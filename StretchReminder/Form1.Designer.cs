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
            btnToggleScreenSaver = new Button();
            label1 = new Label();
            rdoButtonOn = new RadioButton();
            rdoButtonOff = new RadioButton();
            monthCalendar1 = new MonthCalendar();
            lblTime = new Label();
            btnSetReminders = new Button();
            dateTimePicker1 = new DateTimePicker();
            lblCutOff = new Label();
            lblStop = new Label();
            timePicker = new DateTimePicker();
            SuspendLayout();
            // 
            // btnToggleScreenSaver
            // 
            btnToggleScreenSaver.BackColor = Color.Red;
            btnToggleScreenSaver.Location = new Point(80, 26);
            btnToggleScreenSaver.Margin = new Padding(3, 2, 3, 2);
            btnToggleScreenSaver.Name = "btnToggleScreenSaver";
            btnToggleScreenSaver.Size = new Size(80, 41);
            btnToggleScreenSaver.TabIndex = 0;
            btnToggleScreenSaver.Text = "OFF";
            btnToggleScreenSaver.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(49, 8);
            label1.Name = "label1";
            label1.Size = new Size(133, 15);
            label1.TabIndex = 1;
            label1.Text = "Stretch Reminder Status";
            // 
            // rdoButtonOn
            // 
            rdoButtonOn.AutoSize = true;
            rdoButtonOn.Font = new Font("Microsoft Sans Serif", 4.8F);
            rdoButtonOn.Location = new Point(35, 28);
            rdoButtonOn.Margin = new Padding(3, 2, 3, 2);
            rdoButtonOn.Name = "rdoButtonOn";
            rdoButtonOn.Size = new Size(32, 13);
            rdoButtonOn.TabIndex = 2;
            rdoButtonOn.TabStop = true;
            rdoButtonOn.Text = "ON";
            rdoButtonOn.UseVisualStyleBackColor = true;
            rdoButtonOn.CheckedChanged += rdoButtonOn_CheckedChanged;
            // 
            // rdoButtonOff
            // 
            rdoButtonOff.AutoSize = true;
            rdoButtonOff.Font = new Font("Microsoft Sans Serif", 4.8F);
            rdoButtonOff.Location = new Point(35, 47);
            rdoButtonOff.Margin = new Padding(3, 2, 3, 2);
            rdoButtonOff.Name = "rdoButtonOff";
            rdoButtonOff.Size = new Size(35, 13);
            rdoButtonOff.TabIndex = 3;
            rdoButtonOff.TabStop = true;
            rdoButtonOff.Text = "OFF";
            rdoButtonOff.UseVisualStyleBackColor = true;
            rdoButtonOff.CheckedChanged += rdoButtonOff_CheckedChanged;
            // 
            // monthCalendar1
            // 
            monthCalendar1.Location = new Point(15, 135);
            monthCalendar1.Margin = new Padding(8);
            monthCalendar1.Name = "monthCalendar1";
            monthCalendar1.TabIndex = 4;
            // 
            // lblTime
            // 
            lblTime.AutoSize = true;
            lblTime.Font = new Font("Microsoft Sans Serif", 9F);
            lblTime.Location = new Point(165, 34);
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(38, 15);
            lblTime.TabIndex = 6;
            lblTime.Text = "Time:";
            // 
            // btnSetReminders
            // 
            btnSetReminders.Location = new Point(80, 306);
            btnSetReminders.Margin = new Padding(3, 2, 3, 2);
            btnSetReminders.Name = "btnSetReminders";
            btnSetReminders.Size = new Size(106, 22);
            btnSetReminders.TabIndex = 7;
            btnSetReminders.Text = "Set Reminders";
            btnSetReminders.UseVisualStyleBackColor = true;
            btnSetReminders.Click += btnSetReminders_Click;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Font = new Font("Microsoft Sans Serif", 7.2F);
            dateTimePicker1.Location = new Point(57, 101);
            dateTimePicker1.Margin = new Padding(3, 2, 3, 2);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(201, 18);
            dateTimePicker1.TabIndex = 8;
            // 
            // lblCutOff
            // 
            lblCutOff.AutoSize = true;
            lblCutOff.Location = new Point(4, 102);
            lblCutOff.Name = "lblCutOff";
            lblCutOff.Size = new Size(47, 15);
            lblCutOff.TabIndex = 9;
            lblCutOff.Text = "Cut off:";
            // 
            // lblStop
            // 
            lblStop.AutoSize = true;
            lblStop.Location = new Point(8, 77);
            lblStop.Name = "lblStop";
            lblStop.Size = new Size(34, 15);
            lblStop.TabIndex = 10;
            lblStop.Text = "Stop:";
            // 
            // timePicker
            // 
            timePicker.Location = new Point(58, 73);
            timePicker.Name = "timePicker";
            timePicker.Size = new Size(200, 23);
            timePicker.TabIndex = 11;
            timePicker.ValueChanged += timePicker_ValueChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(291, 350);
            Controls.Add(timePicker);
            Controls.Add(lblStop);
            Controls.Add(lblCutOff);
            Controls.Add(dateTimePicker1);
            Controls.Add(btnSetReminders);
            Controls.Add(lblTime);
            Controls.Add(monthCalendar1);
            Controls.Add(rdoButtonOff);
            Controls.Add(rdoButtonOn);
            Controls.Add(label1);
            Controls.Add(btnToggleScreenSaver);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            ShowInTaskbar = false;
            Text = "Stretch Reminder";
            FormClosed += Form1_FormClosed;
            ResumeLayout(false);
            PerformLayout();

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
        private Label lblStop;
        private DateTimePicker timePicker;
    }
}

