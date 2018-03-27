using System.Runtime.InteropServices;

namespace OpenDataBotAPI
{
    [Guid("C20058D2-7B86-4489-B6AF-0488C0162044")]
    [ClassInterface(ClassInterfaceType.None)]
    [ComSourceInterfaces(typeof(ITax_debts))]
    public class Tax_debts : ITax_debts
    {
        public string Text { get; set; }
        public string Icon { get; set; }
        public string Total { get; set; }
        public string Local { get; set; }
        public string Government { get; set; }
        public string DataBase_date { get; set; }
    }
}
