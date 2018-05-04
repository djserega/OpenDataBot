using System;

namespace OpenDataBotAPI
{
    public interface IChangeItem
    {
        DateTime Date { get; }
        Changes Changes { get; }
    }
}