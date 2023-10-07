using System;
using System.Collections;
using System.Timers;

namespace StatusChecker {
    class Program : StatusGetter{
        static void Main()
        {
            System.Timers.Timer checkerTimer = new System.Timers.Timer(30000); // 30s
            checkerTimer.Elapsed += OnTimedEvent;
            checkerTimer.AutoReset = true;
            checkerTimer.Start();

            Console.WriteLine("Press 'Enter' to exit the program.");
            Console.ReadLine();

            checkerTimer.Stop();
        }

        private static async void OnTimedEvent(object? source, ElapsedEventArgs e)
        {
            try {
                string[] services = {"Discord Bot", "Emails", "Websites", "DayZ Server"};
                StatusGetter statusChecker = new StatusGetter();
                Discord discord = new Discord();

                for (int i = 0; i < services.Length; i++) {
                    string serviceStatus = statusChecker.CheckServiceStatus(services[i]);
                    string[] parts = serviceStatus.Split(' ');
                    string status = parts[0];
                    string serviceName = parts[1];

                    if (status == "Online") {
                        await Discord.StartBotAndStatus(true);
                    } else {
                        await Discord.StartBotAndStatus(false);
                    }
                }
            } catch (Exception ex) {
                System.Console.WriteLine($"Error: {ex}");
            }
        }
    }
}