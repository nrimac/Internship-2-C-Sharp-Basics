using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        public static bool Confirm()
        {
        FalseInput:;
            Console.WriteLine("Jeste li sigurni da želite nastaviti? y/n");
            var confirm = Console.ReadLine();
            switch (confirm)
            {
                case "y":
                    {
                        return true;
                    }
                case "n":
                    {
                        return false;
                    }
                default:
                    {
                        Console.WriteLine("Krivi unos!");
                        goto FalseInput;
                    }
            }
        }
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
            Console.WriteLine("10 - Shuffle songs");
            Console.WriteLine("0 - Izlaz iz aplikacije");
            Console.WriteLine();
        }
        public static void PrintList(Dictionary<int,string> songs)
        {
            if (songs.Count > 0)
            {
                var songToList = (0, "");
                Console.WriteLine("Lista pjesama:");
                for (int i = 1; i <= songs.Count; i++)
                {
                    foreach (var song in songs)
                    {
                        if(song.Key==i)
                        {
                            songToList.Item1 = song.Key;
                            songToList.Item2 = song.Value;
                        }
                    }
                    Console.WriteLine("{0}. - {1}",songToList.Item1,songToList.Item2);
                }
            }
            else
            {
                Console.WriteLine("Lista je prazna.");
            }
            Console.WriteLine();
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
            Console.WriteLine();
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
            Console.WriteLine();
        }
        public static void SongInput(Dictionary<int, string> songs)
        {
            if(Confirm()==false)
               goto EndFunction;
            
            Console.WriteLine("Unesite ime nove pjesme:");
            var newSongName = Console.ReadLine();
            foreach (var song in songs)
            {
                if(newSongName==song.Value)
                {
                    Console.WriteLine("Pjesma već postoji na listi.");
                    goto EndFunction;
                }
            }
            songs.Add(songs.Count + 1, newSongName);
            Console.WriteLine("Pjesma dodana!");
        EndFunction:;
            Console.WriteLine();
        }
        public static void DeleteSongByOrdinalNumber(Dictionary<int, string> songs)
        {
            if (Confirm() == false)
                goto EndFunction;
            Console.WriteLine("Unesite redni broj pjesme koju želite izbrisati:");
            var songToDeleteIndex = int.Parse(Console.ReadLine());
            if(songToDeleteIndex>songs.Count)
            {
                Console.WriteLine("Ne postoji uneseni index!");
                goto EndFunction;
            }
            for (int i = songToDeleteIndex; i < songs.Count; i++)
            {
                songs[i] = (songs[i + 1]);
            }
            songs.Remove(songs.Count);
            Console.WriteLine("Pjesma je izbrisana.");
        EndFunction:;
            Console.WriteLine();
        }
        public static void DeleteSongByName(Dictionary<int, string> songs)
        {
            if (Confirm() == false)
                goto EndFunction;
            Console.WriteLine("Unesite ime pjesme koju želite izbrisati:");
            var songToDeleteName = Console.ReadLine();
            var songToDeleteIndex=1;
            var t = false;
            foreach (var song in songs)
            {
                if (song.Value == songToDeleteName)
                    t = true;
            }
            if(t==false)
            {
                Console.WriteLine("Unesena pjesma nije na listi.");
                goto EndFunction;
            }
            foreach (var song in songs)
            {
                if (song.Value == songToDeleteName)
                    songToDeleteIndex = song.Key;
            }
            for (int i = songToDeleteIndex; i < songs.Count; i++)
            {
                songs[i] = (songs[i + 1]);
            }
            songs.Remove(songs.Count);
            Console.WriteLine("Pjesma izbrisana!");
        EndFunction:;
            Console.WriteLine();
        }
        public static void DeleteSongList(Dictionary<int, string> songs)
        {
            if (Confirm() == false)
                goto EndFunction;
            songs.Clear();
            Console.WriteLine("Lista izbrisana!");
        EndFunction:;
            Console.WriteLine();
        }
        public static void EditSongName(Dictionary<int, string> songs)
        {
            if (Confirm() == false)
                goto EndFunction;
            Console.WriteLine("Upišite redni broj pjesme kojoj želite promijeniti ime:");
            var changeSongNameIndex = int.Parse(Console.ReadLine());
            Console.WriteLine("Unesite novo ime pjesme:");
            songs[changeSongNameIndex] = (Console.ReadLine());
        EndFunction:;
            Console.WriteLine();
        }
        public static void EditSongIndex(Dictionary<int, string> songs)
        {
            if (Confirm() == false)
                goto EndFunction;
            Console.WriteLine("Upišite redni broj pjesme kojoj želite promijeniti redni broj:");
            var oldSongIndex = int.Parse(Console.ReadLine());
            if (oldSongIndex > songs.Count)
            {
                Console.WriteLine("Ne postoji uneseni index!");
                goto EndFunction;
            }
            Console.WriteLine("Upišite novi redni broj pjesme:");
            var newSongIndex = int.Parse(Console.ReadLine());
            if (newSongIndex > songs.Count)
            {
                Console.WriteLine("Ne postoji uneseni index!");
                goto EndFunction;
            }
            var nameOfChangingSong = songs[oldSongIndex];
            if (oldSongIndex - newSongIndex > 0)
            {
                //A -B C D E -F G
                for (int i = oldSongIndex; i >= newSongIndex; i--)
                {
                    if(i>newSongIndex)
                    {
                        songs[i] = songs[i - 1];
                    }
                    else
                    {
                        songs[i] = nameOfChangingSong;
                    }
                }
            }
            else
            {
                //A -B C D E -F G
                for (int i = oldSongIndex; i <= newSongIndex; i++)
                {
                    if(i<newSongIndex)
                    {
                        songs[i] = songs[i + 1];
                    }
                    else
                    {
                        songs[i] = nameOfChangingSong;
                    }
                }
            }
            Console.WriteLine("Uspješna promjena!");
        EndFunction:;
            Console.WriteLine();
        }
        public static void Shuffler(Dictionary<int,string> songs)
        {
            if (Confirm() == false)
                goto EndFunction;
            var randomInt = new Random();
            
            for (int i = 1; i <= songs.Count; i++)
            {
                var a = randomInt.Next(1, songs.Count + 1);
                var switchSong = songs[i];
                songs[i] = songs[a];
                songs[a] = switchSong;
            }
            Console.WriteLine("Pjesme izmješane!");
            Console.WriteLine();
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
                        SongInput(songs);
                        break;
                    }
                case 5:
                    {
                        DeleteSongByOrdinalNumber(songs);
                        break;
                    }
                case 6:
                    {
                        DeleteSongByName(songs);
                        break;
                    }
                case 7:
                    {
                        DeleteSongList(songs);
                        break;
                    }
                case 8:
                    {
                        EditSongName(songs);
                        break;
                    }
                case 9:
                    {
                        EditSongIndex(songs);
                        break;
                    }
                case 10:
                    {
                        Shuffler(songs);
                        break;
                    }
                case 0:
                    {
                        goto EndOfProgram;
                    }
                default:
                    {
                        Console.WriteLine("Krivi unos!");
                        goto UserChoice;
                    }
            }
            goto UserChoice;
        EndOfProgram:;
        }
    }
}
