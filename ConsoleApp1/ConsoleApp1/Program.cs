using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        public static void PrintList(Dictionary<int,string> songs)
        {
            foreach (var song in songs)
            {

            }
        }
        static void Main(string[] args)
        {
            var songs = new Dictionary<int, string>();
            Console.WriteLine("Odaberite akciju:");
            Console.WriteLine("1 - Ispis cijele liste");
            Console.WriteLine("2 - Ispis imena pjesme unosom pripadajućeg rednog broja");
            Console.WriteLine("3 - Ispis rednog broja pjesme unosom pripadajućeg imena");
            Console.WriteLine("4 - Unos nove pjesme");
            Console.WriteLine("5 - Brisanje pjesme po rednom broju");
            Console.WriteLine("6 - Brisanje pjesme po imenu");
            Console.WriteLine("7 - Brisanje cijele liste");
            Console.WriteLine("8 - Uređivanje imena pjesme");
            Console.WriteLine("9 - Uređivanje rednog broja pjesme, odnosno premještanje pjesme na novi redni broj u listi");
            Console.WriteLine("0 - Izlaz iz aplikacije");
            var userChoice = int.Parse(Console.ReadLine());
            switch (userChoice)
            {
                case 1:
                    {
                        break;
                    }
                case 2:
                    {
                        break;
                    }
                case 3:
                    {
                        break;
                    }
                case 4:
                    {
                        break;
                    }
                case 5:
                    {
                        break;
                    }
                case 6:
                    {
                        break;
                    }
                case 7:
                    {
                        break;
                    }
                case 8:
                    {
                        break;
                    }
                case 9:
                    {
                        break;
                    }
                case 0:
                    {
                        break;
                    }
                default:
                    break;
            }
        }
    }
}
