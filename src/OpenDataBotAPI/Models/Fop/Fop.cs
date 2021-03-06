﻿using System;
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

        public Tax_debts Tax_debts { get; set; }
    }
}
