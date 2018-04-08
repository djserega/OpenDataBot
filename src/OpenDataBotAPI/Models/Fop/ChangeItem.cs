﻿using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace OpenDataBotAPI
{
    [Guid("2472EC29-1843-4A9A-A664-95B2C6C24453")]
    [ClassInterface(ClassInterfaceType.None)]
    [ComSourceInterfaces(typeof(IChangeItem))]
    public class ChangeItem : IChangeItem
    {
        public DateTime Date { get; set; }
        public Changes Changes { get; set; }
    }
}
