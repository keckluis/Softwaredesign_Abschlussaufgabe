using System;
using System.Collections.Generic;
using static System.Console;
using System.IO;
using Newtonsoft.Json;

namespace Softwaredesign_Abschlussaufgabe
{
    class TextAdventure
    {
        private static List<Room> Rooms;
        private static Room CurrentRoom;
        private static Player Player;

        public static bool GameOver = false;

        private static void Main(string[] args)
        {
            LoadGame();
        }

        private static void LoadGame()
        {
            Rooms = new List<Room>();

            using (StreamReader r = new StreamReader("../Softwaredesign_Abschlussaufgabe/Code/GameBuilder/Rooms.json"))
            {
                string json = r.ReadToEnd();
                Rooms = JsonConvert.DeserializeObject<List<Room>>(json);
            }

            CurrentRoom = Rooms[0];

            using (StreamReader r = new StreamReader("../Softwaredesign_Abschlussaufgabe/Code/GameBuilder/Player.json"))
            {
                string json = r.ReadToEnd();
                Player = JsonConvert.DeserializeObject<Player>(json);
            }

            ForegroundColor = ConsoleColor.Magenta;
            WriteLine(Player.GameStartText);

            DisplayCommands();

            CurrentRoom.RoomDescription();

            PlayGame();
        }

        private static void PlayGame()
        {
            if (!GameOver)
            {
                ForegroundColor = ConsoleColor.Cyan;
                WriteLine("What do you want to do?");
                ForegroundColor = ConsoleColor.White;
                Write(">");

                string input = ReadLine();
                input = input.ToLower();

                switch (input)
                {
                    case "commands":
                    case "c":
                        DisplayCommands();
                        break;
                    case "north":
                    case "n":
                        TryToGoThroughDoor(CurrentRoom.NorthDoor);
                        break;
                    case "east":
                    case "e":
                        TryToGoThroughDoor(CurrentRoom.EastDoor);
                        break;
                    case "south":
                    case "s":
                        TryToGoThroughDoor(CurrentRoom.SouthDoor);
                        break;
                    case "west":
                    case "w":
                        TryToGoThroughDoor(CurrentRoom.WestDoor);
                        break;
                    case "look":
                    case "l":
                        CurrentRoom.RoomDescription();
                        break;
                    case "take item":
                    case "ti":
                        Player.TakeItem(CurrentRoom);
                        break;
                    case "drop item":
                    case "di":
                        Player.DropItem(CurrentRoom);
                        break;
                    case "inventory":
                    case "i":
                        Player.DisplayInventory();
                        break;
                    case "eat item":
                    case "ei":
                        Player.EatItem();
                        break;
                    case "attack":
                    case "a":
                        break;
                    case "talk":
                    case "tlk":
                        break;
                    case "trade":
                    case "trd":
                        break;
                    case "quit":
                    case "q":
                        GameOver = true;
                        break;
                    default:
                        WriteLine("Invalid command. Please try again.");
                        break;
                }
                PlayGame();
            }
            else
            {
                ForegroundColor = ConsoleColor.DarkRed;
                WriteLine("Game end.");
                ForegroundColor = ConsoleColor.White;
            }
        }

        private static void TryToGoThroughDoor(Door _Door)
        {
            if (_Door.isOpen)
            {
                GoThroughDoor(_Door);
            }
            else
            {
                ForegroundColor = ConsoleColor.Magenta;
                WriteLine(_Door.LockedText);
                if (_Door.OpenedBy != null)
                {
                    ForegroundColor = ConsoleColor.Cyan;
                    WriteLine("Choose the item you want to open the door with (it will be removed from your inventory):");
                    ForegroundColor = ConsoleColor.White;
                    Write(">");
                    string input = ReadLine();

                    if (input == _Door.OpenedBy.Name)
                    {
                        if (Player.CheckInventory(_Door.OpenedBy))
                        {
                            Player.RemoveFromInventory(_Door.OpenedBy);
                            _Door.isOpen = true;
                            GoThroughDoor(_Door);
                        }
                        else
                        {
                            ForegroundColor = ConsoleColor.Cyan;
                            WriteLine("This item is not in your inventory.");
                            ForegroundColor = ConsoleColor.White;
                        }
                    }
                    else
                    {
                        ForegroundColor = ConsoleColor.Cyan;
                        WriteLine("This item doesn't open the door.");
                        ForegroundColor = ConsoleColor.White;
                    }
                }
            }
        }

        private static void GoThroughDoor(Door _Door)
        {
            foreach (Room r in Rooms)
            {
                if (_Door.LeadsTo == r.Name)
                {
                    CurrentRoom = r;
                    CurrentRoom.RoomDescription();
                }
            }
        }

        private static void DisplayCommands()
        {
            ForegroundColor = ConsoleColor.Cyan;
            WriteLine("These are all possible commands:");
            ForegroundColor = ConsoleColor.White;
            WriteLine("commands(c), north(n), east(e), south(s), west(w), look(l), take item(ti), drop item(di), inventory(i), eat item (ei), attack(a), talk(tlk), trade(trd), quit(q)");
        }
    }
}