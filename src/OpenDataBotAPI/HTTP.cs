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
        private string _url = "https://opendatabot.com/api/v2";
        private string _apiKey;

        internal HTTP(string apiKey)
        {
            _apiKey = apiKey;
        }

        internal string CompanyCode { get; set; }

        internal List<T> GetInfo<T>() where T : class, new()
        {
            WebRequest webRequest = GetWebRequest(typeof(T));

            WebResponse webResponse = webRequest.GetResponse();

            string response = string.Empty;
            using (StreamReader reader = new StreamReader(webResponse.GetResponseStream()))
            {
                response = reader.ReadToEnd();
            }

            return Json<T>.DeserializeString(response);
        }

        private WebRequest GetWebRequest(Type type)
        {
            StringBuilder stringBuilder = new StringBuilder(_url);
            if (type == typeof(Company))
            {
                stringBuilder.Append("/company/");
                stringBuilder.Append(CompanyCode);
                stringBuilder.Append("?apiKey=");
                stringBuilder.Append(_apiKey);

            }
            else
                return null;

            WebRequest webRequest = WebRequest.Create(stringBuilder.ToString());
            webRequest.Method = "get";
            webRequest.ContentType = "application/json";

            return webRequest;
        }
    }
}
