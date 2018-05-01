namespace OpenDataBotAPI
{
    public interface IChangesCompany
    {
        string Code { get; }
        IChangeItem Item { get; }
        int ItemCount { get; }
        int ItemIndex { get; set; }

        bool NextItem();
    }
}