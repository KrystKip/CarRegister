using System;

namespace Car_Register.Models
{
    public class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }

        public static int amountOfCars;

        public Car(string brand, string model, int year)
        {
            this.Model = model;
            this.Brand = brand;
            this.Year = year;
            amountOfCars++;
        }

        public virtual void Info()
        {
            Console.Write($"Brand: {Brand}, Model: {Model}, Year: {Year} ");
        }

    }
}
