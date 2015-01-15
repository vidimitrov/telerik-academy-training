using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.GSM
{
    class GSMCallHistoryTest
    {
        static void Main()
        {
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Add three calls to CallHistory.");
            Console.WriteLine("-------------------------------");
            GSM.AddCall("0896677670", 59);
            GSM.AddCall("0892567432", 120);
            GSM.AddCall("0898345678", 259);

            string str = "";
            List<Call> history = GSM.CallHistory;
            foreach (Call call in history)
            {
                Console.WriteLine("");
                str = "Called number: " + call.Number + "\nDuration: " + call.Duration + " s.\nDate: " + call.Date + " " + call.Time;
                Console.WriteLine(str);
            }

            GSM.RemoveCall(0);
            Console.WriteLine("");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("First call is removed.");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("");

            history = GSM.CallHistory;
            foreach (Call call in history)
            {
                Console.WriteLine("");
                str = "Called number: " + call.Number + "\nDuration: " + call.Duration + " s.\nDate: " + call.Date + " " + call.Time;
                Console.WriteLine(str);
            }
            double pricePerMinute = 0.36;
            double totalPrice = GSM.TotalPrice(pricePerMinute);
            Console.WriteLine("");

            Console.WriteLine("-------------------------------");
            Console.WriteLine("With price of {0} the total price is: ${1}",pricePerMinute, totalPrice);
            Console.WriteLine("-------------------------------");
            Console.WriteLine("");

            GSM.ClearHistory();
            Console.WriteLine("-------------------------------");
            Console.WriteLine("The history is cleared.");
            Console.WriteLine("-------------------------------");

            //history = GSM.CallHistory;
            //foreach (Call call in history)
            //{
            //    Console.WriteLine("");
            //    str = "Called number: " + call.Number + "\nDuration: " + call.Duration + " s.\nDate: " + call.Date + " " + call.Time;
            //    Console.WriteLine(str);
            //}
        }
    }
}
