﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Text.RegularExpressions;

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
                else if (value > _listCompany.Count - 1)
                    _companyIndex = _listCompany.Count;
                else
                    _companyIndex = value;
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


        public ChangesCompany CurrentChanges { get; private set; }
        public List<ChangesCompany> Changes { get; private set; }

        public void GetChanges(string code)
        {
            if (!CheckFilledAPIKey())
                return;

            InitializeHTTP();

            try
            {
                Changes = _http.GetInfos<ChangesCompany>(code);
                if (Changes.Count == 1)
                    CurrentChanges = Changes[0];
                else
                    CurrentChanges = null;
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
            if (typeT == typeof(Fop))
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
