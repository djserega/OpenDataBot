using System;

namespace OpenDataBotAPI
{
    public class PersonalCompany : BaseCompany
    {
        public string Activities { get; set; }
        public DateTime Database_date { get; set; }
        public Heads[] Heads { get; set; }
    }

}
