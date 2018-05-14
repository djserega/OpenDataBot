using System;

namespace OpenDataBotAPI
{
    public interface IChangeItem
    {
        DateTime Date { get; }
        
        Changes CurrentChanges { get; }
        int ChangesCount { get; }
        int ChangesIndex { get; set; }
        bool NextChanges();
    }
}