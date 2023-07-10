using System.Collections.Generic;

namespace Autoserves
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Cell> cells = new List<Cell>();
            cells.Add(new Cell(new Detail("Двигатель"), 5));
            cells.Add(new Cell(new Detail("Колесо"), 18));
            cells.Add(new Cell(new Detail("Руль"), 9));
            cells.Add(new Cell(new Detail("Подвеска"), 2));

            Queue<Car> cars = new Queue<Car>();
            cars.Enqueue(new Car(new Detail(name: "Подвеска", state: "Old")));
            cars.Enqueue(new Car(new Detail(name: "Подвеска", state: "Old")));
            cars.Enqueue(new Car(new Detail(name: "Подвеска", state: "Old")));
            cars.Enqueue(new Car(new Detail(name: "Двигатель", state: "Old")));
            cars.Enqueue(new Car(new Detail(name: "Колесо", state: "Old")));
            cars.Enqueue(new Car(new Detail(name: "Руль", state: "Old")));

            Stock stock = new Stock(cells);

            CarService carService = new CarService(stock, 20000);

            while (cars.Count > 0)
            {
                Car currentCar = cars.Dequeue();

                carService.DetectBreaking(currentCar);
            }
        }
    }
}
