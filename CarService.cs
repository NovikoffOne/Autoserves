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

        private Dictionary<string, int> _detailPrice;

        private int _balance;
        private int _repairPriceCar = 0;
        private int _flne = 1999;
        private int _workPrice = 5000;

        public CarService(Stock stock, int balance = 0, Dictionary<string, int> detailPrice = null)
        {
            _balance = balance;
            _stock = stock;

            if(detailPrice == null)
            {
                _detailPrice = new Dictionary<string, int>();
                _detailPrice[EngineDetailName] = 30000;
                _detailPrice[WheelDetailName] = 2000;
                _detailPrice[SteeringWheelDetailName] = 3000;
                _detailPrice[SuspensionDetailName] = 50000;
            }
        }

        public void DetectBreaking(ref Car car)
        {
            string brekingDetailName = car.BreakingDetail.Name;

            Console.WriteLine($"{brekingDetailName} - неисправен.");

            if (_stock.TryDetailAvailability(brekingDetailName) == true)
            {
                _repairPriceCar = CalculatePriceRepair(_detailPrice[brekingDetailName], _workPrice);

                Console.WriteLine($"Цена ремонта : {_repairPriceCar}");

                ReplacePart(car);
            }
            else
            {
                Console.WriteLine("Мы не сможем починить ваш автомобиль");

                Flne();
            }
        }

        private void ReplacePart(Car car)
        {
            Detail newDetail = _stock.PickDetail(car.BreakingDetail.Name);

            if (car.TryRepair(newDetail))
            {
                Console.WriteLine(RepairText);
                TakePayment(_repairPriceCar);
            }
            else
            {
                Console.WriteLine(NoRepairText);
                Flne();
            }
        }

        private void Flne()
        {
            _balance -= _flne;

            Console.WriteLine("Баланс : " + _balance);
        }

        private int CalculatePriceRepair(int detailPrice, int workingPrice)
        {
            return detailPrice + workingPrice;
        }

        private void TakePayment(int price)
        {
            if (price > 0)
                _balance += price;

            Console.WriteLine("Баланс : " + _balance);
        }
    }
}
