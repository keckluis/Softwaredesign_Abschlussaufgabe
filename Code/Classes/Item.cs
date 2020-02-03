using static System.Console;

namespace Softwaredesign_Abschlussaufgabe
{
    class Item
    {
        public string Name;
        public int Damage;
        public int HealthRegeneration;

        public Item(string _Name, int _Damage = 0, int _HealthRegeneration = 0)
        {
            this.Name = _Name;
            this.Damage = _Damage;
            this.HealthRegeneration = _HealthRegeneration;
        }

        public void DisplayItem()
        {
            WriteLine(this.Name + " (" + this.Damage + "dmg, " + this.HealthRegeneration + "reg)");
        }
    }
}