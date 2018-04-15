using System.Runtime.InteropServices;

namespace OpenDataBotAPI
{
    [Guid("50B2C4A8-90C5-451A-B765-DC6A533351D3")]
    [ComSourceInterfaces(typeof(IBeneficiariesCompany))]
    public class BeneficiariesCompany : IBeneficiariesCompany
    {
        public string Title { get; set; }
        public long Capital { get; set; }
        public string Location { get; set; }
    }
}
