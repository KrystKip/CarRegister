using System;
using System.Collections.Generic;
using System.Linq;
using Car_Register.Models;

namespace Car_Register.Services
{
    internal class CarRepository
    {
        public void StartListOfCars(List<Car> cars)  // list of cars to make list not empty at the start of the program
        {
            #region List cars
            cars.Add(new Car("Audi", "A4", 2014));
            cars.Add(new Car("Toyota", "Yaris2", 2012));
            cars.Add(new Car("Citroen", "C4", 2011));
            cars.Add(new Car("Citroen", "C4", 2018));
            cars.Add(new Car("Toyota", "Yaris", 2020));
            cars.Add(new ElectricCar("Audi", "A6", 2018, 100));
            #endregion
        }

        public void AddCar(List<Car> cars)  // add car to list
        {
            InputHelper inputHelper = new InputHelper();    // object that validates input
            int numExit = 0;
            do
            {
                Console.WriteLine("Choose which car do you want to add. Write number");
                Console.WriteLine("1. Electric Car");
                Console.WriteLine("2. Gasoline Car");

                // checking if user gave proper answer
                bool check;
                int number;
                Console.WriteLine("Write number 1 or 2");
                do
                {
                    check = int.TryParse(Console.ReadLine(), out number);
                    if (check == false)
                    {
                        Console.WriteLine("This isn't number");
                    }
                    else if (number != 1 && number != 2)
                    {
                        Console.WriteLine("Choose between 1 (Electric Car) or 2 (Gasoline Car)");
                    }
                }
                while (check == false || (number != 1 && number != 2));

                // adding new car. User writes all variables
                if (number == 2)
                {
                    string Brand = inputHelper.GetValidString("Write Brand: ");
                    string Model = inputHelper.GetValidString("Write Model:");
                    int Year = inputHelper.GetValidInt("Write Year:");
                    cars.Add(new Car(Brand, Model, Year));
                }
                else if (number == 1)
                {
                    string Brand = inputHelper.GetValidString("Write Brand: ");
                    string Model = inputHelper.GetValidString("Write Model:");
                    int Year = inputHelper.GetValidInt("Write Year:");
                    int BatteryCapacity = inputHelper.GetValidInt("Write BatteryCapacity");
                    cars.Add(new ElectricCar(Brand, Model, Year, BatteryCapacity));
                }
                numExit = inputHelper.GetValidNum("Do you want to add more cars? \n Yes = 1 ------  No = 2"); // checking if user wants to add more
            }
            while (numExit != 2);
        }

        public void RemoveCar(List<Car> cars)  // delete car from list
        {
            // Shows all then you can check which one you want to remove
            int i = 0;
            foreach (Car car in cars)
            {
                i++;
                Console.Write($"Car number: ({i})   ");
                car.Info();
                Console.WriteLine();
            }

            // Checking if proper number is given 
            bool check;
            int number;

            int amountOfCars = cars.Count;
            List<int> carNumbers = Enumerable.Range(1, amountOfCars).ToList();
            do
            {
                Console.WriteLine("Write number of car that you want to remove");
                check = int.TryParse(Console.ReadLine(), out number);
                if (check == false)
                {
                    Console.WriteLine("Write proper number");
                }
                else if (!carNumbers.Contains(number))
                {
                    Console.WriteLine($"Write number from {1} to {amountOfCars}");
                }
            }
            while (check == false || (!carNumbers.Contains(number)));
            cars.Remove(cars[number - 1]);

            Console.WriteLine("Car removed successfully");
        }

        public void EditCar(List<Car> cars)
        {
            InputHelper inputHelper = new InputHelper();
            int i = 0;
            foreach (Car car1 in cars)
            {
                i++;
                Console.Write($"Car number: ({i})   ");
                car1.Info();
                Console.WriteLine();
            }
            int idx = inputHelper.GetValidInt("Enter car number to edit:") - 1;
            if (idx < 0 || idx >= cars.Count) { Console.WriteLine("Invalid number"); return; }

            var car = cars[idx];
            string brand = inputHelper.GetValidString($"Brand ({car.Brand}):");
            string model = inputHelper.GetValidString($"Model ({car.Model}):");
            int year = inputHelper.GetValidInt($"Year ({car.Year}):");

            car.Brand = brand;
            car.Model = model;
            car.Year = year;

            if (car is ElectricCar eCar)
            {
                eCar.BatteryCapacity = inputHelper.GetValidInt($"BatteryCapacity ({eCar.BatteryCapacity}):");
            }
        }

        public void ShowCars(List<Car> cars)   // shows all cars from the list
        {
            if (cars.Count == 0)
            {
                Console.WriteLine("No cars in the list");
            }
            else
            {
                Console.WriteLine("List of cars:");
                foreach (Car car in cars)
                {
                    car.Info();
                    Console.WriteLine();
                }
            }
        }

        public void SortCarsByBrand(List<Car> cars)  // sort Car by Brand
        {
            cars.Sort((a, b) => a.Brand.CompareTo(b.Brand));
            Console.WriteLine("Cars sorted by Brand");
        }

        public void SortCarsByYear(List<Car> cars)
        {
            cars.Sort((a, b) => a.Year.CompareTo(b.Year));
            Console.WriteLine("Cars sorted by Year");
        }
    }
}
