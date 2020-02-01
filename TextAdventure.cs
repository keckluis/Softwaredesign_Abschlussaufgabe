using System.Collections.Generic;
using static System.Console;
using System.IO;
using Newtonsoft.Json;

namespace Softwaredesign_Abschlussaufgabe
{
    class TextAdventure
    {
        private static List<Room> Rooms;
        private Player Player;

        static void Main(string[] args)
        {
            LoadGame();
        }

        private static void LoadGame()
        {
            Rooms = new List<Room>();

            using(StreamReader r = new StreamReader("Rooms.json"))
            {
                string json = r.ReadToEnd();
                Rooms = JsonConvert.DeserializeObject<List<Room>>(json);
            }

            PlayGame();
        }

        private static void PlayGame()
        {
            foreach(Room r in Rooms)
            {
                WriteLine(r.Description);
            }
        }

        private void DisplayCommands()
        {

        }
    }
}
