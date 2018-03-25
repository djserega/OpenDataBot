using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenDataBotAPI
{
    public class Fop
    {
        public string Code { get; set; }
        public string Full_name { get; set; }
        public string Location { get; set; }
        public string Status { get; set; }
        public List<string> Phones { get; set; }
        public string Email { get; set; }
        public string Registration_date { get; set; }
        public string Last_date { get; set; }
        public string Birth_date { get; set; }
        public Sex Sex { get; set; }
        public string Activities { get; set; }
        public List<string> Additionally_activities { get; set; }
        public List<ChangeItem> History { get; set; }
        public string Pdv_code { get; set; }
        public string Pdv_status { get; set; }
        public List<Tax_debts> Tax_debts { get; set; }
    }

    public class ChangeItem
    {
        public string Date { get; set; }
        public List<Changes> Changes { get; set; }
    }

    public class Changes
    {
        public string Field { get; set; }
        public string Old_value { get; set; }
        public string New_value { get; set; }
    }

    public class Tax_debts
    {
        public string Text { get; set; }
        public string Icon { get; set; }
        public string Total { get; set; }
        public string Local { get; set; }
        public string Government { get; set; }
        public string DataBase_date { get; set; }
    }

    public enum Sex { male, female };
}
