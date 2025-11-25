using System;
using System.Collections.Generic;
using Car_Register.Models;

namespace Car_Register.Services
{
    internal class MenuService
    {
        private readonly CarRepository _carRepository;
        private readonly FileService _fileService;
        private readonly List<Car> _cars;

        public MenuService(CarRepository carRepository, FileService fileService, List<Car> cars)
        {
            _carRepository = carRepository;
            _fileService = fileService;
            _cars = cars;
        }

        public void Run()
        {
            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine("==== Car Register Menu ====");
                Console.WriteLine("Choose your option:");
                Console.WriteLine("1. Add car");
                Console.WriteLine("2. Remove Car");
                Console.WriteLine("3. Show all cars");
                Console.WriteLine("4. Save to file");
                Console.WriteLine("5. Read file");
                Console.WriteLine("6. Sort cars by year");
                Console.WriteLine("7. Sort cars by brand");
                Console.WriteLine("8. Edit Car");
                Console.WriteLine("9. Exit");
                Console.WriteLine("Choose option (1-8)");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        _carRepository.AddCar(_cars);
                        break;
                    case "2":
                        _carRepository.RemoveCar(_cars);
                        break;
                    case "3":
                        _carRepository.ShowCars(_cars);
                        break;
                    case "4":
                        _fileService.SaveCarsToFile(_cars);
                        break;
                    case "5":
                        _fileService.ShowFileContents(_cars);
                        break;
                    case "6":
                        _carRepository.SortCarsByYear(_cars);
                        break;
                    case "7":
                        _carRepository.SortCarsByBrand(_cars);
                        break;
                    case "8":
                        _carRepository.EditCar(_cars);
                        break;
                    case "9":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }

                if (running)
                {
                    Console.WriteLine("Press any key to return to menu...");
                    Console.ReadKey();
                }
            }
        }
    }
}
