using System;
using System.Collections.Generic;
using static System.Console;

namespace Softwaredesign_Abschlussaufgabe
{
    class Room
    {
        public string Name;
        public string Description;

        public Door NorthDoor;
        public Door EastDoor;
        public Door SouthDoor;
        public Door WestDoor;

        public List<Item> Items;
        public List<NPC> NPCs;

        public Room(string _Name, string _Description, Door _NorthDoor, Door _EastDoor, Door _SouthDoor, Door _WestDoor, List<Item> _Items, List<NPC> _NPCs)
        {
            this.Name = _Name;
            this.Description = _Description;

            this.NorthDoor = _NorthDoor;
            this.EastDoor = _EastDoor;
            this.SouthDoor = _SouthDoor;
            this.WestDoor = _WestDoor;

            this.Items = _Items;
            this.NPCs = _NPCs;
        }

        public void DisplayRoom()
        {
            ForegroundColor = ConsoleColor.Magenta;
            WriteLine(this.Description);

            ForegroundColor = ConsoleColor.Cyan;
            if (this.Items.Count > 0)
            {
                WriteLine("These items are in the " + this.Name + ":");
                foreach (Item i in this.Items)
                    i.DisplayItem();
            }

            if (this.NPCs.Count > 0)
            {
                WriteLine("These characters are in the " + this.Name + ":");
                foreach (NPC n in this.NPCs)
                    n.DisplayNPC();
            }
        }

        public void RemoveNPC(NPC _NPC)
        {
            int i = 0;
            foreach (NPC npc in this.NPCs)
            {
                if (npc.Name == _NPC.Name)
                {
                    NPCs.RemoveAt(i);
                    return;
                }
                i++;
            }
        }

        public void TalkToNPC()
        {
            ForegroundColor = ConsoleColor.Cyan;
            WriteLine("Who do you want to talk to?");
            ForegroundColor = ConsoleColor.White;
            Write(">");
            string input = ReadLine();

            foreach (NPC npc in this.NPCs)
            {
                if (input == npc.Name)
                {
                    ForegroundColor = ConsoleColor.Magenta;
                    WriteLine(npc.Text);
                    return;
                }
            }
            ForegroundColor = ConsoleColor.Red;
            WriteLine(input + " is not here.");
        }

        public void TradeWithNPC(Player _Player)
        {
            ForegroundColor = ConsoleColor.Cyan;
            WriteLine("Who do you want to trade with?");
            ForegroundColor = ConsoleColor.White;
            Write(">");
            string inputNPC = ReadLine();

            ForegroundColor = ConsoleColor.Cyan;
            foreach (NPC npc in this.NPCs)
            {
                if (inputNPC == npc.Name)
                {
                    npc.Trade(_Player);
                    return;
                }
            }
            ForegroundColor = ConsoleColor.Red;
            WriteLine(inputNPC + " is not here.");
        }

        public void FightNPC(TextAdventure _TA)
        {
            ForegroundColor = ConsoleColor.Cyan;
            WriteLine("Who do you want to fight?");
            ForegroundColor = ConsoleColor.White;
            Write(">");
            string inputNPC = ReadLine();

            foreach (NPC npc in _TA.CurrentRoom.NPCs)
            {
                if (inputNPC == npc.Name)
                {
                    npc.Fight(_TA);
                    return;
                }
            }
            ForegroundColor = ConsoleColor.Red;
            WriteLine(inputNPC + " is not here.");
        }
    }
}