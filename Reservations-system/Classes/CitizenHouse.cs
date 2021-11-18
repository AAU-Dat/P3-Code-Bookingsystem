using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reservations_system.Classes
{
    public class CitizenHouse
    {
        private string _adress;
        private bool _isInUse;

        public string Adress
        {
            get { return _adress; }
            set { _adress = value; }
        }


        public bool IsInUse
        {
            get { return _isInUse; }
            set { _isInUse = value; }
        }

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
