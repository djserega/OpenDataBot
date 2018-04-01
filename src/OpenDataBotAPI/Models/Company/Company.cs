using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace OpenDataBotAPI
{
    [Guid("65644E49-712B-4DFB-B9A0-ABBE9F140333")]
    [ClassInterface(ClassInterfaceType.None)]
    [ComSourceInterfaces(typeof(ICompany))]
    public class Company : ICompany
    {
        public string Full_name { get; set; }
        public string Short_name { get; set; }
        public string Code { get; set; }
        public string Ceo_name { get; set; }
        public string Location { get; set; }
        public string Activities { get; set; }
        public string Status { get; set; }

        public IBeneficiaries Beneficiarie { get; set; }

        public Beneficiaries[] Beneficiaries
        {
            set
            {
                _listBeneficiaries.Clear();
                if (value != null)
                    foreach (Beneficiaries item in value)
                        _listBeneficiaries.Add(item);
            }
        }
        private List<Beneficiaries> _listBeneficiaries = new List<Beneficiaries>();
        private int _beneficiariesIndex;
        public int BeneficiariesCount { get { return _listBeneficiaries.Count(); } }
        public int BeneficiariesIndex
        {
            get { return _beneficiariesIndex; }
            set
            {
                if (value < 0)
                    _beneficiariesIndex = 0;
                else if (value > BeneficiariesCount - 1)
                    _beneficiariesIndex = BeneficiariesCount;
                else
                    _beneficiariesIndex = value;
            }
        }
        public bool NextBeneficiarie()
        {
            if (_beneficiariesIndex < 0
                || _beneficiariesIndex > BeneficiariesCount - 1)
            {
                _beneficiariesIndex = 0;
                Beneficiarie = null;
                return false;
            }

            Beneficiarie = _listBeneficiaries[_beneficiariesIndex];
            _beneficiariesIndex++;
            return true;
        }

    }
}
