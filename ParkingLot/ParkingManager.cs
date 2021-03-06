﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLot
{
    public class ParkingManager : ParkingBoy
    {
        private List<ParkingBoy> manageList = new List<ParkingBoy>();
        private Random rnd = new Random();
        private List<CarLot<string, Car>> managerLots = new List<CarLot<string, Car>>()
        {
            new CarLot<string, Car>(20),
        };
        public ParkingManager(string name) : base(name)
        {
        }

        public List<ParkingBoy> ManageList => manageList;

        public void HireBoy(ParkingBoy employee)
        {
            manageList.Add(employee);
        }

        public string ManagerPark(Car car, List<CarLot<string, Car>> parkingLots, out string parkMessage)
        {
            int assignIndex = rnd.Next(manageList.Count);
            return manageList[assignIndex].Park(car, parkingLots, out parkMessage);
        }

        public Car ManagerFetch(string ticket, List<CarLot<string, Car>> parkingLots, out string fetchMessage)
        {
            int assignIndex = rnd.Next(manageList.Count);
            return manageList[assignIndex].Fetch(ticket, parkingLots, out fetchMessage);
        }

        public string SelfPark(Car car, out string parkMessage)
        {
            return Park(car, managerLots, out parkMessage);
        }

        public Car SelfFetch(string ticket, out string fetchMessage)
        {
            return Fetch(ticket, managerLots, out fetchMessage);
        }
    }
}
