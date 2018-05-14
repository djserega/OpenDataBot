using System;

namespace OpenDataBotAPI
{
    [Guid("C20058D2-7B86-4489-B6AF-0488C0162044")]
    [ClassInterface(ClassInterfaceType.None)]
    [ComSourceInterfaces(typeof(ITax_debts))]
    public class Tax_debts : ITax_debts
    {
        public string Text { get; set; }
        public string Icon { get; set; }
        public Double Total { get; set; }
        public Double Local { get; set; }
        public Double Government { get; set; }
        public dynamic DataBase_date { get; set; }
    }
}
