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
    public class Company : BaseCompany, ICompany
    {
        public string Activities { get; set; }

        public IBeneficiariesCompany CurrentBeneficiaries { get; set; }
        public BeneficiariesCompany[] Beneficiaries
        {
            set
            {
                _listBeneficiaries.Clear();
                if (value != null)
                    foreach (BeneficiariesCompany item in value)
                        _listBeneficiaries.Add(item);
            }
        }
        private List<BeneficiariesCompany> _listBeneficiaries = new List<BeneficiariesCompany>();
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
        public bool NextBeneficiaries()
        {
            if (_beneficiariesIndex < 0
                || _beneficiariesIndex > BeneficiariesCount - 1)
            {
                _beneficiariesIndex = 0;
                CurrentBeneficiaries = null;
                return false;
            }

            CurrentBeneficiaries = _listBeneficiaries[_beneficiariesIndex];
            _beneficiariesIndex++;
            return true;
        }
    }
}
