using System;

namespace OpenDataBotAPI
{
    public interface ITax_debts
    {
        dynamic DataBase_date { get; }
        Double Government { get; }
        string Icon { get; }
        Double Local { get; }
        string Text { get; }
        Double Total { get; }
    }
}