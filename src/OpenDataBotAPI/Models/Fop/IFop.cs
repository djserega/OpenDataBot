namespace OpenDataBotAPI
{
    public interface IFop
    {
        string Activities { get; }
        string[] Additionally_activities { get; }
        string Birth_date { get; }
        string Code { get; }
        IChangeItem CurrentHistory { get; }
        ITax_debts CurrentTax_debts { get; }
        string Email { get; }
        string Full_name { get; }
        int HistoryCount { get; }
        int HistoryIndex { get; set; }
        string Last_date { get; }
        string Location { get; }
        string Pdv_code { get; }
        string Pdv_status { get; }
        string[] Phones { get; }
        string Registration_date { get; }
        Sex Sex { get; }
        string Status { get; }
        int Tax_debtsCount { get; }
        int Tax_debtsIndex { get; set; }

        bool NextHistory();
        bool NextTax_debts();
    }
}