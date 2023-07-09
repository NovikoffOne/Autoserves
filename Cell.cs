using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autoserves
{
    class Cell
    {
        public Cell(Detail detail = null, int count = 0)
        {
            Detail = detail;
            CountDetail = count;
        }

        public Detail Detail { get; private set; }

        public int CountDetail { get; private set; }

        public Detail GetDetail(int count)
        {
            if ((CountDetail -= count) >= 0)
            {
                CountDetail -= count;

                return Detail;
            }

            return null;
        }
    }
}
