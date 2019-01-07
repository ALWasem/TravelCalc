using System;

namespace TravelCalc
{
    public class Vehicle
    {

        static public enum VehicleType { Car, Train, Plane }



        public Vehicle(VehicleType type, int capcity)
        {
            Type = type;
            Capacity = capacity;

            if (type = VehicleType.Car)
            {
                StartUpCost = 0;
                CostPerMile = 0.608;
            }
            else if (type = VehicleType.Train)
            {
                StartUpCost = 10;
                CostPerMile = 0.50;
            }
            else if (type = VehicleType.Plane)
            {
                StartUpCost = 50;
                CostPerMile = 0.11;
            }

        }

        public VehicleType Type { get; set; }
        public float CostPerMile { get; set; }
        public float StartUpCost { get; set; }
        public int Capacity { get; set; }
        public List<Passenger> Passengers { get; set; }
        public List<Trip> Trips { get; set; }

    }
}