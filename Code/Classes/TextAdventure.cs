using System;
using System.Collections.Generic;
using static System.Console;
using System.IO;
using Newtonsoft.Json;

namespace Softwaredesign_Abschlussaufgabe
{
    class TextAdventure
    {
        public List<Room> Rooms;
        public Room CurrentRoom;
        public Player Player;

        public bool GameOver;

        public TextAdventure(List<Room> _Rooms, Room _CurrentRoom, Player _Player)
        {
            this.Rooms = _Rooms;
            this.CurrentRoom = _CurrentRoom;
            this.Player = _Player;
            this.GameOver = false;
        }

        public void PlayGame()
        {
            if (!this.GameOver)
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
                        this.DisplayCommands();
                        break;
                    case "north":
                    case "n":
                        this.CurrentRoom.NorthDoor.TryToGoThrough(this);
                        break;
                    case "east":
                    case "e":
                        this.CurrentRoom.EastDoor.TryToGoThrough(this);
                        break;
                    case "south":
                    case "s":
                        this.CurrentRoom.SouthDoor.TryToGoThrough(this);
                        break;
                    case "west":
                    case "w":
                        this.CurrentRoom.WestDoor.TryToGoThrough(this);
                        break;
                    case "look":
                    case "l":
                        this.CurrentRoom.DisplayRoom();
                        break;
                    case "take item":
                    case "ti":
                        this.Player.TakeItem(this.CurrentRoom);
                        break;
                    case "drop item":
                    case "di":
                        this.Player.DropItem(this.CurrentRoom);
                        break;
                    case "inventory":
                    case "i":
                        this.Player.DisplayInventory();
                        break;
                    case "eat item":
                    case "ei":
                        this.Player.EatItem();
                        break;
                    case "attack":
                    case "a":
                        this.CurrentRoom.FightNPC(this);
                        break;
                    case "talk":
                    case "tlk":
                        this.CurrentRoom.TalkToNPC();
                        break;
                    case "trade":
                    case "trd":
                        this.CurrentRoom.TradeWithNPC(this.Player);
                        break;
                    case "save game":
                    case "sv":
                        this.SaveGame();
                        break;
                    case "quit":
                    case "q":
                        this.GameOver = true;
                        break;
                    default:
                        ForegroundColor = ConsoleColor.DarkRed;
                        WriteLine("Invalid command. Please try again.");
                        break;
                }
                this.PlayGame();
            }
            else
            {
                ForegroundColor = ConsoleColor.DarkRed;
                WriteLine("Game end.");
                ForegroundColor = ConsoleColor.White;
            }
        }

        public void DisplayCommands()
        {
            ForegroundColor = ConsoleColor.Cyan;
            WriteLine("These are all possible commands:");
            ForegroundColor = ConsoleColor.White;
            WriteLine("commands(c), north(n), east(e), south(s), west(w), look(l), take item(ti), drop item(di), inventory(i), eat item(ei), attack(a), talk(tlk), trade(trd), quit(q)");
        }

        private void SaveGame()
        {
            ForegroundColor = ConsoleColor.Green;
            WriteLine("Enter name you want for this save file. You'll need it to load this save later.");
            ForegroundColor = ConsoleColor.White;
            Write(">");
            string input = ReadLine();

            if (input != "")
            {
                this.Player.GameStartText = "";
                using (StreamWriter file = File.CreateText(@"../Softwaredesign_Abschlussaufgabe/Code/SaveFiles/" + input + ".json"))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(file, this);
                }
                ForegroundColor = ConsoleColor.Green;
                WriteLine("Game saved.");
            }
            else
            {
                ForegroundColor = ConsoleColor.Red;
                WriteLine("Please enter a name for your save file");
                this.SaveGame();
            }
        }
    }
}