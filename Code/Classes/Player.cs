using System;
using System.Collections.Generic;
using static System.Console;

namespace Softwaredesign_Abschlussaufgabe
{
    class Player
    {
        public string GameStartText;
        public string GameEndText;
        public int Health;
        public List<Item> Inventory;

        public Player(string _GameStartText, string _GameEndText, int _Health, List<Item> _Inventory)
        {
            this.GameStartText = _GameStartText;
            this.GameEndText = _GameEndText;
            this.Health = _Health;
            this.Inventory = _Inventory;
        }

        public void DisplayInventory()
        {
            ForegroundColor = ConsoleColor.Cyan;
            if (this.Inventory.Count > 0)
            {
                WriteLine("These items are in your inventory:");
                foreach (Item i in this.Inventory)
                    i.DisplayItem();
            }
            else
            {
                WriteLine("Your inventory is empty.");
            }
            WriteLine("Your health is at " + this.Health + "hp.");
        }

        public bool CheckInventory(string _ItemName)
        {
            foreach (Item item in this.Inventory)
            {
                if (item.Name == _ItemName)
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
        }

        public void EatItem()
        {
            ForegroundColor = ConsoleColor.Cyan;
            WriteLine("Which item do you want to eat?");
            ForegroundColor = ConsoleColor.White;
            Write(">");
            string input = ReadLine();
            ForegroundColor = ConsoleColor.Cyan;

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
                        WriteLine("You shouldn't eat this item.");
                        return;
                    }
                }
                i++;
            }
            WriteLine("This item is not in your inventory.");
        }
    }
}