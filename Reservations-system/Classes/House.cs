using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reservations_system.Classes
{
    public class House
    {
        private bool _isInUse;

        public bool IsInUse
        {
            get { return _isInUse; }
            set { _isInUse = value; }
        }
    }
}
