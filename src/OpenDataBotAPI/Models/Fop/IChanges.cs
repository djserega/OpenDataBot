namespace OpenDataBotAPI
{
    public interface IChanges
    {
        string Field { get; }
        string New_value { get; }
        string Old_value { get; }
    }
}