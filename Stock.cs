using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.SymbolStore;

namespace Autoserves
{
    class Stock
    {
        private List<Cell> _cells;

        public Stock(List<Cell> cells = null)
        {
            if (cells != null)
                _cells = cells;
            else
                _cells = new List<Cell>();
        }

        public bool TryDetailAvailability(string name)
        {
            Cell cell = FindDetail(name);

            if (cell != null && cell.CountDetail > 0)
                return true;

            return false;
        }

        public Detail PickDetail(string name, int count = 1)
        {
            return FindDetail(name).GetDetail(count);
        }

        private Cell FindDetail(string name)
        {
            foreach(var cell in _cells)
            {
                if (cell.Detail.Name == name)
                    return cell;
            }

            return null;
        }
    }
}
