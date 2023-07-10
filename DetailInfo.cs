using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autoserves
{
    class DetailInfo
    {
        public DetailInfo(Detail detail, int price, int workPrice)
        {
            Detail = detail;
            Price = price;
            WorkPrice = workPrice;
        }

        public Detail Detail { get; private set; }

        public int Price { get; private set; }
        
        public int WorkPrice { get; private set; }
        
        public string Name => Detail.Name;
    }
}
