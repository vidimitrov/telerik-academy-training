using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.GSM
{
    public class GSM
    {
        public string model;
        public string manufacturer;
        public double price;
        public string owner;

        public string Model
        {
            get{return model;}
            set 
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Wrong value for GSM-model!");
                }
                this.model = value;
            }
        }
        public string Manufacturer
        {
            get { return manufacturer; }
            set
            {
                if ((String.IsNullOrEmpty(value)) || (value.Length < 3))
                {
                    throw new ArgumentException("Wrong value for manufacturer!");
                }
                this.manufacturer = value;
            }
        }
        public double Price
        {
            get { return price; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Wrong value of GSM-price!");
                }
                this.price = value;
            }
        }
        public string Owner
        {
            get { return owner; }
            set
            {
                if ((String.IsNullOrEmpty(value)) || (value.Length < 3))
                {
                    throw new ArgumentException("Wrong value for owner!");
                }
                this.owner = value;
            }
        }

        Battery battery = new Battery();
        Display display = new Display();

        //IPhone 4S
        private static GSM iPhone4s = new GSM("IPhone", "4S", 1000, "Pesho", 4.3, 16000000,
            "BH-400s", 100, 15, Battery.BatteryType.LiIon);
        public static string IPhone4S
        {
            get
            {
                return iPhone4s.ToString();
            }
        }

        public GSM(string model, string manufacturer)
        {
            this.model = model;
            this.manufacturer = manufacturer;
        }

        public GSM(string manufacturer, string model, double price, string owner, double size,
            int color, string batModel, int hIdle, int hTalk, Battery.BatteryType type)
        {
            this.model = model;
            this.manufacturer = manufacturer;
            this.price = price;
            this.owner = owner;

            this.display.Size = size;
            this.display.Colors = color;

            this.battery.Model = batModel;
            this.battery.HoursIdle = hIdle;
            this.battery.HoursTalk = hTalk;
            this.battery.Type = type;

        }
        
        //Display class

        public class Display
        {
            public double size;
            public int colors;

            public double Size
            {
                get { return size; }
                set
                {
                    if ((value > 10) || (value < 1))
                    {
                        throw new ArgumentException("Wrong display size!");
                    }
                    this.size = value;
                }
            }
            public int Colors
            {
                get { return colors; }
                set
                {
                    if ((colors > 16000000) || (size < 2))
                    {
                        throw new ArgumentException("Wrong value for colors!");
                    }
                    this.colors = value;
                }
            }
            public Display() { }
            public Display(float size, int colors)
            {
                this.size = size;
                this.colors = colors;
            }
        }

        //Battery class

        public class Battery
        {
            public string batteryModel;
            public int hoursIdle;
            public int hoursTalk;

            public enum BatteryType
            {
                LiIon, NiCd, NiMh
            }
            private BatteryType type;
            public BatteryType Type
            {
                get { return type; }
                set 
                {
                    this.type = value;
                }
            }

            public string Model
            {
                get { return batteryModel; }
                set
                {
                    if ((String.IsNullOrEmpty(value)) || (value.Length < 3))
                    {
                        throw new ArgumentException("Wrong value of battery-model!");
                    }
                    this.batteryModel = value;
                }
            }
            public int HoursIdle
            {
                get { return hoursIdle; }
                set
                {
                    if ((value < 1) || (value > 1500))
                    {
                        throw new ArgumentException("Wrong value of hours-idle!");
                    }
                    this.hoursIdle = value;
                }
            }
            public int HoursTalk
            {
                get { return hoursTalk; }
                set
                {
                    if ((value < 0) || (value > 20))
                    {
                        throw new ArgumentException("Wrong value of hours-talk!");
                    }
                    this.hoursTalk = value;
                }
            }
            public Battery() { }
            public Battery(string model, int hIdle, int hTalk, BatteryType type)
            {
                this.batteryModel = model;
                this.hoursIdle = hIdle;
                this.hoursTalk = hTalk;
                this.type = type;
            }
        }
       
        //Overriding ToString()

        public override string ToString()
        {
            string info = "GSM model: " + this.model + "\nGSM manufacturer: " + this.manufacturer + "\nOwner: " + this.owner + "\nPrice of the phone: $" +
                this.price + "\nThe battery-model of " + this.manufacturer + " " + this.model + " is " + battery.Model + ".\nSpecifications: " +
                battery.HoursIdle + " hours idle and " + battery.HoursTalk + " hours talk\nBattey-type: " + battery.Type + "\nDisplay: " +
                display.Size + " inches and " + display.Colors + " colors";
            return info;
        }
    }
}
