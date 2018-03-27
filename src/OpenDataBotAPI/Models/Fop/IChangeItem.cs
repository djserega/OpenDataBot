using System.Collections.Generic;

namespace OpenDataBotAPI
{
    public interface IChangeItem
    {
        List<Changes> Changes { get; }
        string Date { get; }
    }
}