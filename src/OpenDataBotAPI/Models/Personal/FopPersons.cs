namespace OpenDataBotAPI
{
    public class FopPersons
    {
        private Debt_status? _debt_status;

        public string Full_name { get; set; }
        public string Location { get; set; }
        public string Activities { get; set; }
        public string Debt_status
        {
            get { return _debt_status?.ToString("F"); }
            set
            {
                switch (value)
                {
                    case "possible debt":
                        _debt_status = OpenDataBotAPI.Debt_status.PossibleDebt;
                        break;
                    case "no debt":
                        _debt_status = OpenDataBotAPI.Debt_status.NoDebt;
                        break;
                    case "debt":
                        _debt_status = OpenDataBotAPI.Debt_status.Debt;
                        break;
                    default:
                        _debt_status = null;
                        break;
                }
            }
        }
        public long Debt_amount { get; set; }
      }
}
