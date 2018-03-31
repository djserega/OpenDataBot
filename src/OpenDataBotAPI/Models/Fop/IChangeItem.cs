using System.Collections.Generic;

namespace OpenDataBotAPI
{
    public interface IChangeItem
    {
        IChanges[] Changes { get; }
        string Date { get; }
    }
}