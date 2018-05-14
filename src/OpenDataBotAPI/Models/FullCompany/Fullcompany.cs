using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace OpenDataBotAPI
{
    [Guid("81FA0CBD-B71A-4A72-95D8-D8698A201BD6")]
    [ClassInterface(ClassInterfaceType.None)]
    [ComSourceInterfaces(typeof(IFullCompany))]
    public class FullCompany : BaseCompany, IFullCompany
    {
        public string Email { get; set; }
        public DateTime Registration_date { get; set; }
        public long Capital { get; set; }

        public IHeads CurrentHeads { get; set; }
        public Heads[] Heads
        {
            set
            {
                _listHeads.Clear();
                if (value != null)
                    foreach (Heads item in value)
                        _listHeads.Add(item);
            }
        }
        private List<Heads> _listHeads = new List<Heads>();
        private int _headsIndex;
        public int HeadsCount { get { return _listHeads.Count; } }
        public int HeadsIndex
        {
            get { return _headsIndex; }
            set
            {
                if (value < 0)
                    _headsIndex = 0;
                else if (value > HeadsCount - 1)
                    _headsIndex = HeadsCount;
                else
                    _headsIndex = value;
            }
        }
        public bool NextHeads()
        {
            if (_headsIndex < 0
                || _headsIndex > HeadsCount - 1)
            {
                _headsIndex = 0;
                CurrentHeads = null;
                return false;
            }

            CurrentHeads = _listHeads[_headsIndex];
            _headsIndex++;
            return true;
        }

        public IFullCompanyActivities CurrentActivities { get; set; }
        public FullCompanyActivities[] Activities
        {
            set
            {
                _listActivities.Clear();
                if (value != null)
                    foreach (FullCompanyActivities item in value)
                        _listActivities.Add(item);
            }
        }
        private List<FullCompanyActivities> _listActivities = new List<FullCompanyActivities>();
        private int _activitiesIndex;
        public int ActivitiesCount { get { return _listActivities.Count; } }
        public int ActivitiesIndex
        {
            get { return _activitiesIndex; }
            set
            {
                if (value < 0)
                    _activitiesIndex = 0;
                else if (value > ActivitiesIndex - 1)
                    _activitiesIndex = ActivitiesCount;
                else
                    _activitiesIndex = value;
            }
        }
        public bool NextActivities()
        {
            if (_activitiesIndex < 0
                || _activitiesIndex > ActivitiesIndex - 1)
            {
                _activitiesIndex = 0;
                CurrentActivities = null;
                return false;
            }

            CurrentActivities = _listActivities[_activitiesIndex];
            _activitiesIndex++;
            return true;
        }

        public DateTime Last_time { get; set; }
        public string Phones { get; set; }

        public IFullCompanyBeneficiares CurrentBeneficiaries { get; set; }
        public FullCompanyBeneficiares[] Beneficiaries
        {
            set
            {
                _listBeneficiaries.Clear();
                if (value != null)
                    foreach (FullCompanyBeneficiares item in value)
                        _listBeneficiaries.Add(item);
            }
        }
        private List<FullCompanyBeneficiares> _listBeneficiaries = new List<FullCompanyBeneficiares>();
        private int _beneficiariesIndex;
        public int BeneficiariesCount { get { return _listBeneficiaries.Count; } }
        public int BeneficiariesIndex
        {
            get { return _beneficiariesIndex; }
            set
            {
                if (value < 0)
                    _beneficiariesIndex = 0;
                if (value > _beneficiariesIndex - 1)
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
        public int HistoryCount { get { return _listHistory.Count; } }
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

    }
}
