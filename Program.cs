using System.Collections.Generic;

namespace Autoserves
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<Detail, int> details = new Dictionary<Detail, int>();
            details[new Detail("Двигатель")] = 5;
            details[new Detail("Колесо")] = 18;
            details[new Detail("Руль")] = 9;
            details[new Detail("Подвеска")] = 2;

            Queue<Car> cars = new Queue<Car>();
            cars.Enqueue(new Car(new Detail(name: "Подвеска", state: "Old")));
            cars.Enqueue(new Car(new Detail(name: "Подвеска", state: "Old")));
            cars.Enqueue(new Car(new Detail(name: "Подвеска", state: "Old")));
            cars.Enqueue(new Car(new Detail(name: "Двигатель", state: "Old")));
            cars.Enqueue(new Car(new Detail(name: "Колесо", state: "Old")));
            cars.Enqueue(new Car(new Detail(name: "Руль", state: "Old")));

            Stock stock = new Stock(details);

            CarService carService = new CarService(stock, 20000);

            while (cars.Count > 0)
            {
                Car currentCar = carService.DetectBreaking(cars.Dequeue());

                if (currentCar != null)
                    carService.ReplacePart(currentCar);
            }
        }
    }
}
