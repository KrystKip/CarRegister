using System;

namespace Car_Register.Models
{
    public class ElectricCar : Car
    {
        public ElectricCar(string brand, string model, int year, int batteryCapacity) : base(brand, model, year)
        {
            BatteryCapacity = batteryCapacity;
        }

        public int BatteryCapacity { get; set; }

        public override void Info()
        {
            base.Info();
            Console.Write($"battery Capacity: {BatteryCapacity}");
        }
    }
}
