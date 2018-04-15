using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace OpenDataBotAPI
{
    [Guid("0AAF4C7A-FE36-402C-A5E8-7A800FA39201")]
    public interface IAPI_20
    {
        string APIKey { set; }
        bool APIKeyIsSet { get; }

        bool Error { get; }
        string ErrorText { get; }

        Fop Fop { get; }
        Company Company { get; }
        int CompanyCount { get; }
        int CompanyIndex { get; set; }
        FullCompany FullCompany { get; }
        ChangesCompany CurrentChanges { get; }
        Personal Personal { get; }


        void GetFop(string code);
        void GetCompany(string code);
        void GetFullCompany(string code);
        void GetChanges(string code);
        void GetPersonalInfo(string pib);

        bool NextCompany();
    }
}