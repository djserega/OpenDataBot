using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace OpenDataBotAPI
{
    [Guid("0AAF4C7A-FE36-402C-A5E8-7A800FA39201")]
    public interface IAPI_20
    {
        string APIKey { get; set; }
        bool APIKeyIsSet { get; }

        bool Error { get; }
        string ErrorText { get; }

        Fop Fop { get; }
        Company Company { get; }
        Company[] Companys { get; }

        void GetFop(string code);
        void GetCompany(string code);
    }
}