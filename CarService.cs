using System;
using System.Collections.Generic;

namespace Autoserves
{
    class CarService
    {
        #region ConstString
        private const string RepairText = "Деталь заменена";
        private const string NoRepairText = "Деталь не заменена заменена";

        private const string EngineDetailName = "Двигатель";
        private const string WheelDetailName = "Колесо";
        private const string SteeringWheelDetailName = "Руль";
        private const string SuspensionDetailName = "Подвеска";
        #endregion

        private Dictionary<string, int> _priceListWorking  = new Dictionary<string, int>();
        private Dictionary<string, int> _priceListDeteil  = new Dictionary<string, int>();

        private Stock _stock;

        private int _balance = 10000;
        private int _repairPriceCar = 0;
        private int _flne = 1999;

        public CarService(Stock stock, int balance = 0)
        {
            _balance = balance;
            _stock = stock;

            _priceListDeteil[EngineDetailName] = 50000;
            _priceListDeteil[WheelDetailName] = 10000;
            _priceListDeteil[SteeringWheelDetailName] = 8000;
            _priceListDeteil[SuspensionDetailName] = 80000;

            _priceListWorking[EngineDetailName] = 30000;
            _priceListWorking[WheelDetailName] = 2000;
            _priceListWorking[SteeringWheelDetailName] = 3000;
            _priceListWorking[SuspensionDetailName] = 50000;
        }

        public Car DetectBreaking(Car car)
        {
            string brekingDetailName = car.BreakingDetail.Name;

            Console.WriteLine($"{brekingDetailName} - неисправен.");

            if (_stock.CheckDetailAvailability(brekingDetailName) == true)
            {
                _repairPriceCar = CalculatePriceRepair(_priceListDeteil[brekingDetailName], _priceListWorking[brekingDetailName]);

                Console.WriteLine($"Цена ремонта : {_repairPriceCar}");

                return car;
            }
            else
            {
                Console.WriteLine("Мы не сможем починить ваш автомобиль");

                Flne();

                return null;
            }
        }

        public void ReplacePart(Car car)
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
