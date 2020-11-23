using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        public static void OptionsPrint()
        {
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
        }
        public static void PrintList(Dictionary<int,string> songs)
        {
            Console.WriteLine("Lista pjesama:");
            foreach (var song in songs)
            {
                Console.WriteLine("{0}. - {1}",song.Key,song.Value);
            }
        }
        public static void PrintSong(Dictionary<int, string> songs)
        {
            Console.WriteLine("Unesite redni broj pjesme koju želite ispisati:");
            var i = int.Parse(Console.ReadLine());
            foreach (var song in songs)
            {
                if (i == song.Key)
                {
                    Console.WriteLine("Pjesma s upisanim rednim brojem je {0}.",song.Value);
                    goto EndFunction;
                }
            }
            Console.WriteLine("Ne postoji pjesma sa zadanim rednim brojem.");
        EndFunction:;
        }
        public static void PrintOrdinalNumber(Dictionary<int, string> songs)
        {
            Console.WriteLine("Unesite ime pjesme kojoj želite ispisati redni broj:");
            var i = Console.ReadLine();
            foreach (var song in songs)
            {
                if(i==song.Value)
                {
                    Console.WriteLine("Pjesma je {0}. na listi.",song.Key);
                    goto EndFunction;
                }
            }
            Console.WriteLine("Pjesma nije na listi.");
        EndFunction:;
        }
        static void Main(string[] args)
        {
            var songs = new Dictionary<int, string>() {
                {1,"Hello" },
                {2,"Can't hold us" },
                {3,"Butterflies" },
                {4,"Tinder samurai" },
                {5,"Kali ma" },
                {6,"Oh my" },
                {7,"Mr Sandman" },
                {8,"Keš u krvi" }
            };
        UserChoice:;
            OptionsPrint();
            var userChoice = int.Parse(Console.ReadLine());
            switch (userChoice)
            {
                case 1:
                    {
                        PrintList(songs);
                        break;
                    }
                case 2:
                    {
                        PrintSong(songs);
                        break;
                    }
                case 3:
                    {
                        PrintOrdinalNumber(songs);
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
                        goto EndOfProgram;
                    }
                default:
                    break;
            }
            goto UserChoice;
        EndOfProgram:;
        }
    }
}
