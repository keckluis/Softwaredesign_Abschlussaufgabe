using System;
using System.Collections.Generic;
using static System.Console;
using System.IO;
using Newtonsoft.Json;

namespace Softwaredesign_Abschlussaufgabe
{
    class GameLoader
    {
        private static void Main(string[] args)
        {
            LoadGame();
        }

        private static void LoadGame()
        {
            TextAdventure TA;
            ForegroundColor = ConsoleColor.White;
            WriteLine("Type a number to choose your start settings:");
            WriteLine("1. New Game");
            WriteLine("2. Load Game");
            WriteLine("3. Quit");
            Write(">");
            string input = ReadLine();

            if (input == "1")
            {
                List<Room> rooms = new List<Room>();
                using (StreamReader r = new StreamReader(@"../Softwaredesign_Abschlussaufgabe/Code/GameBuilder/Rooms.json"))
                {
                    string json = r.ReadToEnd();
                    rooms = JsonConvert.DeserializeObject<List<Room>>(json);
                }

                Room currentRoom = rooms[0];

                Player player;
                using (StreamReader r = new StreamReader(@"../Softwaredesign_Abschlussaufgabe/Code/GameBuilder/Player.json"))
                {
                    string json = r.ReadToEnd();
                    player = JsonConvert.DeserializeObject<Player>(json);
                }

                TA = new TextAdventure(rooms, currentRoom, player);
                StartGame(TA);
            }
            else if (input == "2")
            {
                WriteLine("Whats the name of your save file? (Don't add the path or file type)");
                Write(">");
                string inputFile = ReadLine();

                try
                {
                    using (StreamReader r = new StreamReader(@"../Softwaredesign_Abschlussaufgabe/Code/SaveFiles/" + inputFile + ".json"))
                    {
                        string json = r.ReadToEnd();
                        TA = JsonConvert.DeserializeObject<TextAdventure>(json);
                    }
                    StartGame(TA);
                }
                catch (Exception e)
                {
                    WriteLine(e.Message);
                    ForegroundColor = ConsoleColor.Red;
                    WriteLine("Failed to load save file. Did you type the name correctly?");
                    ForegroundColor = ConsoleColor.White;
                    LoadGame();
                }
            }
            else if (input == "3")
            {
                return;
            }
            else
            {
                ForegroundColor = ConsoleColor.Red;
                WriteLine("Invalid input. Please try again.");
                LoadGame();
            }
        }

        private static void StartGame(TextAdventure _TA)
        {
            _TA.DisplayCommands();
            ForegroundColor = ConsoleColor.Magenta;
            WriteLine(_TA.Player.GameStartText);
            _TA.CurrentRoom.DisplayRoom();
            _TA.PlayGame();
        }
    }
}