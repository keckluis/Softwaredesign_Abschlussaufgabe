using static System.Console;

namespace Softwaredesign_Abschlussaufgabe
{
    class NPC
    {
        public string Name;
        public Item Loot;
        public Item Trade;
        public int Health;
        public int Damage;
        public string Text;

        public NPC(string _Name, Item _Loot, Item _Trade, int _Health, int _Damage, string _Text)
        {
            this.Name = _Name;
            this.Loot = _Loot;
            this.Trade = _Trade;
            this.Health = _Health;
            this.Damage = _Damage;
            this.Text = _Text;
        }

        public void DisplayNPC()
        {
            WriteLine(this.Name + "(" + this.Health + "hp/ " + this.Damage + "dmg/ trades " + this.Loot.Name + " for " + this.Trade.Name + ")");
        }
    }
}