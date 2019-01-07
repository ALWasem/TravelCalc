using System;


namespace TravelCalc
{
    public class Trip
    {
        public Trip(float traveldistance)
        {
            TravelDistance = traveldistance;
        }

        public float TravelDistance { get; set; }
    }
}
