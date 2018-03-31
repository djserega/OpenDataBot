using System.Collections.Generic;

namespace OpenDataBotAPI
{
    public interface IFop
    {
        string Activities { get; }
        string[] Additionally_activities { get; }
        string Birth_date { get; }
        string Code { get; }
        string Email { get; }
        string Full_name { get; }
        ChangeItem[] History { get; }
        string Last_date { get; }
        string Location { get; }
        string Pdv_code { get; }
        string Pdv_status { get; }
        string[] Phones { get; }
        string Registration_date { get; }
        Sex Sex { get; }
        string Status { get; }
        Tax_debts[] Tax_debts { get; }
    }
}