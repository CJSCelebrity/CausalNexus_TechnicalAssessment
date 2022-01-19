using System;
using System.Drawing;
using System.Threading;
using Console = Colorful.Console;

namespace ultimaterace
{
    public class Common
    {
        public static int numberofcontents = 6;
        public static Thread[] contestent = new Thread[numberofcontents];
        public static int currentcontestent = 0;
        public static Scoreboard scoreboard = new Scoreboard();
        public static Vehicle vehicle = new Vehicle("",0);
        public static Random random = new Random();
        public static bool bikeHasWon = false;
        public static bool teslaHasWon = false;
        public static bool subHasWon = false;
        public static bool chopperStopped = false;
        public static CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        public static CancellationToken token = cancellationTokenSource.Token;

        public static void StartingLine() {

            Console.WriteLine("WELCOME!!!");
            Thread.Sleep(850);
            Console.WriteLine("To the ULTIMATE RACE!!!");
            Thread.Sleep(850);
            Console.WriteLine("Travel from Cairo to Cape Town.");
            Thread.Sleep(850);
            Console.Write("A journey of blood");
            Thread.Sleep(850);
            Console.Write(", sweat");
            Thread.Sleep(850);
            Console.WriteLine(", and gears!");
            Thread.Sleep(850);
            Console.WriteLine("Before we start, we know you folks love to familiarize yourself with the track,");
            Thread.Sleep(850);
            Console.WriteLine("So here are some fancy colors to show you who's who");
            Thread.Sleep(850);
            Console.WriteLine("CYAN --- Nuclear sub", Color.Cyan);
            Console.WriteLine("ORANGE --- Chopper", Color.Orange);
            Console.WriteLine("PURPLE --- Tesla", Color.Purple);
            Console.WriteLine("GOLD --- Bike\n", Color.Gold);
            Thread.Sleep(850);
            Console.WriteLine("GREEN signifies the winner!",Color.Green);
            Console.WriteLine("RED signifies if anything has happened to the participants", Color.Red);
            Thread.Sleep(850);
            Console.Write("Press 'Enter' to begin the race\n");
            if (Console.ReadKey().Key == ConsoleKey.Enter)
            {
                Thread.Sleep(850);
                Console.WriteLine("\nAlrighty\nGentlemen and lady, start your engines!");
                Thread.Sleep(850);
                Console.WriteLine("3");
                Thread.Sleep(850);
                Console.WriteLine("2");
                Thread.Sleep(850);
                Console.WriteLine("1");
                Console.WriteLine("Go!!!!");
                Thread.Sleep(850);
                Console.WriteLine("\n------------------\n", Color.Magenta);
            }
        }


        public static void Winner(string vehicle) {
            Console.WriteLine("\n!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!", Color.Green);
            Console.WriteLine($"{vehicle} has won!", Color.Green);
            Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!", Color.Green);
            Scoreboard.determineTrophyPositions(scoreboard.bikeposition, scoreboard.teslapostion, scoreboard.chopperposition, scoreboard.subposition);
        }

        public static void UserErrorMessage() {
            Console.WriteLine("Oh no! It looks like we lost connectivity to the race. Alright, time for a commercial break.");
        }
    }
}
