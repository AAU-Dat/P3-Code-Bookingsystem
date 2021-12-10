using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Reservations_system.Classes
{

    public abstract class Renter
    {
        private string _name;
        private string _phoneNumber;
        private string _mail;
        private string _address;
        private string _accountNumber;
        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private ContactPerson _contactPerson; //Håndter korrekt


        protected Renter(string name, string phoneNumber, string mail, string address, ContactPerson contactPerson, string accountNumber)
        {
            Name = name;
            PhoneNumber = phoneNumber;
            Mail = mail;
            Address = address;
            ContactPerson = contactPerson;
            AccountNumber = accountNumber;
        }

        protected Renter()
        {
        }
        [Required]
        [StringLength(50, ErrorMessage = "Det indtastede navn er for langt")]
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
            }
        }

        [Required]
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set
            {
                _phoneNumber = value;
            }
        }

        [Required]
        public string Mail
        {
            get { return _mail; }
            set
            {
                _mail = value;
            }
        }
        public string AccountNumber
        {
            get
            {
                return _accountNumber;
            }
            set
            {
                _accountNumber = value ;
            }
        }
        [Required]
        public string Address
        {
            get
            {
                return _address;
            }
            set
            {
                _address = value;

            }
        }

        public ContactPerson ContactPerson
        {
            get { return _contactPerson; }
            set { _contactPerson = value; }
        }
    }
}
