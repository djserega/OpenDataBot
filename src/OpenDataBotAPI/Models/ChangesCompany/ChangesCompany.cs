using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenDataBotAPI
{
    public class ChangesCompany
    {
        public string Code { get; set; }
        public ChangeItem[] Items { get; set; }
    }
}
