# CarRegister# Car Register

Simple console application in C# (.NET) for managing a list of cars.  
Supports basic CRUD operations, saving to and reading from a CSV file, sorting, and handling electric cars.

## Project Structure

- `Car_Register.sln` – Visual Studio solution file.
- `Car_Register/` – main project folder
  - `Models/`
    - `Car.cs` – base car class (Brand, Model, Year)
    - `ElectricCar.cs` – electric car inherits from Car (adds BatteryCapacity)
  - `Services/`
    - `CarRepository.cs` – methods to add, remove, edit, show and sort cars
    - `FileService.cs` – save and read cars to/from CSV
    - `InputHelper.cs` – input validation helpers
    - `MenuService.cs` – console menu and interaction loop
  - `Program.cs` – application entry point, composes services and runs the menu

## Features

- Add gasoline and electric cars
- Remove cars by index
- Edit car properties (brand, model, year, battery capacity for electric cars)
- Show all cars
- Save list to CSV (`file.csv`)
- Read list from CSV
- Sort cars by brand or year
- Input validation for user prompts

## How to run

Requires .NET SDK (6.0 or newer recommended).

From project root:
```bash
cd CarRegister/Car_Register    # path to the project folder (where .csproj is)
dotnet run
