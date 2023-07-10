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

        private List<Detail> _details = new List<Detail>();

        public Car(Detail breaking, string brand = BaseBrand, string model = BaseModel)
        {
            _details.Add(breaking);
            Brand = brand;
            Model = model;
        }

        public Detail BreakingDetail { get; private set; }

        public string Brand { get; private set; }

        public string Model { get; private set; }

        public bool TryRepair(Detail detail)
        {
            Detail brackingDetail = FindBreakingDetail();

            if (detail != null && brackingDetail.Name == detail.Name)
            {
                _details.Remove(brackingDetail);
                _details.Add(detail);

                return true;
            }
            else
            {
                return false;
            }
        }

        public Detail FindBreakingDetail()
        {
            foreach (var detail in _details)
            {
                if (detail.State == "Old")
                    return detail;
            }

            return null;
        }
    }
}
