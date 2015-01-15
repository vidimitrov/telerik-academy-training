using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.GSM
{
    class GSMTest
    {
        static void Main()
        {
            GSM[] mobilephones = {
                 new GSM("Nokia", "X6-00", 500, "Veselin Dimitrov", 3.5, 16000000, "UT-220M", 120, 15, GSM.Battery.BatteryType.NiMh),
                 new GSM("Samsung", "Galaxy S III", 1100, "Gosho", 4.5, 16000000, "X-980W", 150, 15, GSM.Battery.BatteryType.NiCd),
                 new GSM("LG", "KP 500", 300, "Stoyan", 3.2, 56000, "UA-210H", 100, 10, GSM.Battery.BatteryType.LiIon)
            };
            Console.WriteLine(GSM.IPhone4S);
            Console.WriteLine("");
            foreach (GSM gsm in mobilephones)
            {
                Console.WriteLine(gsm.ToString());
                Console.WriteLine("");
            }

           
        }
    }
}
