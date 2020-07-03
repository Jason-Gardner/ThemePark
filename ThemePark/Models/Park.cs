using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace ThemePark.Models
{
    public class Park
    {
        public string parkName;
        public string parkCity;
        public string parkState;

        public string parkStats()
        {
            return ($"{this.parkName} in {this.parkCity}, {this.parkState}");
        }
    }
}
