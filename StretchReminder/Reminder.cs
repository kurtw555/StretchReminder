using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
//using System.Web.Script.Serialization;

namespace StretchReminder
{
    public class Reminder
    {
        //# of minutes
        public int interval { get; set; }
        public String  description { get; set; }
        public bool enabled { get; set; }

        [JsonIgnore]
        public DateTime lastreminder { get; set; }

        public Reminder()
        {
            lastreminder = DateTime.Now;
        }

    }

    public class Reminders : List<Reminder>
    {
        public Reminders() : base()
        {

        }
    }


}
