using System;

namespace OpenDataBotAPI
{
    public interface IFullCompanyDecision
    {
        string Number { get; }
        string Type { get; }
        string Form { get; }
        string Document_Number { get; }
        string Curt_Name { get; }
        DateTime Entry_Date { get; }
        DateTime Judge { get; }
        string Link { get; }
    }

}
