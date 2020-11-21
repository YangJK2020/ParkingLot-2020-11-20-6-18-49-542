﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLot
{
    public class ParkingBoy
    {
        private int parkingCapacity = 10;
        private int indexOfPlateNumber = 1;
        public string Park(Car car, Dictionary<string, Car> parkinglot)
        {
            if (parkinglot.Count < parkingCapacity && !parkinglot.ContainsKey(car.PlateNumber))
            {
                try
                {
                    parkinglot.Add(car.PlateNumber, car);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                return $"SuperPark: {car.PlateNumber}";
            }

            return null;
        }

        public string Park(Car car, Dictionary<string, Car> parkinglot, out string message)
        {
            if (parkinglot.Count < parkingCapacity && !parkinglot.ContainsKey(car.PlateNumber))
            {
                try
                {
                    parkinglot.Add(car.PlateNumber, car);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                message = "Your car is parked successfully";
                return $"SuperPark: {car.PlateNumber}";
            }

            message = "Not enough position.";
            return null;
        }

        public Car Fetch(string ticket, Dictionary<string, Car> parkinglot)
        {
            var plateNumber = ticket.Split(" ")[indexOfPlateNumber];
            if (parkinglot.ContainsKey(plateNumber))
            {
                var car = parkinglot[plateNumber];
                parkinglot.Remove(plateNumber);
                return car;
            }

            return null;
        }

        public Car Fetch(string ticket, Dictionary<string, Car> parkinglot, out string message)
        {
            var plateNumber = ticket.Split(" ")[indexOfPlateNumber];
            if (parkinglot.ContainsKey(plateNumber))
            {
                var car = parkinglot[plateNumber];
                parkinglot.Remove(plateNumber);
                message = "Here is your car";
                return car;
            }

            message = "Unrecognized parking ticket.";
            return null;
        }

        public Car Fetch(Dictionary<string, Car> parkinglot)
        {
            return null;
        }

        public Car Fetch(Dictionary<string, Car> parkinglot, out string message)
        {
            message = "Please provide your parking ticket.";
            return null;
        }
    }
}
