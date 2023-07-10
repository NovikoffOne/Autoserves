using System;
using System.Collections.Generic;

namespace Autoserves
{
    class CarService
    {
        private const string RepairText = "Деталь заменена";
        private const string NoRepairText = "Деталь не заменена заменена";

        private const string EngineDetailName = "Двигатель";
        private const string WheelDetailName = "Колесо";
        private const string SteeringWheelDetailName = "Руль";
        private const string SuspensionDetailName = "Подвеска";

        private Stock _stock;
        private List<DetailInfo> _detailInfos;

        private int _balance;
        private int _repairPriceCar = 0;
        private int _flne = 1999;

        public CarService(Stock stock, int balance = 0, List<DetailInfo> detailInfos = null)
        {
            _balance = balance;
            _stock = stock;

            if(detailInfos == null)
            {
                _detailInfos = new List<DetailInfo>();
                _detailInfos.Add(new DetailInfo(new Detail(EngineDetailName), 30000, 50000));
                _detailInfos.Add(new DetailInfo(new Detail(WheelDetailName), 2000, 3000));
                _detailInfos.Add(new DetailInfo(new Detail(SteeringWheelDetailName), 3000, 4000));
                _detailInfos.Add(new DetailInfo(new Detail(SuspensionDetailName), 50000, 45000));
            }
        }

        public void DetectBreaking(Car car)
        {
            string brekingDetailName = car.FindBreakingDetail().Name;

            Console.WriteLine($"{brekingDetailName} - неисправен.");

            if (_stock.ContainseDetail(brekingDetailName) == true)
            {
                _repairPriceCar = GetRepairPrice(_detailInfos, brekingDetailName);

                Console.WriteLine($"Цена ремонта : {_repairPriceCar}");

                ReplacePart(car);
            }
            else
            {
                Console.WriteLine("Мы не сможем починить ваш автомобиль");

                PayFlne();
            }
        }

        private void ReplacePart(Car car)
        {
            Detail newDetail = _stock.PickDetail(car.FindBreakingDetail().Name);

            if (car.TryRepair(newDetail))
            {
                Console.WriteLine(RepairText);
                TakePayment(_repairPriceCar);
            }
            else
            {
                Console.WriteLine(NoRepairText);
                PayFlne();
            }
        }

        private void PayFlne()
        {
            _balance -= _flne;

            Console.WriteLine("Баланс : " + _balance);
        }

        private int CalculatePriceRepair(int detailPrice, int workingPrice)
        {
            return detailPrice + workingPrice;
        }

        private int GetRepairPrice(List<DetailInfo> detailInfos, string detailName)
        {
            foreach (var detail in detailInfos)
            {
                if (detail.Name == detailName)
                {
                    return CalculatePriceRepair(detail.Price, detail.WorkPrice);
                }
            }

            return 0;
        }

        private void TakePayment(int price)
        {
            if (price > 0)
                _balance += price;

            Console.WriteLine("Баланс : " + _balance);
        }
    }
}
