using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Reservations_system.Classes
{

    public abstract class Renter
    {
        private string _name;
        private string _phoneNumber;
        private string _mail;
        private string _address;
        private ContactPerson _contactPerson; //Håndter korrekt


        protected Renter(string name, string phoneNumber, string mail, string address, ContactPerson contactPerson)
        {
            Name = name;
            PhoneNumber = phoneNumber;
            Mail = mail;
            Address = address;
            ContactPerson = contactPerson;
        }

        protected Renter()
        {
        }

        public string Name
        {
            get { return _name; }
            set
            {
                if (String.IsNullOrEmpty(_name))
                {
                    throw new ArgumentNullException("String Name is null or missing");
                }
                if (_name.Any(char.IsDigit))
                {
                    throw new ArgumentException("String Name contains digits");
                }
                if (_name.Length > 40 && _name.Length < 2)
                {
                    throw new ArgumentOutOfRangeException("String Name's length is invalid");
                }
                _name = char.ToUpper(value[0]) + value.Substring(1);
            }
        }

        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set
            {
                if (_phoneNumber.Length != 8)
                {
                    throw new ArgumentOutOfRangeException("String PhoneNumber's length is invalid");
                }

                if (String.IsNullOrEmpty(_phoneNumber))
                {
                    throw new ArgumentNullException("String PhoneNumber is null or missing");
                }

                if (_phoneNumber.Any(char.IsLetter))
                {
                    throw new ArgumentException("String Phonenumber contains a letter");
                }

                _phoneNumber = value;

            }
        }

        public string Mail
        {
            get { return _mail; }
            set {
                if (String.IsNullOrEmpty(_mail))
                {
                    throw new ArgumentNullException("String Mail is null or misisng");
                }

                if(ValidateMailAdressFormat(_mail))
                {
                    _mail = value;
                }

            }
        }
        public bool ValidateMailAdressFormat(string mailToBeValidated)
        {
            MailAddress m = MailAddress(mailToBeValidated);
        }
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        public ContactPerson ContactPerson
        {
            get { return _contactPerson; }
            set { _contactPerson = value; }
        }
    }
}
