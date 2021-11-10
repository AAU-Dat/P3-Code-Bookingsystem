using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Reservations_system.Classes;
using Reservations_system.Interfaces;

namespace Reservations_system.Classes
{
    public class CitizenHouse : IHouseUsable
    {
        public string Address { get; set; }

        public bool IsInUse { get; set; }


        public void HouseCleared()
        {
            IsInUse = false;
        }

        public void HouseDelievered()
        {
            IsInUse = false;
        }

        public void HouseRetrieved()
        {
            IsInUse = true;
        }
    }
}
