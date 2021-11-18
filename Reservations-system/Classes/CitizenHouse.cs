using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reservations_system.Classes
{
    public class CitizenHouse
    {
        public string Address { get; set; }

        public bool IsInUse { get; set; }


        public void HouseIsNotInUse()
        {
            IsInUse = false;
        }

        public void HouseIsInUse()
        {
            IsInUse = false;
        }
    }
}
