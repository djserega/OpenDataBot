using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace OpenDataBotAPI
{
    public class ChangeItem : IChangeItem
    {
        public DateTime Date { get; set; }
        public Changes[] Changes { get; set; }
    }
}
