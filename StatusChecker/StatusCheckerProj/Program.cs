using System;
using System.Timers;

namespace StatusChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            Timer timer = new Timer(30000);
            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;
            timer.Start();
        }

        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            string[,] ipAddresses = {
                { "", "" },
                { "", "" },
                { "", "" }
            }

            for (int i = 0; i < ipAddresses[-1].Length; i++)
            {
                StatusGetter statusGetter = new StatusGetter();
                bool status = statusGetter.GetStatus(IP[i]);

                if (status == true)
                {
                    // Discord : Online
                }
                else
                {
                    // Discord : Offline
                }
            }
        }
    }
}
