using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Web.Script.Serialization;

namespace StretchReminder
{
    public partial class frmReminders : Form
    {

        public IList<Reminder> _reminders { get; set; }

        public frmReminders(IList<Reminder> reminders)
        {
            InitializeComponent();
            dataGridView1.AllowUserToAddRows = true;
            dataGridView1.AllowUserToDeleteRows = true;
            _reminders = reminders;
        }

        private void Reminders_Load(object sender, EventArgs e)
        {
            try
            {                
                DataTable dt = new DataTable();
                dt.Columns.Add("Interval", typeof(int));                
                dt.Columns.Add("Description", typeof(String));
                dt.Columns.Add("Enabled", typeof(bool));

                if (_reminders != null)
                {
                    for (int i = 0; i < _reminders.Count; i++)
                    {
                        DataRow dr = dt.NewRow();
                        dr[0] = _reminders[i].interval;
                        dr[1] = _reminders[i].description;                        
                        dr[2] = _reminders[i].enabled;
                        dt.Rows.Add(dr);
                    }
                }

                dataGridView1.DataSource = dt;
            }
            catch(Exception ex)
            {
                string msg = ex.Message;
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DataTable dt = dataGridView1.DataSource as DataTable;
            _reminders = new Reminders();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Reminder reminder = new Reminder();
                DataRow dr = dt.Rows[i];
                reminder.interval = Convert.ToInt32(dr[0]);
                reminder.description = dr[1].ToString();
                reminder.enabled = Convert.ToBoolean(dr[2]);
                _reminders.Add(reminder);
            }            
        }
    }
}
