using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenDataBotAPI
{
    public class Company
    {
        public string Full_name { get; set; }
        public string Short_name { get; set; }
        public string Code { get; set; }
        public string Ceo_name { get; set; }
        public string Location { get; set; }
        public string Activities { get; set; }
        public string Status { get; set; }
        public List<Beneficiaries> Beneficiaries { get; set; }
    }

    public class Beneficiaries
    {
        public string Title { get; set; }
        public string Capital { get; set; }
        public string Location { get; set; }
    }
}
