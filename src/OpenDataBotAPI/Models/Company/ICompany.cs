using System.Collections.Generic;

namespace OpenDataBotAPI
{
    public interface ICompany
    {
        string Activities { get; set; }
        string Ceo_name { get; set; }
        string Code { get; set; }
        string Full_name { get; set; }
        string Location { get; set; }
        string Short_name { get; set; }
        string Status { get; set; }
        Beneficiaries Beneficiarie { get; set; }

        int BeneficiariesCount { get; }
        int BeneficiariesIndex { get; set; }
        bool NextBeneficiarie();
    }
}