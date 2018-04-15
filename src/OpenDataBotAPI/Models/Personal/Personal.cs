using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace OpenDataBotAPI
{
    [Guid("78521B00-A142-48DA-AD63-B6ADBCB8A570")]
    [ClassInterface(ClassInterfaceType.None)]
    [ComSourceInterfaces(typeof(IFullCompany))]
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
