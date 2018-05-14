using System;

namespace OpenDataBotAPI
{
    [Guid("2472EC29-1843-4A9A-A664-95B2C6C24453")]
    [ClassInterface(ClassInterfaceType.None)]
    [ComSourceInterfaces(typeof(IChangeItem))]
    public class ChangeItem : IChangeItem
    {
        public DateTime Date { get; set; }

        public Changes CurrentChanges { get; set; }
        public Changes[] Changes
        {
            set
            {
                _listChanges.Clear();
                if (value != null)
                    foreach (Changes item in value)
                        _listChanges.Add(item);
            }
        }
        private List<Changes> _listChanges = new List<Changes>();
        private int _changesIndex;
        public int ChangesCount { get => _listChanges.Count; }
        public int ChangesIndex
        {
            get => _changesIndex;
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
                CurrentChanges = null;
                return false;
            }

            CurrentChanges = _listChanges[_changesIndex];
            _changesIndex++;
            return true;
        }
    }
}
