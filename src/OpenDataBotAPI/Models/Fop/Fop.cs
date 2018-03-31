using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace OpenDataBotAPI
{
    [Guid("4D983636-A648-4218-A333-380D9E7A3E21")]
    [ClassInterface(ClassInterfaceType.None)]
    [ComSourceInterfaces(typeof(IFop))]
    public class Fop : IFop
    {
        public string Code { get; set; }
        public string Full_name { get; set; }
        public string Location { get; set; }
        public string Status { get; set; }
        public string[] Phones { get; set; }
        public string Email { get; set; }
        public string Registration_date { get; set; }
        public string Last_date { get; set; }
        public string Birth_date { get; set; }
        public string Activities { get; set; }
        public string Pdv_code { get; set; }
        public string Pdv_status { get; set; }

        public Sex Sex { get; set; }

        public string[] Additionally_activities { get; set; }

        public ChangeItem[] History { get; set; }

        public Tax_debts[] Tax_debts { get; set; }
    }
}
