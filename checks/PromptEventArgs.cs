using System;

namespace checks
{
    public class PromptEventArgs : EventArgs
    {
        public PromptChoice ChoiceType { get; set; }
        public string Item { get; set; }
    }
    public enum PromptChoice
    {
        Cancel = 0,
        OK = 1,
    }
}
