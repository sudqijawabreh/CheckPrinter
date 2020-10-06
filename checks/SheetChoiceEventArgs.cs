using System;

namespace checks
{
    public class SheetChoiceEventArgs : EventArgs
    {
        public SheetChoiceType ChoiceType { get; set; }
        public string ChoosenItem { get; set; }
    }
    public enum SheetChoiceType
    {
        Cancel = 0,
        OK = 1,
    }
}
