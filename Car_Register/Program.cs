using System.Collections.Generic;
using Car_Register.Models;
using Car_Register.Services;

namespace Car_Register
{
    public class Program
    {
        static List<Car> cars = new List<Car>();

        static void Main(string[] args)
        {
            var carRepository = new CarRepository();
            var fileService = new FileService();
            var menuService = new MenuService(carRepository, fileService, cars);

            //carRepository.StartListOfCars(cars); // optionally preload sample cars

            menuService.Run();
        }
    }
}
