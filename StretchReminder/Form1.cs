using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Media;

namespace StretchReminder
{
  
    public partial class Form1 : Form
    {
        private const string STATUS_ON = "ON";
        private const string STATUS_OFF = "OFF";

        IList<Reminder> _reminders = null;

        private DateTime _lastCheckTime = DateTime.Now;

        frmMessage message = null;
        bool _moveMouse = false;

        private enum State
        {
            ON,
            OFF
        };

        private System.Windows.Forms.Timer _timer;         

        public Form1()
        {
            InitializeComponent();

            lblTime.Text = string.Format("Time: {0:T}", DateTime.Now);
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "MMM dd yyyy hh:mmtt";
            dateTimePicker1.ShowCheckBox = true;
            int year = DateTime.Now.Year;
            int month = DateTime.Now.Month;
            int day = DateTime.Now.Day;

            dateTimePicker1.Value = new DateTime(year, month, day, 18, 0, 0);

            _timer = new System.Windows.Forms.Timer();
            // Hook up the Elapsed event for the timer. 
            _timer.Tick += new EventHandler(OnTimedEvent);
            _timer.Interval = 1000;
            _timer.Start();
            rdoButtonOff.Checked = true;
            LoadReminders();
        }        

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            EXECUTION_STATE prevState = Global.SetThreadExecutionState(EXECUTION_STATE.ES_CONTINUOUS);
            _timer.Dispose();
            
        }

        private void OnTimedEvent(Object myObject, EventArgs myEventArgs)               
        {
            {
                // Don't do anything if the form's handle hasn't been created  
                // or the form has been disposed. 
                if (!this.IsHandleCreated && !this.IsDisposed) return;

                DateTime dt = DateTime.Now;

                //int minute = dt.Minute;
                //if (minute % 5 == 0)
                //{
                //    //SendKeys.Send("{SCROLLLOCK}");
                //    if (_moveMouse == true)
                //    {
                //        MoveCursor();
                //        _moveMouse = false;
                //    }
                //}
                //else
                //{
                //    _moveMouse = true;                     
                //}

                // Show the current time in the form's title bar. 
                lblTime.Text = string.Format("Time: {0:T}", dt);

                if (dateTimePicker1.Checked)
                {
                    if (dt.CompareTo(dateTimePicker1.Value) >= 0)
                    {
                        if (!rdoButtonOff.Checked)
                        {
                            rdoButtonOff.Checked = true;
                            _lastCheckTime = dt;
                        }
                    }
                }
                else
                {
                    //If its after 18 and user click ON button - give 10 minute grace period
                    if (dt.Subtract(_lastCheckTime).TotalMinutes > 10)
                    {

                        if (dt.Hour >= 18)
                        {
                            if (!rdoButtonOff.Checked)
                            {
                                rdoButtonOff.Checked = true;
                                _lastCheckTime = dt;
                            }

                        }
                    }
                }

                if (_reminders != null)
                {
                    foreach (Reminder remind in _reminders)
                    {
                        Console.WriteLine(remind.description + "  Min: " + dt.Subtract(remind.lastreminder).TotalMinutes);
                        if (!remind.enabled)
                            continue;

                        if (dt.Subtract(remind.lastreminder).TotalMinutes > remind.interval)
                        {
                            remind.lastreminder = DateTime.Now;
                            if (!frmMessage.IsVisible)
                            {
                                message = new frmMessage(remind.description);
                                message.StartPosition = FormStartPosition.Manual;
                                message.Location = this.Location;
                                message.ShowDialog();
                                message = null;
                                frmMessage.IsVisible = false;
                            }
                        }


                    }
                }

            }
        }
        private void ToggleState(State state)
        {
            EXECUTION_STATE prevState;
            if (state == State.ON)
            {

                prevState = Global.SetThreadExecutionState(EXECUTION_STATE.ES_DISPLAY_REQUIRED | EXECUTION_STATE.ES_CONTINUOUS | EXECUTION_STATE.ES_SYSTEM_REQUIRED);
                btnToggleScreenSaver.Text = STATUS_ON;
                btnToggleScreenSaver.BackColor = Color.Green;                
                //_timer.Enabled = true;
            }
            else if (state == State.OFF)
            {
                prevState = Global.SetThreadExecutionState(EXECUTION_STATE.ES_CONTINUOUS);
                btnToggleScreenSaver.Text = STATUS_OFF;
                btnToggleScreenSaver.BackColor = Color.Red;
                //_timer.Enabled = false;
            }
        }
        private void rdoButtonOn_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoButtonOn.Checked == true)
                ToggleState(State.ON);
            else
                ToggleState(State.OFF);
        }

        //Don't really need this guy
        private void rdoButtonOff_CheckedChanged(object sender, EventArgs e)
        {
            bool bval = rdoButtonOff.Checked;
        }

        private void btnSetReminders_Click(object sender, EventArgs e)
        {
            frmReminders frmRmnders = new frmReminders(_reminders);
            frmRmnders.StartPosition = FormStartPosition.Manual;
            frmRmnders.Location = this.Location;
            DialogResult dr = frmRmnders.ShowDialog();
            if (dr == DialogResult.OK)
                _reminders = frmRmnders._reminders;
        }

        private void LoadReminders()
        {
            try
            {
                String file = "reminders.json";
                String jsonReminders = null;
                if (File.Exists(file))
                {
                    using (StreamReader reader = new StreamReader(file))
                    {
                        jsonReminders = reader.ReadToEnd();
                    }
                }

                //reminders = null;
                if (!String.IsNullOrWhiteSpace(jsonReminders))
                {
                    //_reminders = new JavaScriptSerializer().Deserialize<IList<Reminder>>(jsonReminders);
                    _reminders = JsonSerializer.Deserialize<IList<Reminder>>(jsonReminders);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SaveReminders()
        {
            try
            {
                //JavaScriptSerializer jss = new JavaScriptSerializer();
                string jsReminders = JsonSerializer.Serialize(_reminders);
                //String jsReminders = jss.Serialize(_reminders);

                using (StreamWriter sw = new StreamWriter("reminders.json"))
                {
                    sw.Write(jsReminders);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MoveCursor()
        {
            // Set the Current cursor, move the cursor's Position,
            // and set its clipping rectangle to the form. 

            this.Cursor = new Cursor(Cursor.Current.Handle);
            Cursor.Position = new Point(Cursor.Position.X - 50, Cursor.Position.Y - 50);
            Cursor.Clip = new Rectangle(this.Location, this.Size);
        }
    }
}
