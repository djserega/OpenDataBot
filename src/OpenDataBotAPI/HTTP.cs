using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OpenDataBotAPI
{
    internal class HTTP
    {
        private const string _url = "https://opendatabot.com/api/v2";
        private string _apiKey;

        internal HTTP(string apiKey)
        {
            _apiKey = apiKey;
        }
 

        internal T GetInfo<T>(string param) where T : class, new()
        {
            WebRequest webRequest = GetWebRequest(typeof(T), param);

            WebResponse webResponse = webRequest.GetResponse();

            string response = string.Empty;
            using (StreamReader reader = new StreamReader(webResponse.GetResponseStream()))
            {
                response = reader.ReadToEnd();
            }

            return Json<T>.DeserializeString(response);
        }

        internal List<T> GetInfos<T>(string param) where T : class, new()
        {
            WebRequest webRequest = GetWebRequest(typeof(T), param);
            if (webRequest == null)
                return null;

            WebResponse webResponse = webRequest.GetResponse();

            string response = string.Empty;
            using (StreamReader reader = new StreamReader(webResponse.GetResponseStream()))
            {
                response = reader.ReadToEnd();
            }

            return Json<T>.DeserializeStringToList(response);
        }

        private WebRequest GetWebRequest(Type type, string param)
        {
            StringBuilder stringBuilder = new StringBuilder(_url);

            if (type == typeof(Company))
                stringBuilder.Append("/company/");
            else if (type == typeof(Fop))
                stringBuilder.Append("/fop/");
            else
                return null;

            stringBuilder.Append(param);
            stringBuilder.Append("?apiKey=");
            stringBuilder.Append(_apiKey);

            WebRequest webRequest = WebRequest.Create(stringBuilder.ToString());
            webRequest.Method = "get";
            webRequest.ContentType = "application/json";

            return webRequest;
        }
    }
}
