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

        public void RoomDescription()
        {
            ForegroundColor = ConsoleColor.Magenta;
            WriteLine(this.Description);
            ForegroundColor = ConsoleColor.White;

            if (this.Items.Count > 0)
            {
                ForegroundColor = ConsoleColor.Cyan;
                WriteLine("These items are in the " + this.Name + ":");
                ForegroundColor = ConsoleColor.White;

                foreach (Item i in this.Items)
                    i.DisplayItem();
            }

            if (this.NPCs.Count > 0)
            {
                ForegroundColor = ConsoleColor.Cyan;
                WriteLine("These characters are in the " + this.Name + ":");
                ForegroundColor = ConsoleColor.White;

                foreach (NPC n in this.NPCs)
                    n.DisplayNPC();
            }
        }
    }
}