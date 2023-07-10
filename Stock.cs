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

        public bool ContainseDetail(string name)
        {
            Cell cell = FindDetail(name);

            return cell != null && cell.CountDetail > 0;
        }

        public Detail PickDetail(string name)
        {
            return FindDetail(name).GiveDetail();
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
