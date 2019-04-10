using CurExample.DataRead;
using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CurExample
{
    public class Program
    {
        
        public static void DataManager()
        {
            while (true)
            {
                var readClass = new XmlRead();
                var currencyList = readClass.Read();
                Thread.Sleep(20000);
                //var timer = new System.Timers.Timer();
                //timer.Interval = 20000;
                //timer.Enabled = true;

            }
        }


        static void Main(string[] args)
        {
            var thread = new Thread(new ThreadStart(DataManager));
            thread.Start();
            
            
            Console.ReadKey();
        }
    }
}
