using System;

namespace OpenDataBotAPI
{
    public class Persons
    {
        public long ID { get; set; }
        public string Full_name { get; set; }
        public DateTime Birth_date { get; set; }
        public DateTime Lost_date { get; set; }
        public Sex Sex { get; set; }
        public string Article_crim { get; set; }
        public string Lost_place { get; set; }
        public string Ovd { get; set; }
        public string Category { get; set; }
        public string Restraint { get; set; }
        public string Status_text { get; set; }
        static int Status { get; set; }
    }

}
