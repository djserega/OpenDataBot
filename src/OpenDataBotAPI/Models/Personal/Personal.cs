using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenDataBotAPI
{
    public class Personal
    {
        public PersonalCeo Ceo { get; set; }
        public PersonalCeo Old_ceo { get; set; }
        public PersonalCeo Beneficiaries { get; set; }
        public PersonalCeo Old_Beneficiaries { get; set; }
        public PersonalWanted Wanted { get; set; }
        public PersonalSessions Sessions { get; set; }
        public PersonalFop Fop { get; set; }
    }
}
