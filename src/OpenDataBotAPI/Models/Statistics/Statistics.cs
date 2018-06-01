using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace OpenDataBotAPI
{
    [Guid("2450DA48-2DCD-4EA9-ABB6-CD5356899B5D")]
    [ClassInterface(ClassInterfaceType.None)]
    [ComSourceInterfaces(typeof(IAPI_20Events))]
    public class APIStatistics
    {
        public StatisticCompany Company { get; set; }
        public StatisticFullCompany FullCompany { get; set; }
        public StatisticFop Fop { get; set; }
        public StatisticFopInn FopInn { get; set; }
        public StatisticPerson Person { get; set; }
        public StatisticRegistrations Registrations { get; set; }
        public StatisticVat Vat { get; set; }
        public StatisticSchedule Schedule { get; set; }
        public StatisticCompanyRecord CompanyRecord { get; set; }
        public StatisticCourt Court { get; set; }
        public StatisticSubscription Subscription { get; set; }
        public StatisticUnsubscription Unsubscription { get; set; }
        public StatisticHistory History { get; set; }
        public StatisticChanges Changes { get; set; }
        public StatisticInstitutions Institutions { get; set; }
        public StatisticSearch Search { get; set; }
        public StatisticLists Lists { get; set; }
        public StatisticDebt Debt { get; set; }
        public StatisticApiCourt ApiCourt { get; set; }
        public StatisticMessage Message { get; set; }
        public StatisticStatistics Statistics { get; set; }

    }

    public class StatisticCompany : StatisticsBase { }
    public class StatisticFullCompany : StatisticsBase { }
    public class StatisticFop : StatisticsBase { }
    public class StatisticFopInn : StatisticsBase { }
    public class StatisticPerson : StatisticsBase { }
    public class StatisticRegistrations : StatisticsBase { }
    public class StatisticVat : StatisticsBase { }
    public class StatisticSchedule : StatisticsBase { }
    public class StatisticCompanyRecord : StatisticsBase { }
    public class StatisticCourt : StatisticsBase { }
    public class StatisticSubscription : StatisticsBase { }
    public class StatisticUnsubscription : StatisticsBase { }
    public class StatisticHistory : StatisticsBase { }
    public class StatisticChanges : StatisticsBase { }
    public class StatisticInstitutions : StatisticsBase { }
    public class StatisticSearch : StatisticsBase { }
    public class StatisticLists : StatisticsBase { }
    public class StatisticDebt : StatisticsBase { }
    public class StatisticApiCourt : StatisticsBase { }
    public class StatisticMessage : StatisticsBase { }
    public class StatisticStatistics : StatisticsBase { }

    public class StatisticsBase
    {
        public string Name { get; set; }
        public int Used { get; set; }
        public int Limit { get; set; }
        public int Balance { get; set; }
    }


}
