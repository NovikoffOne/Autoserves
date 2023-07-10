using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

        public Detail GiveDetail()
        {
            if (CountDetail > 0)
            {
                CountDetail--;

                return Detail;
            }

            return null;
        }
    }
}
