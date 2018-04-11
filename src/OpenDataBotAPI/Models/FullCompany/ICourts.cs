using System;

namespace OpenDataBotAPI
{
    public interface ICourts
    {
        string Text { get; }
        string Icon { get; }
        string Value { get; }
        DateTime Database_Date { get; }
        IDecision CurrentDecision { get; }
        int DecisionCount { get; }
        int DecisionIndex { get; set; }
        bool NextDecision();
    }

}
