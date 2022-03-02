namespace StretchReminder
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnToggleScreenSaver = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.rdoButtonOn = new System.Windows.Forms.RadioButton();
            this.rdoButtonOff = new System.Windows.Forms.RadioButton();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.lblTime = new System.Windows.Forms.Label();
            this.btnSetReminders = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.lblCutOff = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnToggleScreenSaver
            // 
            this.btnToggleScreenSaver.BackColor = System.Drawing.Color.Red;
            this.btnToggleScreenSaver.Location = new System.Drawing.Point(92, 35);
            this.btnToggleScreenSaver.Name = "btnToggleScreenSaver";
            this.btnToggleScreenSaver.Size = new System.Drawing.Size(91, 55);
            this.btnToggleScreenSaver.TabIndex = 0;
            this.btnToggleScreenSaver.Text = "OFF";
            this.btnToggleScreenSaver.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(56, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Stretch Reminder Status";
            // 
            // rdoButtonOn
            // 
            this.rdoButtonOn.AutoSize = true;
            this.rdoButtonOn.Font = new System.Drawing.Font("Microsoft Sans Serif", 4.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rdoButtonOn.Location = new System.Drawing.Point(40, 37);
            this.rdoButtonOn.Name = "rdoButtonOn";
            this.rdoButtonOn.Size = new System.Drawing.Size(38, 16);
            this.rdoButtonOn.TabIndex = 2;
            this.rdoButtonOn.TabStop = true;
            this.rdoButtonOn.Text = "ON";
            this.rdoButtonOn.UseVisualStyleBackColor = true;
            this.rdoButtonOn.CheckedChanged += new System.EventHandler(this.rdoButtonOn_CheckedChanged);
            // 
            // rdoButtonOff
            // 
            this.rdoButtonOff.AutoSize = true;
            this.rdoButtonOff.Font = new System.Drawing.Font("Microsoft Sans Serif", 4.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rdoButtonOff.Location = new System.Drawing.Point(40, 63);
            this.rdoButtonOff.Name = "rdoButtonOff";
            this.rdoButtonOff.Size = new System.Drawing.Size(42, 16);
            this.rdoButtonOff.TabIndex = 3;
            this.rdoButtonOff.TabStop = true;
            this.rdoButtonOff.Text = "OFF";
            this.rdoButtonOff.UseVisualStyleBackColor = true;
            this.rdoButtonOff.CheckedChanged += new System.EventHandler(this.rdoButtonOff_CheckedChanged);
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(17, 149);
            this.monthCalendar1.Margin = new System.Windows.Forms.Padding(9, 11, 9, 11);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 4;
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTime.Location = new System.Drawing.Point(189, 46);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(45, 18);
            this.lblTime.TabIndex = 6;
            this.lblTime.Text = "Time:";
            // 
            // btnSetReminders
            // 
            this.btnSetReminders.Location = new System.Drawing.Point(92, 396);
            this.btnSetReminders.Name = "btnSetReminders";
            this.btnSetReminders.Size = new System.Drawing.Size(121, 29);
            this.btnSetReminders.TabIndex = 7;
            this.btnSetReminders.Text = "Set Reminders";
            this.btnSetReminders.UseVisualStyleBackColor = true;
            this.btnSetReminders.Click += new System.EventHandler(this.btnSetReminders_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dateTimePicker1.Location = new System.Drawing.Point(65, 101);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(229, 21);
            this.dateTimePicker1.TabIndex = 8;
            // 
            // lblCutOff
            // 
            this.lblCutOff.AutoSize = true;
            this.lblCutOff.Location = new System.Drawing.Point(5, 103);
            this.lblCutOff.Name = "lblCutOff";
            this.lblCutOff.Size = new System.Drawing.Size(57, 20);
            this.lblCutOff.TabIndex = 9;
            this.lblCutOff.Text = "Cut off:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 466);
            this.Controls.Add(this.lblCutOff);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.btnSetReminders);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.rdoButtonOff);
            this.Controls.Add(this.rdoButtonOn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnToggleScreenSaver);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.ShowInTaskbar = false;
            this.Text = "Stretch Reminder";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnToggleScreenSaver;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rdoButtonOn;
        private System.Windows.Forms.RadioButton rdoButtonOff;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Button btnSetReminders;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label lblCutOff;
    }
}

