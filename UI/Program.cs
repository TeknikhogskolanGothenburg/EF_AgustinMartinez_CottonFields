using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Threading.Tasks;
using CottonFields.Data;
using CottonFields.Domain;
using static System.Console;


namespace UI
{
    class Program
    {
        private static CottonContext _toData;
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
                _toData = new CottonContext();
            }
            catch
            {
                WriteLine("·········Connection to the server cannot be established·········");
            }
        }

        static void Menu()
        {
            WriteLine("");
            Logo();
            WriteLine("\n\n                                   your vinyl database\n\n\n");
            WriteLine("     Press 'F1' for Log in or 'F2' and create a new account.");

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

        private static void Logo()
        {
            var arr = new[]
            {
                @"     ______               __      __                            ",
                @"    /      \             /  |    /  |                           ",
                @"   /$$$$$$  |  ______   _$$ |_  _$$ |_     ______   _______     ",
                @"   $$ |  $$/  /      \ / $$   |/ $$   |   /      \ /       \    ",
                @"   $$ |      /$$$$$$  |$$$$$$/ $$$$$$/   /$$$$$$  |$$$$$$$  |   ",
                @"   $$ |   __ $$ |  $$ |  $$ | __ $$ | __ $$ |  $$ |$$ |  $$ |   ",
                @"   $$ \__/  |$$ \__$$ |  $$ |/  |$$ |/  |$$ \__$$ |$$ |  $$ |   ",
                @"   $$    $$/ $$    $$/   $$  $$/ $$  $$/ $$    $$/ $$ |  $$ |   ",
                @"    $$$$$$/   $$$$$$/     $$$$/   $$$$/   $$$$$$/  $$/   $$/    ",
                @"                                                                ",
                @"          ________  __            __        __                  ",
                @"         /        |/  |          /  |      /  |                 ",
                @"         $$$$$$$$/ $$/   ______  $$ |  ____$$ |  _______        ",
                @"         $$ |__    /  | /      \ $$ | /    $$ | /       |       ",
                @"         $$    |   $$ |/$$$$$$  |$$ |/$$$$$$$ |/$$$$$$$/        ",
                @"         $$$$$/    $$ |$$    $$ |$$ |$$ |  $$ |$$      \        ",
                @"         $$ |      $$ |$$$$$$$$/ $$ |$$ \__$$ | $$$$$$  |       ",
                @"         $$ |      $$ |$$       |$$ |$$    $$ |/     $$/        ",
                @"         $$/       $$/  $$$$$$$/ $$/  $$$$$$$/ $$$$$$$/         ",
            };
            WindowWidth = 65;
            WriteLine("");
            foreach (string line in arr)
                WriteLine(line);
        }

        static void LogIn()
        {
            string email;
            string password;

            Clear();
            WriteLine("E-mail:");
            email = ReadLine();
            Clear();
            WriteLine("Password:");
            password = ReadLine();
            Clear();
            if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
            {
                CheckUser(email, password);
            }
            else
            {
                NewUser();
            }
        }

        static void CheckUser(string email, string password)
        {

            var o = (from p in _toData.Users where p.Email == email && p.Password == password select p).FirstOrDefault();
            if (o != null)
            {
                o.ID = userID;
                isLogged = true;
                StartPage();
            }
            else
            {
                Menu();
            }

        }

        private static void StartPage()
        {
            WriteLine("\n\n\n          · MAIN MENU ·");
            WriteLine("\n\n     'F1' List your personal collection\n" +
                "\n     'F2' Submit a release from your collection\n" +
                "\n     'F3' Add a release to your collection\n" +
                "\n     'F4' Exit");

            switch (ReadKey().Key)
            {
                /*case ConsoleKey.F1:
                    Collection();
                    break;
                case ConsoleKey.F2:
                    SubmitRelease();
                    break;
                case ConsoleKey.F3:
                    AddRelease();
                    break;
                case ConsoleKey.F4:
                    Exit();
                    break;*/
            }
        }

        private static void Exit()
        {
            Exit();
        }

        private static void CreatePass()
        {
            WriteLine("\nPassword:");
        }

        private static void NewUser()
        {
            User user = new User();
            user.Name = "name";
            user.Email = "email";
            user.Phone = 1234;
            user.Birthday = System.DateTime.Now;
            user.Nationality = "nationality";
            _toData.Users.Add(user);
            _toData.SaveChanges();
        }
    }
}
//var DatabaseObjct = (from m in toData.Labels select m.Name).ToList();


//WriteLine("\n\n\n          · CREATE A NEW ACCOUNT ·\n\n");

//WriteLine("Name:");

//WriteLine("\nE-mail:");

//WriteLine("\nPhone:");

//WriteLine("\nBirthday:");

//WriteLine("\nNationality:");

//CreatePass();