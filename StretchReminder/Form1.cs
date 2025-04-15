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
using System.Runtime.InteropServices;
using System.Globalization;

namespace StretchReminder
{

    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        internal static extern uint SendInput(uint nInputs, [MarshalAs(UnmanagedType.LPArray), In] INPUT[] pInputs, int cbSize);

        //[DllImport("user32.dll", SetLastError = true)]
        //private static extern uint SendInput(uint nInputs, ref INPUT pInputs, int cbSize);

        private const string STATUS_ON = "ON";
        private const string STATUS_OFF = "OFF";

        //IList<Reminder> _reminders = null;
        //Parameters _parameters = null;

        private DateTime _lastCheckTime = DateTime.Now;

        frmMessage message = null;


        private State _currentState = State.OFF;

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
            timePicker.Format = DateTimePickerFormat.Time;
            timePicker.ShowUpDown = true;

            _timer = new System.Windows.Forms.Timer();
            // Hook up the Elapsed event for the timer. 
            _timer.Tick += new EventHandler(OnTimedEvent);
            _timer.Interval = 1000;
            _timer.Start();
            rdoButtonOff.Checked = true;
            _currentState = State.OFF;
            //Global.parameters = new Parameters();
            Global.LoadParameters();
            DateTime dateTime = DateTime.ParseExact(Global.parameters.StopTime, "h:mm tt", CultureInfo.InvariantCulture);
            timePicker.Value = dateTime;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            EXECUTION_STATE prevState = Global.SetThreadExecutionState(EXECUTION_STATE.ES_CONTINUOUS);
            _timer.Dispose();
            Global.SaveParameters();

        }

        private void OnTimedEvent(object? myObject, EventArgs myEventArgs)
        {
            {
                // Don't do anything if the form's handle hasn't been created  
                // or the form has been disposed. 
                if (!this.IsHandleCreated && !this.IsDisposed) return;

                DateTime dt = DateTime.Now;


                INPUT[] i = new INPUT[1];

                i[0].type = 0;
                i[0].U.mi.time = 0;
                i[0].U.mi.dwFlags = MOUSEEVENTF.MOVE;
                i[0].U.mi.dwExtraInfo = UIntPtr.Zero;
                i[0].U.mi.dx = 0;
                i[0].U.mi.dy = 0;

                //var retval = SendInput(1, i, INPUT.Size);

                int seconds = dt.Second;
                uint retval = 0;
                if (seconds % 60 == 0)
                {
                    if (_currentState == State.ON)
                        retval = SendInput(1, i, INPUT.Size);
                    //uint retval2 = retval;
                }

                //var retval = SendInput(1, ref inp, Marshal.SizeOf(inp));

                //if (retval != 1)
                //{
                //    var errcode = Marshal.GetLastWin32Error();
                //}

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

                        //if (dt.Hour >= 18)
                        if (dt.Hour >= timePicker.Value.Hour && dt.Minute >= timePicker.Value.Minute)
                        {
                            if (!rdoButtonOff.Checked)
                            {
                                rdoButtonOff.Checked = true;
                                _lastCheckTime = dt;
                            }

                        }
                    }
                }

                //if (_reminders != null)
                if (Global.parameters != null && Global.parameters.Reminders != null)
                {
                    //foreach (Reminder remind in _reminders)
                    foreach (Reminder remind in Global.parameters.Reminders)
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
            _currentState = state;
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
            frmReminders frmRmnders = new frmReminders();
            frmRmnders.StartPosition = FormStartPosition.Manual;
            frmRmnders.Location = this.Location;
            DialogResult dr = frmRmnders.ShowDialog();
            if (dr == DialogResult.OK)
            {
                //Global.parameters.Reminders = frmRmnders.Parameters.Reminders;
                //Global.parameters.StopTime = timePicker.Value.ToShortTimeString();
                Global.SaveParameters();
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

        private void timePicker_ValueChanged(object sender, EventArgs e)
        {
            Global.parameters.StopTime = timePicker.Value.ToShortTimeString();
        }
    }



    [StructLayout(LayoutKind.Sequential)]
    internal struct MOUSEINPUT
    {
        internal int dx;
        internal int dy;
        internal int mouseData;
        internal MOUSEEVENTF dwFlags;
        internal uint time;
        internal UIntPtr dwExtraInfo;
    }

    internal struct KEYBDINPUT
    {
        internal short wVk;
        internal short wScan;
        internal int dwFlags;
        internal int time;
        internal UIntPtr dwExtraInfo;
    }

    struct HARDWAREINPUT
    {
        internal int uMsg;
        internal short wParamL;
        internal short wParamH;
    }
    

      [Flags]
    internal enum MOUSEEVENTF : uint
    {
        ABSOLUTE = 0x8000,
        HWHEEL = 0x01000,
        MOVE = 0x0001,
        MOVE_NOCOALESCE = 0x2000,
        LEFTDOWN = 0x0002,
        LEFTUP = 0x0004,
        RIGHTDOWN = 0x0008,
        RIGHTUP = 0x0010,
        MIDDLEDOWN = 0x0020,
        MIDDLEUP = 0x0040,
        VIRTUALDESK = 0x4000,
        WHEEL = 0x0800,
        XDOWN = 0x0080,
        XUP = 0x0100
    }

    [StructLayout(LayoutKind.Explicit)]
    internal struct InputUnion
    {
        [FieldOffset(0)]
        internal MOUSEINPUT mi;
        [FieldOffset(0)]
        internal KEYBDINPUT ki;
        [FieldOffset(0)]
        internal HARDWAREINPUT hi;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct INPUT
    {
        internal uint type;
        internal InputUnion U;
        internal static int Size
        {
            get { return Marshal.SizeOf(typeof(INPUT)); }
        }
    }
    //internal struct INPUT
    //{
    //    public int TYPE;
    //    public int dx;
    //    public int dy;
    //    public int mouseData;
    //    public int dwFlags;
    //    public int time;
    //    public IntPtr dwExtraInfo;
    //}
}
