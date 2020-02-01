using System.Collections.Generic;

namespace Softwaredesign_Abschlussaufgabe
{
    class Room
    {
        public string Description;

        public Door NorthDoor;
        public Door EastDoor;
        public Door SouthDoor;
        public Door WestDoor;

        public List<string> Items;
        public List<NPC> NPCs;

        public Room(string _Description, Door _NorthDoor, Door _EastDoor, Door _SouthDoor, Door _WestDoor, List<string> _Items, List<NPC> _NPCs)
        {
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

        }

        public void GoThroughDoor(Door _door)
        {

        }
    }
}