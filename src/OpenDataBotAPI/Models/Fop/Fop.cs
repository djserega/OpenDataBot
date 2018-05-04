using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace OpenDataBotAPI
{
    [Guid("4D983636-A648-4218-A333-380D9E7A3E21")]
    [ClassInterface(ClassInterfaceType.None)]
    [ComSourceInterfaces(typeof(IFop))]
    public class Fop : IFop
    {
        public string Code { get; set; }
        public string Full_name { get; set; }
        public string Location { get; set; }
        public string Status { get; set; }
        public string[] Phones { get; set; }
        public string Email { get; set; }
        public DateTime Registration_date { get; set; }
        public DateTime Last_date { get; set; }
        public DateTime Birth_date { get; set; }
        public string Activities { get; set; }
        public string Pdv_code { get; set; }
        public string Pdv_status { get; set; }

        public Sex Sex { get; set; }

        public string[] Additionally_activities { get; set; }

        public IChangeItem CurrentHistory { get; set; }
        public ChangeItem[] History
        {
            set
            {
                _listHistory.Clear();
                if (value != null)
                    foreach (ChangeItem item in value)
                        _listHistory.Add(item);
            }
        }
        private List<ChangeItem> _listHistory = new List<ChangeItem>();
        private int _historyIndex;
        public int HistoryCount { get { return _listHistory.Count(); } }
        public int HistoryIndex
        {
            get { return _historyIndex; }
            set
            {
                if (value < 0)
                    _historyIndex = 0;
                else if (value > HistoryCount - 1)
                    _historyIndex = HistoryCount;
                else
                    _historyIndex = value;
            }
        }
        public bool NextHistory()
        {
            if (_historyIndex < 0
                || _historyIndex > HistoryCount - 1)
            {
                _historyIndex = 0;
                CurrentHistory = null;
                return false;
            }

            CurrentHistory = _listHistory[_historyIndex];
            _historyIndex++;
            return true;
        }

        public ITax_debts CurrentTax_debts { get; set; }
        public Tax_debts[] Tax_debts 
        {
            set
            {
                _listTax_debts.Clear();
                if (value != null)
                    foreach (Tax_debts item in value)
                        _listTax_debts.Add(item);
            }
        }
        private List<Tax_debts> _listTax_debts = new List<Tax_debts>();
        private int _tax_debtsIndex;
        public int Tax_debtsCount { get { return _listTax_debts.Count(); } }
        public int Tax_debtsIndex
        {
            get { return _tax_debtsIndex; }
            set
            {
                if (value < 0)
                    _tax_debtsIndex = 0;
                else if (value > Tax_debtsCount - 1)
                    _tax_debtsIndex = Tax_debtsCount;
                else
                    _tax_debtsIndex = value;
            }
        }
        public bool NextTax_debts()
        {
            if (_tax_debtsIndex < 0
                || _tax_debtsIndex > Tax_debtsCount - 1)
            {
                _tax_debtsIndex = 0;
                CurrentTax_debts = null;
                return false;
            }

            CurrentTax_debts = _listTax_debts[_tax_debtsIndex];
            _tax_debtsIndex++;
            return true;
        }
    }
}
