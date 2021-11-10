using System;
namespace Reservations_system.Interfaces
{
    internal interface IHouseUsable
    {
        public void HouseCleared();

        public void HouseRetrieved();

        public void HouseDelievered();
    }
}
