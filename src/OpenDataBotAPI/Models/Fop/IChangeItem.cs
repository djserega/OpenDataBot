using System;
using System.Collections.Generic;

namespace OpenDataBotAPI
{
    public interface IChangeItem
    {
        DateTime Date { get; }
        Changes Changes { get; }
    }
}