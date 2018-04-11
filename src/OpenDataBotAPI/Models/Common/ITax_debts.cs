using System;

namespace OpenDataBotAPI
{
    public interface ITax_debts
    {
        DateTime DataBase_date { get; }
        string Government { get; }
        string Icon { get; }
        string Local { get; }
        string Text { get; }
        string Total { get; }
    }
}