using System;
using System.Runtime.InteropServices;

namespace OpenDataBotAPI
{
    public class Tax_debts : ITax_debts
    {
        public string Text { get; set; }
        public string Icon { get; set; }
        public string Total { get; set; }
        public string Local { get; set; }
        public string Government { get; set; }
        public DateTime DataBase_date { get; set; }
    }
}
