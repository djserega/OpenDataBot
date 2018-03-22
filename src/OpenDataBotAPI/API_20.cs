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

        public bool Error { get; private set; }
        public string ErrorText { get; private set; }


        public List<Company> ListCompany { get; private set; }


        public API_20()
        {
            _apiKey = "";
        }


        public void SetAPIKey(string apiKey)
        {
            _apiKey = apiKey;
        }

        public void GetCompany(string code)
        {
            if (string.IsNullOrWhiteSpace(_apiKey))
            {
                Error = true;
                ErrorText = "Не указан api-ключ";
                return;
            }

            InitializeAPI();

            _http.CompanyCode = code;
            ListCompany = _http.GetInfo<Company>();
        }

        private void InitializeAPI()
        {
            if (_http == null)
            {
                _http = new HTTP(_apiKey);
                Error = false;
                ErrorText = string.Empty;
            }
        }
    }
}
