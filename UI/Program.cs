using System;
using System.IO;
using System.Linq;
using CottonFields.Data;
using CottonFields.Domain;
using static System.Console;
using System.Threading;

namespace UI
{
    class Program
    {
        private static CottonContext _database;
        public static bool isLogged = false;
        public static int userID;

        static void Main(string[] args)
        {
            Conection();
            Sound();
            Menu();
        }

        private static void Sound()
        {
            string soundFile = @"C:\Users\agust\source\repos\CottonFields\CottonFields.Data\Mixdown.wav";
            byte[] file = File.ReadAllBytes(soundFile);
            var sound = new System.Media.SoundPlayer(soundFile);
            sound.Play();
        }

        private static void Conection()
        {
            try
            {
                _database = new CottonContext();
            }
            catch
            {
                WriteLine("\n··········· Connection to the server cannot be established ···········");
            }
        }

        static void Menu()
        {
            WriteLine("");
            Logo();
            WriteLine("\n\n\t\t\t\t   your vinyl database\n\n\n");
            WriteLine("      Press 'F1' for Log in or 'F2' and create a new account.");

            switch (ReadKey().Key)
            {
                case ConsoleKey.F1:
                    LogIn();
                    break;
                case ConsoleKey.F2:
                    NewUser();
                    break;
            }
        }

        static void LogIn()
        {
            string email;
            string password;

            Clear();
            WriteLine("\n\n\n\t\t\t  ··· LOGIN ···\n\n");
            WriteLine("E-mail:");
            email = ReadLine();
            WriteLine("\nPassword:");
            password = ReadLine();
            Clear();
            if (!string.IsNullOrEmpty(email) || !string.IsNullOrEmpty(password) || !string.IsNullOrWhiteSpace(email) || !string.IsNullOrWhiteSpace(password))
            {
                CheckUser(email, password);
            }
            else
            {
                WriteLine("\n·You either don't have a Cotton Fields account or you type wrong data·\n\n\tCreate a new account? Y/N");

                switch (ReadKey().Key)
                {
                    case ConsoleKey.Y:
                        NewUser();
                        break;
                    case ConsoleKey.N:
                        Clear();
                        Menu();
                        break;
                }
            }
        }

        private static void NewUser()
        {
            Clear();
            User user = new User();
            WriteLine("\n\n\n\t\t   ··· CREATE A NEW ACCOUNT ···\n\n");
            WriteLine("Name:");
            user.Name = ReadLine();
            WriteLine("\nE-mail:");
            user.Email = ReadLine();
            WriteLine("\nCountry:");
            user.Country = ReadLine();
            WriteLine("\nPassword:");
            user.Password = ReadLine();
            _database.Add(user);
            _database.SaveChanges();
            Clear();
            WriteLine("\n········· Your account create successful! You can log in now ·········");
            Menu();
        }

        static void CheckUser(string email, string password)
        {

            var o = (from p in _database.Users where p.Email == email && p.Password == password select p).FirstOrDefault();
            if (o != null)
            {
                o.ID = userID;
                isLogged = true;
                StartPage();
            }
            else
            {
                WriteLine("\n·You either don't have a Cotton Fields account or you type wrong data·\n\n\tCreate a new account? Y/N");

                switch (ReadKey().Key)
                {
                    case ConsoleKey.Y:
                        NewUser();
                        break;
                    case ConsoleKey.N:
                        Clear();
                        Menu();
                        break;
                }
            }
        }

        private static void Logo()
        {
            var arr = new[]
            {
                @"       ______               __      __                              ",
                @"      /      \             /  |    /  |                             ",
                @"     /$$$$$$  |  ______   _$$ |_  _$$ |_     ______   _______       ",
                @"     $$ |  $$/  /      \ / $$   |/ $$   |   /      \ /       \      ",
                @"     $$ |      /$$$$$$  |$$$$$$/ $$$$$$/   /$$$$$$  |$$$$$$$  |     ",
                @"     $$ |   __ $$ |  $$ |  $$ | __ $$ | __ $$ |  $$ |$$ |  $$ |     ",
                @"     $$ \__/  |$$ \__$$ |  $$ |/  |$$ |/  |$$ \__$$ |$$ |  $$ |     ",
                @"     $$    $$/ $$    $$/   $$  $$/ $$  $$/ $$    $$/ $$ |  $$ |     ",
                @"      $$$$$$/   $$$$$$/     $$$$/   $$$$/   $$$$$$/  $$/   $$/      ",
                @"                                                                    ",
                @"            ________  __            __        __                    ",
                @"           /        |/  |          /  |      /  |                   ",
                @"           $$$$$$$$/ $$/   ______  $$ |  ____$$ |  _______          ",
                @"           $$ |__    /  | /      \ $$ | /    $$ | /       |         ",
                @"           $$    |   $$ |/$$$$$$  |$$ |/$$$$$$$ |/$$$$$$$/          ",
                @"           $$$$$/    $$ |$$    $$ |$$ |$$ |  $$ |$$      \          ",
                @"           $$ |      $$ |$$$$$$$$/ $$ |$$ \__$$ | $$$$$$  |         ",
                @"           $$ |      $$ |$$       |$$ |$$    $$ |/     $$/          ",
                @"           $$/       $$/  $$$$$$$/ $$/  $$$$$$$/ $$$$$$$/           ",
            };
            WindowWidth = 70;
            WriteLine("");
            foreach (string line in arr)
                WriteLine(line);
        }

