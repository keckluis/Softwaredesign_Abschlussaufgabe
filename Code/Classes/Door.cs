using System;
using static System.Console;

namespace Softwaredesign_Abschlussaufgabe
{
    class Door
    {
        public bool isOpen;
        public string LeadsTo;
        public Item OpenedBy;
        public string LockedText;

        public Door(bool _isOpen, string _LeadsTo, string _LockedText, Item _OpenedBy = null)
        {
            this.isOpen = _isOpen;
            this.LeadsTo = _LeadsTo;
            this.OpenedBy = _OpenedBy;
            this.LockedText = _LockedText;
        }

        public void TryToGoThrough(TextAdventure _TA)
        {
            if (this.isOpen)
            {
                this.GoThrough(_TA);
            }
            else
            {
                ForegroundColor = ConsoleColor.Magenta;
                WriteLine(this.LockedText);
                if (this.OpenedBy != null)
                {
                    ForegroundColor = ConsoleColor.Cyan;
                    WriteLine("Choose the item you want to open the door with (it will be removed from your inventory):");
                    ForegroundColor = ConsoleColor.White;
                    Write(">");
                    string input = ReadLine();

                    if (input == this.OpenedBy.Name)
                    {
                        if (_TA.Player.CheckInventory(this.OpenedBy.Name))
                        {
                            _TA.Player.RemoveFromInventory(this.OpenedBy);
                            this.isOpen = true;
                            this.GoThrough(_TA);
                        }
                        else
                        {
                            ForegroundColor = ConsoleColor.Cyan;
                            WriteLine("This item is not in your inventory.");
                        }
                    }
                    else
                    {
                        ForegroundColor = ConsoleColor.Cyan;
                        WriteLine("This item doesn't open the door.");
                    }
                }
            }
        }

        private void GoThrough(TextAdventure _TA)
        {
            if (this.LeadsTo == "GameEnd")
            {
                ForegroundColor = ConsoleColor.Magenta;
                WriteLine(_TA.Player.GameEndText);
                _TA.GameOver = true;
            }

            foreach (Room r in _TA.Rooms)
            {
                if (this.LeadsTo == r.Name)
                {
                    _TA.CurrentRoom = r;
                    _TA.CurrentRoom.DisplayRoom();
                }
            }
        }
    }
}