using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Text.Json;

namespace StretchReminder
{
    [FlagsAttribute]
    public enum EXECUTION_STATE : uint
    {
        ES_AWAYMODE_REQUIRED = 0x00000040,
        ES_CONTINUOUS = 0x80000000,
        ES_DISPLAY_REQUIRED = 0x00000002,
        ES_SYSTEM_REQUIRED = 0x00000001
        // Legacy flag, should not be used.
        // ES_USER_PRESENT = 0x00000004
    }

    public static class Global
    {
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern EXECUTION_STATE SetThreadExecutionState(EXECUTION_STATE esFlags);

        public static Parameters parameters = null;
        public static void SaveParameters()
        {
            try
            {
                if (parameters == null)
                {
                    parameters = new Parameters();
                    parameters.StopTime = DateTime.Now.ToShortTimeString(); 
                }
                //string stopTime = stopTime;
                string jsReminders = JsonSerializer.Serialize(parameters);

                using (StreamWriter sw = new StreamWriter("parameters.json"))
                {
                    sw.Write(jsReminders);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public static void LoadParameters()
        {
            try
            {
                //String file = "reminders.json";
                String file = "parameters.json";
                String? jsonParams = null;
                //if (File.Exists(file))
                if (!File.Exists(file))
                {
                    parameters = new Parameters();
                    parameters.StopTime = "5:30 PM";
                    return;
                }
                else
                {
                    using (StreamReader reader = new StreamReader(file))
                    {
                        jsonParams = reader.ReadToEnd();
                    }
                }

                //reminders = null;
                if (!String.IsNullOrWhiteSpace(jsonParams))
                {
                    //_reminders = new JavaScriptSerializer().Deserialize<IList<Reminder>>(jsonReminders);
                    parameters = JsonSerializer.Deserialize<Parameters>(jsonParams) as Parameters;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


    }
}
