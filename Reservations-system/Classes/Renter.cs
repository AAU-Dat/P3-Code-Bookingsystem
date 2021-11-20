using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

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
        [Required]
        [StringLength(50, ErrorMessage ="Det indtastede navn er for langt")]
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
                    throw new ArgumentException("String Name must not contain digits");
                }
                if (_name.Length > 40 && _name.Length < 2)
                {
                    throw new ArgumentOutOfRangeException("String Name's length is invalid");
                }
                _name = char.ToUpper(value[0]) + value.Substring(1);
            }
        }

        [Required]
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

        [Required]
        public string Mail
        {
            get { return _mail; }
            set
            {
                if (String.IsNullOrEmpty(_mail))
                {
                    throw new ArgumentNullException("String Mail is null or misisng");
                }


                if (ValidateMailAdressFormat(_mail))
                {
                    _mail = value;
                }

            }
        }


        //Perhaps put the function in another file
        bool ValidateMailAdressFormat(string mailToBeValidated)
        {
            try
            {
                MailAddress m = new MailAddress(mailToBeValidated);
                //Det er så forfærdeligt
                if (m.User != null)
                {
                    if (m.Host == "gmail.com" || m.Host == "yahoo.com" || m.Host == "student.aau.dk")
                    {
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }
            return false;
        }
        [Required]
        public string Address
        {
            get { return _address; }
            set
            //Det handler om den egentlige prototype>>
            //>>Vi mangler at implementere validering her senere hen (en addresse indeholder by, vejnr, vejnavn, og alt muligt)
            {
                if (String.IsNullOrEmpty(_address))
                {
                    throw new ArgumentNullException("String Address is null or missing");
                }
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
