using System;

namespace OpenDataBotAPI
{
    public class FullCompanyDecision : IFullCompanyDecision
    {
        public string Number { get; set; }
        public string Type { get; set; }
        public string Form { get; set; }
        public string Document_Number { get; set; }
        public string Curt_Name { get; set; }
        public DateTime Entry_Date { get; set; }
        public DateTime Judge { get; set; }
        public string Link { get; set; }
    }

}
