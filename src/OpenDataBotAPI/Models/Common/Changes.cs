using System.Runtime.InteropServices;

namespace OpenDataBotAPI
{
    [Guid("98DF37AB-F67A-4C63-92DA-7BE989A7E008")]
    [ClassInterface(ClassInterfaceType.None)]
    [ComSourceInterfaces(typeof(IChanges))]
    public class Changes : IChanges
    {
        public string Field { get; set; }
        public string Old_value { get; set; }
        public string New_value { get; set; }
    }
}
