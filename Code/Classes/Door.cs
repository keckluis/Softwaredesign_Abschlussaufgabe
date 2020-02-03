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
    }
}