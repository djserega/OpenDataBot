using System.Runtime.InteropServices;

namespace OpenDataBotAPI
{
    [Guid("50B2C4A8-90C5-451A-B765-DC6A533351D3")]
    [ComSourceInterfaces(typeof(IBeneficiaries))]
    public class Beneficiaries : IBeneficiaries
    {
        public string Title { get; set; }
        public string Capital { get; set; }
        public string Location { get; set; }
    }
}
