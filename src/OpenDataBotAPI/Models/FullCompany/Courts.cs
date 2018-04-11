﻿using System;
using System.Collections.Generic;

namespace OpenDataBotAPI
{
    public class Courts : ICourts
    {
        public string Text { get; set; }
        public string Icon { get; set; }
        public string Value { get; set; }
        public DateTime Database_Date { get; set; }
                                     
        public IDecision CurrentDecision { get; set; }
        public Decision[] Decisions
        {
            set
            {
                _listDecision.Clear();
                if (value != null)
                    foreach (Decision item in value)
                        _listDecision.Add(item);
            }
        }
        private List<Decision> _listDecision = new List<Decision>();
        private int _decisionIndex;
        public int DecisionCount { get { return _listDecision.Count; } }
        public int DecisionIndex
        {
            get { return _decisionIndex; }
            set
            {
                if (value < 0)
                    _decisionIndex = 0;
                else if (value > DecisionCount - 1)
                    _decisionIndex = DecisionCount;
                else
                    _decisionIndex = value;
            }
        }
        public bool NextDecision()
        {
            if (_decisionIndex < 0
                || _decisionIndex > DecisionCount - 1)
            {
                _decisionIndex = 0;
                CurrentDecision = null;
                return false;
            }

            CurrentDecision = _listDecision[_decisionIndex];
            _decisionIndex++;
            return true;
        }
    }

}
