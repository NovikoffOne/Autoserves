using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

namespace Autoserves
{
    class Stock
    {
        private Dictionary<Detail, int> _details = new Dictionary<Detail, int>();

        public Stock(Dictionary<Detail, int> details)
        {
            _details = details;
        }

        public bool CheckDetailAvailability(string nameDetail)
        {
            Detail detail = GetDetail(nameDetail);

            if (detail != null && _details[detail] > 0)
                return true;
            else
                return false;
        }

        public Detail PickDetail(string detailName)
        {
            Detail detail = GetDetail(detailName);

            _details[detail] -= 1;

            return detail;
        }

        private Detail GetDetail(string nameDetail)
        {
            foreach (var detail in _details)
            {
                if (detail.Key.Name == nameDetail && detail.Value > 0)
                {
                    return detail.Key;
                }
            }

            return null;
        }
    }
}
