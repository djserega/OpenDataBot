using System;

namespace OpenDataBotAPI
{
    public interface IFullCompany
    {
        int ActivitiesCount { get; }
        int ActivitiesIndex { get; set; }
        int BeneficiariesCount { get; }
        int BeneficiariesIndex { get; set; }
        long Capital { get; }
        IFullCompanyActivities CurrentActivities { get; }
        IFullCompanyBeneficiares CurrentBeneficiaries { get; }
        IHeads CurrentHeads { get; }
        IChangeItem CurrentHistory { get; }
        string Email { get; }
        int HeadsCount { get; }
        int HeadsIndex { get; set; }
        int HistoryCount { get; }
        int HistoryIndex { get; }
        DateTime Last_time { get; }
        string Phones { get;  }
        DateTime Registration_date { get; }

        bool NextActivities();
        bool NextBeneficiaries();
        bool NextHeads();
        bool NextHistory();
    }
}