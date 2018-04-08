using System.Collections.Generic;

namespace OpenDataBotAPI
{
    public interface IChangeItem
    {
        string Date { get; }
        Changes Changes { get; }
    }
}