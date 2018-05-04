using System.Collections.Generic;
using System.Web.Script.Serialization;

namespace OpenDataBotAPI
{
    internal static class Json<T> where T : class, new()
    {
        internal static T DeserializeString(string input)
        {
            return new JavaScriptSerializer().Deserialize<T>(input);
        }

        internal static List<T> DeserializeStringToList(string input)
        {
            return new JavaScriptSerializer().Deserialize<List<T>>(input);
        }
    }
}
