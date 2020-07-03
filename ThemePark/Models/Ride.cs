using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThemePark.Models
{
    interface IRide
    {
        string rideStats();
        string isOpen();

    }
    
    public class Coaster : IRide
    {
        public string rideName;
        public Park ridePark;
        public bool opStatus;

        public string rideStats()
        {
            return ($"Here are the stats for this ride: {this.rideName} is located at {this.ridePark.parkStats()}. {this.isOpen()}");
        }

        public string isOpen()
        {
            if (this.opStatus)
            {
                return ("This ride is currently open.");
            } else
            {
                return ("This ride is currently closed.");
            }
            
        }
    }
}
