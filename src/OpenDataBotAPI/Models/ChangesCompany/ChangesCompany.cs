using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace OpenDataBotAPI
{
    [Guid("C4431DCC-64AA-41CF-8E3A-1BFBB132F795")]
    [ClassInterface(ClassInterfaceType.None)]
    [ComSourceInterfaces(typeof(IFop))]
    public class ChangesCompany : IChangesCompany
    {
        public string Code { get; set; }

        public IChangeItem Item { get; set; }
        public ChangeItem[] Items
        {
            set
            {
                _listItems.Clear();
                if (value != null)
                    foreach (ChangeItem item in value)
                        _listItems.Add(item);
            }
        }
        private List<ChangeItem> _listItems = new List<ChangeItem>();
        private int _itemIndex;
        public int ItemCount { get { return _listItems.Count(); } }
        public int ItemIndex
        {
            get { return _itemIndex; }
            set
            {
                if (value < 0)
                    _itemIndex = 0;
                else if (value > ItemCount - 1)
                    _itemIndex = ItemCount;
                else
                    _itemIndex = value;
            }
        }
        public bool NextItem()
        {
            if (_itemIndex < 0
                || _itemIndex > ItemCount - 1)
            {
                _itemIndex = 0;
                Item = null;
                return false;
            }

            Item = _listItems[_itemIndex];
            _itemIndex++;
            return true;
        }
    }
}
