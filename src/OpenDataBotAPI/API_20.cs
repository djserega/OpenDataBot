using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
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

        #region API

        // STATISTIC

        public APIStatistics Statistics { get; private set; }

        public void GetStatistic()
        {
            if (!CheckFilledAPIKey())
                return;

            InitializeHTTP();

            try
            {
                Statistics = _http.GetInfo<APIStatistics>();
            }
            catch (WebException ex)
            {
                SetWebExceptionErrorByType<APIStatistics>(ex);
            }
            catch (Exception ex)
            {
                SetError(ex.Message);
            }
        }

        // FOP
        public Fop Fop { get; private set; }

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
            catch (Exception ex)
            {
                SetError(ex.Message);
            }
        }
        
        // COMPANY
        public Company Company { get; private set; }
        private List<Company> _listCompany = new List<Company>();
        private int _companyIndex;
        public int CompanyCount { get { return _listCompany.Count; } }
        public int CompanyIndex
        {
            get { return _companyIndex; }
            set
            {
                if (value < 0)
                    _companyIndex = 0;
                else if (value > CompanyCount - 1)
                    _companyIndex = CompanyCount;
                else
                    _companyIndex = value;
            }
        }
        public bool NextCompany()
        {
            if (_companyIndex < 0
                || _companyIndex > CompanyCount - 1)
            {
                _companyIndex = 0;
                Company = null;
                return false;
            }

            Company = _listCompany[_companyIndex];
            _companyIndex++;
            return true;
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
            catch (Exception ex)
            {
                SetError(ex.Message);
            }
        }

        // FULLCOMPANY
        public FullCompany FullCompany { get; private set; }

        public void GetFullCompany(string code)
        {
            if (!CheckFilledAPIKey())
                return;

            InitializeHTTP();

            try
            {
                FullCompany = _http.GetInfo<FullCompany>(code);
            }
            catch (WebException ex)
            {
                SetWebExceptionErrorByType<FullCompany>(ex);
            }
            catch (Exception ex)
            {
                SetError(ex.Message);
            }
        }

        // CHANGES
        public ChangesCompany Changes { get; private set; }
        private List<ChangesCompany> _listChanges = new List<ChangesCompany>();
        private int _changesIndex;
        public int ChangesCount { get { return _listChanges.Count; } }
        public int ChangesIndex
        {
            get { return _changesIndex; }
            set
            {
                if (value < 0)
                    _changesIndex = 0;
                else if (value > ChangesCount - 1)
                    _changesIndex = ChangesCount;
                else
                    _changesIndex = value;
            }
        }
        public bool NextChanges()
        {
            if (_changesIndex < 0
                || _changesIndex > ChangesCount - 1)
            {
                _changesIndex = 0;
                Changes = null;
                return false;
            }

            Changes = _listChanges[_changesIndex];
            _changesIndex++;
            return true;
        }
                            
        public void GetChanges(string code)
        {
            if (!CheckFilledAPIKey())
                return;

            InitializeHTTP();

            try
            {
                _listChanges = _http.GetInfos<ChangesCompany>(code);
                if (_listChanges.Count == 1)
                    Changes = _listChanges[0];
                else
                    Changes = null;
            }
            catch (WebException ex)
            {
                SetWebExceptionErrorByType<ChangesCompany>(ex);
            }
            catch (Exception ex)
            {
                SetError(ex.Message);
            }
        }

        // PERSONAL
        public Personal Personal { get; private set; }
        public void GetPersonalInfo(string pib)
        {
            if (!CheckFilledAPIKey())
                return;

            InitializeHTTP();

            try
            {
                Personal = _http.GetInfo<Personal>(WebUtility.UrlEncode(pib).Replace("+", "%20"));
            }
            catch (WebException ex)
            {
                SetWebExceptionErrorByType<Personal>(ex);
            }
            catch (Exception ex)
            {
                SetError(ex.Message);
            }
        }
     
        #endregion

        #region Errors

        public bool Error { get; private set; }
        public string ErrorText { get; private set; }

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

        private void SetWebExceptionErrorByType<T>(WebException ex)
        {
            HttpWebResponse webResponse = (HttpWebResponse)ex.Response;

            Type typeT = typeof(T);

            string textStatus = string.Empty;
            if (typeT == typeof(APIStatistics))
            {
                switch (webResponse.StatusCode)
                {
                    case HttpStatusCode.Forbidden:
                        textStatus = "Некорректный api-ключ.";
                        break;
                    default:
                        textStatus = $"Статистика. {ex.Status}. {ex.Message}";
                        break;
                }
            }
            else if (typeT == typeof(Fop))
            {
                switch (webResponse.StatusCode)
                {
                    case HttpStatusCode.Forbidden:
                        textStatus = "Некорректный api-ключ.";
                        break;
                    case HttpStatusCode.NotFound:
                        textStatus = "ФОП не найден.";
                        break;
                    default:
                        textStatus = $"ФОП. {ex.Status}. {ex.Message}";
                        break;
                }
            }
            else if (typeT == typeof(Company))
            {
                switch (webResponse.StatusCode)
                {
                    case HttpStatusCode.Forbidden:
                        textStatus = "Некорректный api-ключ.";
                        break;
                    case HttpStatusCode.NotFound:
                        textStatus = "Компания/компании не найден/ы.";
                        break;
                    default:
                        textStatus = $"Компания. {ex.Status}. {ex.Message}";
                        break;
                }
            }
            else if (typeT == typeof(ChangesCompany))
            {
                switch (webResponse.StatusCode)
                {
                    case HttpStatusCode.Forbidden:
                        textStatus = "Некорректный api-ключ.";
                        break;
                    case HttpStatusCode.NotFound:
                        textStatus = "Компания/компании не найден/ы.";
                        break;
                    default:
                        textStatus = $"Компания. {ex.Status}. {ex.Message}";
                        break;
                }
            }
            else if (typeT == typeof(Personal))
            {
                switch (webResponse.StatusCode)
                {
                    case HttpStatusCode.BadRequest:
                        textStatus = "Ошибка в параметре ФИО.";
                        break;
                    case HttpStatusCode.Forbidden:
                        textStatus = "Некорректный api-ключ.";
                        break;
                    case HttpStatusCode.NotFound:
                        textStatus = "Персональная информация не найдена.";
                        break;
                    default:
                        textStatus = $"Персональная информация. {ex.Status}. {ex.Message}";
                        break;
                }
            }

            SetError($"Ошибка получения информации.\n{textStatus}");
        }

        #endregion

    }
}
