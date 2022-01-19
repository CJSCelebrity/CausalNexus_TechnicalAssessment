using System;
using System.Threading;
using System.Drawing;
using Console = Colorful.Console;
using System.Collections.Generic;

namespace ultimaterace
{
    public class Scoreboard
    {
        public Scoreboard()
        {
        }

        public static int distanceToCover = 10000;

        public int chopperdistancetotraveltowin = 10000;
        public int bikedistancetotraveltowin = 10000;
        public int tesladistancetotraveltowin = 10000;
        public int subdistancetotraveltowin = 10000;
        public int truckDistanceToWin = 10000;
        public int lawnmowerPositionToWin = 10000;

        private int chprposition;
        public int chopperposition
        {
            set
            {
                chprposition = value;
            }
            get
            {
                return chprposition;
            }
        }

        private int bkposition;
        public int bikeposition
        {
            set
            {
                bkposition = value;
            }
            get
            {
                return bkposition;
            }
        }

        private int tsla;
        public int teslapostion
        {
            get
            {
                return tsla;
            }
            set
            {
                tsla = value;
            }
        }

        private int sub;
        public int subposition
        {
            get
            {
                return sub;
            }
            set
            {
                sub = value;
            }
        }

        private static string secondPos;
        private static string thirdPos;
        private static string fourthPos;

        //public static void percentageDistance()
        //{
        //    for (int i = 0; i < distanceToCover; i++)
        //    {
        //        Console.WriteLine($"\rProgress:{i}% ", Color.IndianRed);
        //        Thread.Sleep(850);
        //    }
        //}

        public static void determineTrophyPositions(int bikePos,int teslaPos,int chopperPos, int subPos) 
        {
            List<Vehicle> VehicleList = new List<Vehicle>
            {
                new Vehicle("Bike", bikePos),
                new Vehicle("Tesla", teslaPos),
                new Vehicle("Chopper", chopperPos),
                new Vehicle("Sub", subPos)
            };

            var positionList = new List<int> { bikePos, teslaPos, chopperPos, subPos };

            positionList.Sort();

            foreach (var item in VehicleList)
            {
                if(item.Distance == positionList[2]) secondPos = item.Name;
                if(item.Distance == positionList[1]) thirdPos = item.Name;
                if(item.Distance == positionList[0]) fourthPos = item.Name;
            }

            Console.WriteLine($"\nIn 2nd place -- {secondPos} \nIn 3rd place -- {thirdPos} \nIn 4th place -- {fourthPos}\n",Color.Green);
        }
    }
}
