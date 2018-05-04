using System;

namespace OpenDataBotAPI
{
    public class ChangeItem : IChangeItem
    {
        public DateTime Date { get; set; }
        public Changes Changes { get; set; }
    }
}
