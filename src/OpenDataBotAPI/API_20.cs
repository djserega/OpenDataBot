using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace OpenDataBotAPI
{
    [Guid("7418C8E7-A649-48B7-B682-04DC923C4DB4"),]
    [ClassInterface(ClassInterfaceType.None)]
    [ComSourceInterfaces(typeof(IAPI_20Events))]
    public class API_20 : IAPI_20
    {
        private string _apiKey;
        private HTTP _http;
        private List<Company> _listCompany = new List<Company>();
        private int _companyIndex;


        public string APIKey
        {
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


        public Fop Fop { get; private set; }
        public Company Company { get; private set; }
        public int CompanyCount { get { return _listCompany.Count; } }
        public int CompanyIndex
        {
            get { return _companyIndex; }
            set
            {
                if (value < 0)
                    _companyIndex = 0;
                else if (value > _listCompany.Count - 1)
                    _companyIndex = _listCompany.Count;
                else
                    _companyIndex = value;
            }
        }


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

            Fop = _http.GetInfo<Fop>(code);
        }

        public void GetCompany(string code)
        {
            if (!CheckFilledAPIKey())
                return;

            InitializeHTTP();

            _listCompany = _http.GetInfos<Company>(code);
            if (_listCompany.Count == 1)
                Company = _listCompany[0];
            else
                Company = null;
        }

        public bool NextCompany()
        {
            if (_companyIndex < 0
                || _companyIndex > _listCompany.Count - 1)
            {
                _companyIndex = 0;
                Company = null;
                return false;
            }

            Company = _listCompany[_companyIndex];
            _companyIndex++;
            return true;
        }
    }
}
