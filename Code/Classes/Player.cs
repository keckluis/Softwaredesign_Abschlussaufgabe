using System;
using System.Collections.Generic;
using static System.Console;

namespace Softwaredesign_Abschlussaufgabe
{
    class Player
    {
        public string GameStartText;
        public int Health;
        public List<Item> Inventory;

        public Player(string _GameStartText, int _Health, List<Item> _Inventory)
        {
            this.GameStartText = _GameStartText;
            this.Health = _Health;
            this.Inventory = _Inventory;
        }

        public void DisplayInventory()
        {
            if (this.Inventory.Count > 0)
            {
                ForegroundColor = ConsoleColor.Cyan;
                WriteLine("These items are in your inventory:");
                ForegroundColor = ConsoleColor.White;
                foreach (Item i in this.Inventory)
                    i.DisplayItem();
            }
            else
            {
                ForegroundColor = ConsoleColor.Cyan;
                WriteLine("Your inventory is empty.");
                ForegroundColor = ConsoleColor.White;
            }

            ForegroundColor = ConsoleColor.Cyan;
            WriteLine("Your health is at " + this.Health + "hp.");
            ForegroundColor = ConsoleColor.White;
        }

        public bool CheckInventory(Item _Item)
        {
            foreach (Item item in this.Inventory)
            {
                if (item.Name == _Item.Name)
                    return true;
            }
            return false;
        }

        public void RemoveFromInventory(Item _Item)
        {
            int i = 0;
            foreach (Item item in this.Inventory)
            {
                if (item.Name == _Item.Name)
                    break;
                i++;
            }

            this.Inventory.RemoveAt(i);
        }

        public void DropItem(Room _Room)
        {
            ForegroundColor = ConsoleColor.Cyan;
            WriteLine("Which item do you want to drop?");
            ForegroundColor = ConsoleColor.White;
            Write(">");
            string input = ReadLine();

            int i = 0;
            foreach (Item item in this.Inventory)
            {
                if (item.Name == input)
                {
                    _Room.Items.Add(item);
                    this.Inventory.RemoveAt(i);
                    return;
                }
                i++;
            }

            ForegroundColor = ConsoleColor.Cyan;
            WriteLine("You don't have this item in your inventory.");
            ForegroundColor = ConsoleColor.White;
        }

        public void TakeItem(Room _Room)
        {
            ForegroundColor = ConsoleColor.Cyan;
            WriteLine("Which item do you want to take?");
            ForegroundColor = ConsoleColor.White;
            Write(">");
            string input = ReadLine();

            int i = 0;
            foreach (Item item in _Room.Items)
            {
                if (item.Name == input)
                {
                    this.Inventory.Add(item);
                    _Room.Items.RemoveAt(i);
                    return;
                }
                i++;
            }

            ForegroundColor = ConsoleColor.Cyan;
            WriteLine("This item is not in this room.");
            ForegroundColor = ConsoleColor.White;
        }

        public void EatItem()
        {
            ForegroundColor = ConsoleColor.Cyan;
            WriteLine("Which item do you want to eat?");
            ForegroundColor = ConsoleColor.White;
            Write(">");
            string input = ReadLine();

            int i = 0;
            foreach (Item item in this.Inventory)
            {
                if (item.Name == input)
                {
                    if (item.HealthRegeneration > 0)
                    {
                        this.Health += item.HealthRegeneration;
                        this.Inventory.RemoveAt(i);
                        return;
                    }
                    else
                    {
                        ForegroundColor = ConsoleColor.Cyan;
                        WriteLine("You shouldn't eat this item.");
                        ForegroundColor = ConsoleColor.White;
                        return;
                    }
                }
                i++;
            }

            ForegroundColor = ConsoleColor.Cyan;
            WriteLine("This item is not in your inventory.");
            ForegroundColor = ConsoleColor.White;
        }

        public void FightNPC(NPC _NPC)
        {

        }
    }
}