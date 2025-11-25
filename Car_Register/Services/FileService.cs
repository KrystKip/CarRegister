using System;
using System.IO;
using System.Collections.Generic;
using Car_Register.Models;

namespace Car_Register.Services
{
    public class FileService
    {
        private readonly string _path = Path.Combine(Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName,"file.csv");

        public void SaveCarsToFile(List<Car> cars) // save list of cars to csv file
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(_path))
                {
                    sw.WriteLine("Marka;Model;Rok;BatteryCapacity");
                    foreach (Car car in cars)
                    {
                        if (car is ElectricCar eCar)
                        {
                            sw.WriteLine($"{eCar.Brand};{eCar.Model};{eCar.Year};{eCar.BatteryCapacity}");
                        }
                        else
                        {
                            sw.WriteLine($"{car.Brand};{car.Model};{car.Year};{0}");
                        }
                    }
                }
                Console.WriteLine("File was saved successfully");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("No access to save file in this location");
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("Folder path not found");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"A file write error occurred: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }
        }

        public void ShowFileContents(List<Car> cars)  // show list of cars that was saved to csv file and load into list
        {
            try
            {
                if (!File.Exists(_path))
                {
                    Console.WriteLine("File doesn't exist.");
                    return;
                }

                cars.Clear();

                using (StreamReader sr = new StreamReader(_path))
                {
                    string header = sr.ReadLine(); // skip first line (header)
                    string line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] parts = line.Split(';');   // divides line into parts (brand, model, year, batterycapacity)

                        if (parts.Length == 4)          // protect from malformed lines
                        {
                            string brand = parts[0].Trim();
                            string model = parts[1].Trim();
                            if (!int.TryParse(parts[2], out int year))
                            {
                                // log or skip line
                                continue;
                            }
                            if (!int.TryParse(parts[3], out int battery))
                            {
                                battery = 0; // or continue
                            }

                            if (battery > 0)
                                cars.Add(new ElectricCar(brand, model, year, battery));
                            else
                                cars.Add(new Car(brand, model, year));
                        }
                    }
                }

                Console.WriteLine("File read successfully and cars added to list!");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("You don't have permission to read this file.");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"I/O error while reading file: {ex.Message}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid data format in file. Please check your CSV structure.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }
        }
    }
}
