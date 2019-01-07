using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using TravelCalc.Classes;

namespace TravelCalc
{

    public enum VehicleType { Car, Train, Plane }


    class Program
    {
        static List<Vehicle> Vehicles = new List<Vehicle>();
        static List<Passenger> Passengers = new List<Passenger>();
        static float travelDistanceFloat;
        static int passengerCountInt;
        static Vehicle TripVehicle = null;
        static float TravelCost;
        static float TravelTime;
        static float TotalFoodCost;

        static void Main(string[] args)
        {
            Intro();
            Setup();
            UserInput();
            Calculate();
        }

        private static void Intro()
        {
            Console.WriteLine("Welcome to TravelCalc.");
            Console.WriteLine("");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private static void Setup()
        {
            Vehicle Car = new Vehicle(VehicleType.Car, 5);
            Vehicle Train = new Vehicle(VehicleType.Train, 250);
            Vehicle Plane = new Vehicle(VehicleType.Plane, 100);
            Vehicles.Add(Car);
            Vehicles.Add(Train);
            Vehicles.Add(Plane);
            Console.WriteLine("");
        }

        private static void UserInput()
        {
            string travelDistance;            
            string vehicleType;
            string passengerCount;    

            //Accept Travel Distance From User
            do
            {
                Console.WriteLine("Enter travel distance : ");
                travelDistance = Console.ReadLine();
                float.TryParse(travelDistance,out travelDistanceFloat);
            }
            while(travelDistanceFloat == 0F);

            //Accept Vehicle Type From User
            do 
            {
                Console.WriteLine("Enter vehicle type (C = car / T = train / P = plane) : ");
                vehicleType = Console.ReadLine();
                if(vehicleType == "C")
                    TripVehicle = Vehicles[0];
                else if(vehicleType == "T")
                    TripVehicle = Vehicles[1];
                else if(vehicleType == "P")
                    TripVehicle = Vehicles[2];
            } 
            while(TripVehicle == null);
            
            //Accept Passenger Count From User
            do
            {
                Console.WriteLine("Enter amount of passengers going on trip : ");
                passengerCount = Console.ReadLine();
                int.TryParse(passengerCount,out passengerCountInt);
            }
            while(passengerCountInt == 0);

            //Passenger List
            for (int i = 0; i < passengerCountInt; i++)
			{
                Passengers.Add(new Passenger(10,""));
			}

            
        }

        private static void Calculate()
        {
            Trip trip = new Trip(travelDistanceFloat);

            TravelTime = trip.TravelDistance/TripVehicle.AvgSpeed;
            for (int i = 0; i < passengerCountInt; i++)
			{
                TotalFoodCost += (TravelTime/6)*Passengers[i].FoodCost;
			}

            TravelCost = (TripVehicle.StartUpCost*passengerCountInt) + (trip.TravelDistance*TripVehicle.CostPerMile*passengerCountInt) + TotalFoodCost;

            Console.WriteLine("Press Any Key To Find Your Total Trip Cost...");
            Console.ReadKey();
            Console.WriteLine($"{TravelCost.ToString()}");
            Console.WriteLine("Press Any Key To Exit...");
            Console.ReadKey();

        }



    }

    public class Vehicle
    {
        public Vehicle(VehicleType type, int capacity)
        {
            Type = type;
            Capacity = capacity;

            if (type == VehicleType.Car)
            {
                StartUpCost = 0F;
                CostPerMile = 0.22F;
                AvgSpeed = 60F;
            }
            else if (type == VehicleType.Train)
            {
                StartUpCost = 10F;
                CostPerMile = 0.50F;
                AvgSpeed = 68F;
            }
            else if (type == VehicleType.Plane)
            {
                StartUpCost = 50F;
                CostPerMile = 0.11F;
                AvgSpeed = 550F;
            }

        }

        public VehicleType Type { get; set; }
        public float CostPerMile { get; set; }
        public float StartUpCost { get; set; }
        public float AvgSpeed { get; set;}
        public int Capacity { get; set; }
        public List<Passenger> Passengers { get; set; }
        public List<Trip> Trips { get; set; }

    }

    public class Passenger
    {
        public Passenger(int foodcost, string name)
        {
            FoodCost = foodcost;
            Name = name;
        }

        public int FoodCost { get; set; }
        public string Name { get; set; }
    }

    public class Trip
    {
        public Trip(float traveldistance)
        {
            TravelDistance = traveldistance;
        }

        public float TravelDistance { get; set; }
    }

}
