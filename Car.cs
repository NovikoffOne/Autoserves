using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autoserves
{
    class Car
    {
        private const string BaseBrand = "brand";
        private const string BaseModel = "model";

        public string Brand { get; private set; }
        
        public string Model { get; private set; }

        public Detail BreakingDetail { get; private set; }

        public Car(Detail breaking, string brand = BaseBrand, string model = BaseModel)
        {
            BreakingDetail = breaking;
            Brand = brand;
            Model = model;
        }

        public bool TryRepair(Detail detail)
        {
            if(detail != null)
            {
                BreakingDetail = detail;

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
