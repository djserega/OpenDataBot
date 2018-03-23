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
            set
            {
                if (_apiKey != value)
                    _apiKey = value;
            }
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

        private void InitializeHTTP()
        {
            if (_http == null)
                _http = new HTTP(_apiKey);
        }

        private bool CheckFilledAPIKey()
        {
            if (!APIKeyIsSet)
            {
                Error = true;
                ErrorText = "Не указан api-ключ";
                return false;
            }
            else
            {
                Error = false;
                ErrorText = string.Empty;
                return true;
            }
        }


        public void GetFop(string code)
        {
            if (!CheckFilledAPIKey())
                return;

            InitializeHTTP();

            Fop fop = _http.GetInfo<Fop>(code);
        }

        public void GetCompany(string code)
        {
            if (!CheckFilledAPIKey())
                return;

            InitializeHTTP();

            ListCompany = _http.GetInfos<Company>(code);
        }

    }
}