        private static void StartPage()
        {
            Clear();
            WriteLine("\n\n\n\t\t\t  ··· MAIN MENU ···\n\n");
            WriteLine("\n\n\t'F1' List your personal collection\n" +
                "\n\t'F2' Submit a release from your collection\n" +
                "\n\t'F3' Add a release to your collection\n" +
                "\n\t'F4' Remove a release from your collection\n" +
                "\n\t'ESC' Quit to Windows\n");

            switch (ReadKey().Key)
            {
                case ConsoleKey.F1:
                    GetCollection();
                    break;
                case ConsoleKey.F2:
                    SubmitRelease();
                    break;
                case ConsoleKey.F3:
                    AddRelease();
                    break;
                case ConsoleKey.F4:
                    RemoveRelease();
                    break;
                case ConsoleKey.F5:
                    Environment.Exit(-1);                    
                    break;
            }
        }

        private static void GetCollection()
        {
            Clear();
            WriteLine("\n\n\n\t\t  ··· Your collection ···\n\n");

            foreach (var release in _database.Releases)
            {
                WriteLine("\t" + release.ID + ": " + release.Title + "\n\t   " + release.ReleaseDate + "\n");
            }
            WriteLine("\n\nPlease press F2 to go back.");
            switch (ReadKey().Key)
            {
                case ConsoleKey.F2:
                    Clear();
                    StartPage();
                    break;
            }
        }

        private static void SubmitRelease()
        {
            Clear();
            WriteLine("\n\n\n\t  ··· Submit a release from your collection ···\n\n");
            WriteLine("\nWhich one are you looking for?\n");
            try
            {
                string title = ReadLine();
                var movie = _database.Releases.FirstOrDefault(m => m.Title.StartsWith(title));
                WriteLine(movie.Title);
                WriteLine("\n\nPlease press F2 to go back.");
                switch (ReadKey().Key)
                {
                    case ConsoleKey.F2:
                        Clear();
                        StartPage();
                        break;
                }
            }
            catch (NullReferenceException)
            {

                WriteLine("You don't have the album in your collection.");
                Thread.Sleep(3000);
                StartPage();
            }
        }

        private static void AddRelease()
        {
            Clear();
            WriteLine("\n\n\n\t  ··· Add a release to your collection ···\n\n");

            Artist artist = new Artist();
            WriteLine("\nArtist:");
            artist.Name = ReadLine();
            Release release = new Release();
            WriteLine("\nTitle:");
            release.Title = ReadLine();
            release.ReleaseDate = DateTime.Now;
            MatrixNumber matrixnumber = new MatrixNumber();
            WriteLine("\nMatrixNumber:");
            matrixnumber.Number = ReadLine();

            _database.Artists.Add(artist);
            _database.Releases.Add(release);
            _database.MatrixNumber.Add(matrixnumber);
            _database.SaveChanges();

            StartPage();
        }

        private static void RemoveRelease()
        {
            Clear();
            WriteLine("\tWhich vinyl you want to remove from your collection?");
            foreach (var release in _database.Releases)
            {
                WriteLine("\t" + release.ID + ": " + release.Title + "\n\t   " + release.ReleaseDate + "\n");
            }
            WriteLine("\nPlease write the number of the vinyl you want to erase \nand press enter.");
            int number = int.Parse(ReadLine());
            var releasetoremove = _database.Releases.Find(number);
            _database.Releases.Remove(releasetoremove);
            _database.SaveChanges();
            GetCollection();
        }
    }
}