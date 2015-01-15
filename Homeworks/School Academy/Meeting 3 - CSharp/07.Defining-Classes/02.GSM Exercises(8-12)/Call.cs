using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.GSM
{
    public class Call
    {
        private string date;
        private string time;
        private string number;
        private int duration;

        public string Date
        {
            get { return date; }
        }
        public string Time
        {
            get { return time; }
        }
        public string Number
        {
            get { return number; }
        }
        public int Duration
        {
            get { return duration; }
        }

        public Call(string date, string time, string number, int duration)
        {
            this.date = date;
            this.time = time;
            this.number = number;
            this.duration = duration;
        }
    }
}
