using System.Runtime.InteropServices;

namespace OpenDataBotAPI
{
    public class Changes : IChanges
    {
        public string Field { get; set; }
        public string Old_value { get; set; }
        public string New_value { get; set; }
    }
}
