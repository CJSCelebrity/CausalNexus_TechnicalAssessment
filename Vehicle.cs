using System;
using System.Drawing;
using System.Threading;
using Console = Colorful.Console;

namespace ultimaterace
{
    public class Vehicle
    {
        // Robinson R22
        public int chopperfuelcapacitygallons = 20;
        public int chopperFuelUsageperhourgallons = 8;
        public int chopperAvgSpeedkmh = 180;    // Traveling in the air. No limits!
        public int choppertimetorefuelhrs = 3;
        public double chopperbreakdownprobability = 0.2;

        // KTM 450 Rally
        public double bikefueltankliters = 33.6;
        public double bikekmperlitre = 8;
        public int bikespeedmph = 100;      // Traveling on dirt roads. No cops there!
        public double biketimetorefuelhrs = 0.5;
        public double bikebreakdownprobability = 0.5;

        // Tesla Model-S
        public int teslaenginekw = 310;
        public int teslabatterypack = 700;
        public int teslaspeed = 120;    // Traveling on public roads.
        public double teslatimetorefuelhrs = 1;
        public double teslabreakdownprobability = 0.1;

        // Virginia-Class Submarine
        public int nuclearsubspeedknots = 35; 
        public double subbreakdownprobability = 0.0;

        private string name;
        private int distance;
        public Vehicle(string name,int distance) 
        {
            this.name = name;
            this.distance = distance;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Distance
        {
            get { return distance; }
            set { distance = value; }
        }


        // Text below is to format the way the repair hour is shown
        public static void repairVehicleText(string vehicle) 
        {
            int repairTime = (int)(Common.random.NextDouble() / Common.random.NextDouble() * 1000) + 1000; // Stop at least 1 hour
            string repairHour = (repairTime / 1000).ToString();
            string hourString = int.Parse(repairHour) == 1 ? "hr to repair" : "hrs to repair";
            Console.WriteLine($"{vehicle} has broken down :(", Color.Red);
            Console.WriteLine($"It will take " + repairHour + hourString, Color.Red);
            Thread.Sleep(repairTime);
            switch (vehicle)
            {
                case "sub":
                    Console.WriteLine("Sub is back in the water and in the race!!", Color.Cyan);
                    break;
                case "Chopper":
                    Console.WriteLine("Chopper is back in the air and in the race!!", Color.Orange);
                    break;
                case "Tesla":
                    Console.WriteLine("Tesla is back on the road and in the race!!", Color.Purple);
                    break;
                case "Bike":
                    Console.WriteLine("Bike is back on the dirt tracks and in the race!!", Color.Gold);
                    break;
            }
            
        }
    }
}
