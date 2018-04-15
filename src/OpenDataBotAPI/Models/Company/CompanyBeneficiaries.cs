using System.Runtime.InteropServices;

namespace OpenDataBotAPI
{
    public class CompanyBeneficiaries : ICompanyBeneficiaries
    {
        public string Title { get; set; }
        public long Capital { get; set; }
        public string Location { get; set; }
    }
}
