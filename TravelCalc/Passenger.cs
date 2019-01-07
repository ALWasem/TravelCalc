using System;

namespace TravelCalc
{
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
}
