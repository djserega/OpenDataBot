using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Net;

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
                {
                    _apiKey = value;
                    _http = null;
                }
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
                SetError("Не указан api-ключ");
                return false;
            }
            else
            {
                SetError();
                return true;
            }
        }

        private void SetError(string text = "")
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                Error = false;
                ErrorText = string.Empty;
            }
            else
            {
                Error = true;
                ErrorText = text;
            }
        }


        public void GetFop(string code)
        {
            if (!CheckFilledAPIKey())
                return;

            InitializeHTTP();

            try
            {
                Fop = _http.GetInfo<Fop>(code);
            }
            catch (WebException ex)
            {

                SetWebExceptionErrorByType<Fop>(ex);
            }
        }

        public void GetCompany(string code)
        {
            if (!CheckFilledAPIKey())
                return;

            InitializeHTTP();

            try
            {
                _listCompany = _http.GetInfos<Company>(code);
                if (_listCompany.Count == 1)
                    Company = _listCompany[0];
                else
                    Company = null;
            }
            catch (WebException ex)
            {
                SetWebExceptionErrorByType<Company>(ex);
            }
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

        private void SetWebExceptionErrorByType<T>(WebException ex)
        {
            HttpWebResponse webResponse = (HttpWebResponse)ex.Response;

            Type typeT = typeof(T);

            string textStatus = string.Empty;
            if (typeT == typeof(Fop))
            {
                if (webResponse.StatusCode == HttpStatusCode.NotFound)
                    textStatus = "ФОП не найден.";
                else if (webResponse.StatusCode == HttpStatusCode.Forbidden)
                    textStatus = "Некорректный api-ключ.";
                else
                    textStatus = $"ФОП. {ex.Status}. {ex.Message}";
            }
            else if (typeT == typeof(Company))
            {
                if (webResponse.StatusCode == HttpStatusCode.NotFound)
                    textStatus = "Компания/компании не найден/ы.";
                else if (webResponse.StatusCode == HttpStatusCode.Forbidden)
                    textStatus = "Некорректный api-ключ.";
                else
                    textStatus = $"Компания. {ex.Status}. {ex.Message}";
            }

            SetError($"Ошибка получения информации. {textStatus}");
        }
    }
}
