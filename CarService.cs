using System;

namespace Autoserves
{
    class CarService
    {
        private const string RepairText = "Деталь заменена";
        private const string NoRepairText = "Деталь не заменена заменена";

        private Stock _stock;

        private Price _workPrice = new WorkPrice();
        private Price _detailPrice = new DetailPrice();

        private int _balance;
        private int _repairPriceCar = 0;
        private int _flne = 1999;

        public CarService(Stock stock, int balance = 0)
        {
            _balance = balance;
            _stock = stock;
        }

        public void DetectBreaking(ref Car car)
        {
            string brekingDetailName = car.BreakingDetail.Name;

            Console.WriteLine($"{brekingDetailName} - неисправен.");

            if (_stock.TryDetailAvailability(brekingDetailName) == true)
            {
                _repairPriceCar = CalculatePriceRepair(_detailPrice.GetPrice(brekingDetailName), _workPrice.GetPrice(brekingDetailName));

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
