using System;

namespace OpenDataBotAPI
{
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
