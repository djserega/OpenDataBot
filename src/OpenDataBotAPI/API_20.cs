using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenDataBotAPI
{
    public class API_20
    {
        private string _apiKey;
        private HTTP _http;


        public string APIKey
        {
            get { return _apiKey; }

        }

        public bool APIKeyIsSet
        {
            get { return !string.IsNullOrWhiteSpace(_apiKey); }
        }


        public void SetAPIKey(string apiKey)
        {
            _apiKey = apiKey;
        }

        public void GetCompany(string code)
        {
            InitializeHTTP();

            _http.CompanyCode = code;
            string result = _http.GetInfo<Company>();
        }

        private void InitializeHTTP()
        {
            if (_http == null)
                _http = new HTTP(_apiKey);
        }
    }
}
