using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

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

        private Type _typeT;

        internal T GetInfo<T>(string param) where T : class, new()
        {
            param = param.Trim();

            _typeT = typeof(T);

            WebRequest webRequest = GetWebRequest(param);

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
            param = param.Trim();

            _typeT = typeof(T);

            WebRequest webRequest = GetWebRequest(param);
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

        private WebRequest GetWebRequest(string param)
        {
            StringBuilder stringBuilder = new StringBuilder(_url);

            if (_typeT == typeof(Company))
                stringBuilder.Append("/company/");
            else if (_typeT == typeof(Fop))
                stringBuilder.Append("/fop/");
            else if (_typeT == typeof(FullCompany))
                stringBuilder.Append("/fullcompany/");
            else if (_typeT == typeof(ChangesCompany))
                stringBuilder.Append("/changes/");
            else if (_typeT == typeof(Personal))
                stringBuilder.Append("/person");
            else
                return null;

            if (_typeT != typeof(Personal))
                stringBuilder.Append(param);

            stringBuilder.Append("?apiKey=");
            stringBuilder.Append(_apiKey);

            if (_typeT == typeof(Personal))
            {
                stringBuilder.Append("&pib=");
                stringBuilder.Append(param);
            }

            WebRequest webRequest = WebRequest.Create(stringBuilder.ToString());
            webRequest.Method = "get";
            webRequest.ContentType = "application/json";

            return webRequest;
        }
    }
}
