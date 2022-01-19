using System;
using System.Threading;
using System.Threading.Tasks;
using System.Drawing;
using Console = Colorful.Console;

namespace ultimaterace
{
    class Program
    {
        static void Main(string[] args)
        {
            Common.StartingLine();

            for (int i = 0; i < Common.numberofcontents; i++)
            {
                    Common.contestent[i] = new Thread(new ThreadStart(HandleThreadStart));
                    Common.contestent[i].Start();
            }

            CheckForWinner();
        }

        async private static void CheckForWinner() 
        {
            await Task.Run(() =>
            {
                while (!Common.token.IsCancellationRequested)
                {
                    try
                    {
                        // different modes of transport can take shorter routes
                        if (Common.scoreboard.bikeposition > Common.scoreboard.bikedistancetotraveltowin)
                        {
                            Common.cancellationTokenSource.Cancel();
                            Common.Winner("Bike");
                            return;
                        }
                        else if (Common.scoreboard.teslapostion > Common.scoreboard.tesladistancetotraveltowin)
                        {
                            Common.cancellationTokenSource.Cancel();
                            Common.Winner("Tesla");
                            return;
                        }
                        else if (Common.scoreboard.chopperposition > Common.scoreboard.chopperdistancetotraveltowin)
                        {
                            Common.cancellationTokenSource.Cancel();
                            Common.Winner("Chopper");
                            return;

                        }
                        else if (Common.scoreboard.subposition > Common.scoreboard.subdistancetotraveltowin)
                        {
                            Common.cancellationTokenSource.Cancel();
                            Common.Winner("Nuclear Sub");
                            return;
                        }
                        // Every second represents an hour
                        Thread.Sleep(1000);
                        Console.WriteLine("\n------------------\n", Color.Magenta);
                    }
                    catch (OperationCanceledException ex)
                    {
                        Common.cancellationTokenSource.Cancel();
                        Common.UserErrorMessage();
                        return;
                    }

                }
                return;
            }, Common.cancellationTokenSource.Token);

        }

        protected static void HandleThreadStart() {
            if (Common.token.IsCancellationRequested)
            {
                return;
            }
            else 
            {
                switch (Common.currentcontestent)
                {
                    case 0:
                        Common.currentcontestent++;
                        StartChopper();
                        break;
                    case 1:
                        Common.currentcontestent++;
                        StartBike();
                        break;
                    case 2:
                        Common.currentcontestent++;
                        StartTesla();
                        break;
                    case 3:
                        Common.currentcontestent++;
                        StartNuclearSub();
                        break;
                }
            }
        }

        private static void StartNuclearSub()
        {
            Common.scoreboard.subposition = 0;

            while (!Common.token.IsCancellationRequested)
            {
                try
                {
                    Thread.Sleep(1000); // Every second represents an hour
                    Common.scoreboard.subposition = Common.scoreboard.subposition + Common.vehicle.nuclearsubspeedknots * 2;

                    Console.WriteLine("Nuclear sub has travelled \t" + Common.scoreboard.subposition + "km" , Color.Cyan);
                    //Console.WriteLine($"\rRace Completion:{i}% \n");

                    if (Common.random.NextDouble() < Common.vehicle.subbreakdownprobability)
                    {
                        Vehicle.repairVehicleText("sub");
                    }
                    //Scoreboard.percentageDistance();
                } 
                catch (Exception)
                {

                    Common.UserErrorMessage();
                    return;
                }
                
            }
        }

        private static void StartChopper()
        {
            //int time = 0;
            Common.scoreboard.chopperposition = 0;
            int fuel = Common.vehicle.chopperfuelcapacitygallons;

            while (!Common.token.IsCancellationRequested)
            {

                try
                {
                    Thread.Sleep(1000);
                    Common.scoreboard.chopperposition = Common.scoreboard.chopperposition + Common.vehicle.chopperAvgSpeedkmh;
                    Console.WriteLine("Chopper has travelled \t\t" + Common.scoreboard.chopperposition + "km" , Color.Orange);
                    fuel -= Common.vehicle.chopperFuelUsageperhourgallons;

                    if (fuel < 0)
                    {
                        Console.WriteLine("Chopper is out of fuel :(" , Color.Red);
                        Thread.Sleep(Common.vehicle.choppertimetorefuelhrs * 1000);
                        fuel = Common.vehicle.chopperfuelcapacitygallons;
                        Console.WriteLine("Chopper is back in the air and in the race!!" , Color.Orange);
                    }

                    if (Common.random.NextDouble() < Common.vehicle.chopperbreakdownprobability)
                    {
                        Vehicle.repairVehicleText("Chopper");
                    }
                    //Scoreboard.percentageDistance();
                }
                catch (Exception)
                {

                    Common.UserErrorMessage();
                    return;
                }
              
            }
        }

        private static void StartTesla()
        {
            double batteryLeft = Common.vehicle.teslabatterypack;
            Common.scoreboard.teslapostion = 0;

            while (!Common.token.IsCancellationRequested)
            {

                try
                {
                    Thread.Sleep(1000);
                    Common.scoreboard.teslapostion = Common.scoreboard.teslapostion + Common.vehicle.teslaspeed;
                    Console.WriteLine("Tesla has travelled \t\t" + Common.scoreboard.teslapostion + "km" , Color.Purple);
                    batteryLeft -= Common.vehicle.teslaenginekw;

                    if (batteryLeft < 0)
                    {
                        Console.WriteLine("Tesla is out of battery :(" , Color.Red);
                        Thread.Sleep((int)Common.vehicle.teslatimetorefuelhrs * 1000);
                        batteryLeft = Common.vehicle.teslabatterypack;
                        Console.WriteLine("Tesla is back on the road and in the race!!" , Color.Purple);
                    }

                    if (Common.random.NextDouble() < Common.vehicle.teslabreakdownprobability)
                    {
                        Vehicle.repairVehicleText("Tesla");
                    }
                    //Scoreboard.percentageDistance();
                }
                catch (Exception)
                {

                    Common.UserErrorMessage();
                    return;
                }
              
            }
        }

        private static void StartBike()
        {
            Common.scoreboard.bikeposition = 0;
            int fuel = (int) Common.vehicle.bikefueltankliters;

            while (!Common.token.IsCancellationRequested)
            {

                try
                {
                    Thread.Sleep(1000);
                    Common.scoreboard.bikeposition = Common.scoreboard.bikeposition + (int)(Common.vehicle.bikespeedmph * 1.6);
                    Console.WriteLine("Bike has travelled \t\t" + Common.scoreboard.bikeposition + "km" , Color.Gold);
                    fuel -= (int)(Common.vehicle.bikespeedmph / Common.vehicle.bikekmperlitre);

                    if (fuel < 0)
                    {
                        Console.WriteLine("Bike is out of fuel :(" , Color.Red);
                        Thread.Sleep((int)(Common.vehicle.biketimetorefuelhrs * 1000));
                        fuel = (int)Common.vehicle.bikefueltankliters;
                        Console.WriteLine("Bike is back on the dirt tracks and in the race!!" , Color.Gold);
                    }


                    if (Common.random.NextDouble() < Common.vehicle.bikebreakdownprobability)
                    {
                        Vehicle.repairVehicleText("Bike");
                    }
                    //Scoreboard.percentageDistance();
                }
                catch (Exception)
                {

                    Common.UserErrorMessage();
                    return;
                }
                
            }
        }
    }
}