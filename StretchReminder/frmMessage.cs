using System;
using System.Windows.Forms;
using System.Media;
namespace StretchReminder
{
    public partial class frmMessage : Form
    {
        public static bool IsVisible { get; set; }
        public frmMessage(String message)
        {
            InitializeComponent();
            label1.Text = message;
            IsVisible = true;
            //string sound = @"C:\Windows\Media\Cityscape\Windows Balloon.wav";
            //System.Media.SoundPlayer sp = new SoundPlayer(sound);
            //sp.Play();
            System.Media.SystemSounds.Beep.Play();
            
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            IsVisible = false;
            this.Close();
        }
    }
}
