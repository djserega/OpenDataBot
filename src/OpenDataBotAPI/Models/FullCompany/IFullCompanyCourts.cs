using System;

namespace OpenDataBotAPI
{
    public interface IFullCompanyCourts
    {
        string Text { get; }
        string Icon { get; }
        string Value { get; }
        DateTime Database_Date { get; }
        IFullCompanyDecision CurrentDecision { get; }
        int DecisionCount { get; }
        int DecisionIndex { get; set; }
        bool NextDecision();
    }

}
