using System;
using static System.Console;

namespace Softwaredesign_Abschlussaufgabe
{
    class NPC
    {
        public string Name;
        public Item Loot;
        public Item TradeItem;
        public int Health;
        public int Damage;
        public string Text;

        public NPC(string _Name, int _Health, int _Damage, string _Text, Item _Loot = null, Item _TradeItem = null)
        {
            this.Name = _Name;
            this.Loot = _Loot;
            this.TradeItem = _TradeItem;
            this.Health = _Health;
            this.Damage = _Damage;
            this.Text = _Text;
        }

        public void DisplayNPC()
        {
            ForegroundColor = ConsoleColor.White;
            if (this.Loot != null)
                WriteLine(this.Name + "(" + this.Health + "hp/ " + this.Damage + "dmg/ trades " + this.Loot.Name + " for " + this.TradeItem.Name + ")");
            else
                WriteLine(this.Name + "(" + this.Health + "hp/ " + this.Damage + "dmg)");
        }

        public void Trade(Player _Player)
        {
            if (this.Loot == null)
            {
                ForegroundColor = ConsoleColor.Red;
                WriteLine(this.Name + " has nothing to trade.");
                return;
            }

            if (this.TradeItem == null)
            {
                ForegroundColor = ConsoleColor.Red;
                WriteLine(this.Name + " does not want to trade with you.");
                return;
            }

            ForegroundColor = ConsoleColor.Cyan;
            WriteLine("What item do you want to offer " + this.Name + "?");
            ForegroundColor = ConsoleColor.White;
            Write(">");
            string inputItem = ReadLine();

            if (_Player.CheckInventory(inputItem))
            {
                if (this.TradeItem.Name == inputItem)
                {
                    _Player.Inventory.Add(this.Loot);
                    ForegroundColor = ConsoleColor.Green;
                    WriteLine(this.Name + " gave you a " + this.Loot.Name + ".");
                    this.Loot = null;
                    int i = 0;
                    foreach (Item item in _Player.Inventory)
                    {
                        if (item.Name == inputItem)
                        {
                            _Player.Inventory.RemoveAt(i);
                            return;
                        }
                        i++;
                    }
                }
                else
                {
                    ForegroundColor = ConsoleColor.Red;
                    WriteLine(this.Name + " has no interest in this item.");
                    return;
                }
            }
            else
            {
                ForegroundColor = ConsoleColor.Red;
                WriteLine("This item is not in your inventory.");
                return;
            }
        }

        public void Fight(TextAdventure _TA)
        {
            ForegroundColor = ConsoleColor.Cyan;
            WriteLine("Choose your weapon:");
            ForegroundColor = ConsoleColor.White;
            Write(">");
            string inputItem = ReadLine();

            if (_TA.Player.CheckInventory(inputItem))
            {
                Item weapon = null;

                foreach (Item item in _TA.Player.Inventory)
                {
                    if (item.Name == inputItem)
                        weapon = item;
                }

                this.Health -= weapon.Damage;
                _TA.Player.Health -= this.Damage;

                if (_TA.Player.Health <= 0)
                {
                    ForegroundColor = ConsoleColor.Red;
                    WriteLine("You died.");
                    _TA.GameOver = true;
                    return;
                }

                if (this.Health <= 0)
                {
                    ForegroundColor = ConsoleColor.Green;
                    WriteLine(this.Name + " died.");
                    WriteLine("Your Health: " + _TA.Player.Health + "hp");

                    if (this.Loot != null)
                    {
                        _TA.CurrentRoom.Items.Add(this.Loot);
                        WriteLine(this.Name + " dropped a " + this.Loot.Name + ".");
                    }
                    _TA.CurrentRoom.RemoveNPC(this);
                    return;
                }

                ForegroundColor = ConsoleColor.Green;
                WriteLine("Your Health: " + _TA.Player.Health + "hp");
                ForegroundColor = ConsoleColor.Red;
                WriteLine(this.Name + "'s Health: " + this.Health + "hp");

                return;
            }
            else
            {
                ForegroundColor = ConsoleColor.Red;
                WriteLine("This item is not in your inventory.");
                return;
            }
        }
    }
}