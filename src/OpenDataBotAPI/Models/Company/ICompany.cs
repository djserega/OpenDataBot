namespace OpenDataBotAPI
{
    public interface ICompany
    {
        string Activities { get; }
        string Ceo_name { get; }
        string Code { get; }
        string Full_name { get; }
        string Location { get; }
        string Short_name { get; }
        string Status { get; }
        ICompanyBeneficiaries CurrentBeneficiaries { get; }

        int BeneficiariesCount { get; }
        int BeneficiariesIndex { get; set; }
        bool NextBeneficiaries();
    }
}