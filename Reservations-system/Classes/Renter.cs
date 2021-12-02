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
        public int Id { get; set; }
        private string _name;
        private string _phoneNumber;
        private string _mail;
        private string _address;
        private string _accountNumber;
        private ContactPerson _contactPerson; //Håndter korrekt


        protected Renter(string name, string phoneNumber, string mail, string address, ContactPerson contactPerson, string accountNumber, int id)
        {
            Id = id;
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
                //                if (String.IsNullOrEmpty(_name))
                //                {
                //                    throw new ArgumentNullException("String Name is null or missing");
                //                }
                _name = char.ToUpper(value[0]) + value.Substring(1);


                if ((Regex.IsMatch(_name, @"\d")))
                {
                    throw new ArgumentException("String Name must not contain digits");
                }
                if (_name.Length > 40 && _name.Length < 2)
                {
                    throw new ArgumentOutOfRangeException("String Name's length is invalid");
                }
            }
        }

        [Required]
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set
            {
                _phoneNumber = value;

                if (_phoneNumber.Length != 8)
                {
                    Console.WriteLine(_phoneNumber);
                    throw new ArgumentOutOfRangeException("String PhoneNumber's length is invalid");
                }

                if (String.IsNullOrEmpty(_phoneNumber))
                {
                    throw new ArgumentNullException("String PhoneNumber is null or missing");
                }

                //               if (_phoneNumber.Any(char.IsLetter))
                //               {
                //                   throw new ArgumentException("String Phonenumber contains a letter");
                //               }


            }
        }

        [Required]
        public string Mail
        {
            get { return _mail; }
            set
            {
                _mail = value;
                if (String.IsNullOrEmpty(_mail))
                {
                    throw new ArgumentNullException("String Mail is null or misisng");
                }


                if ((ValidateMailAdressFormat(_mail) == false))
                {
                    Console.WriteLine(_mail);
                    throw new ArgumentException("Invalid mail");
                }

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
                value = _accountNumber;
            }
        }



        //Perhaps put the function in another file
        bool ValidateMailAdressFormat(string mailToBeValidated)
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
                _address = value;
                if (String.IsNullOrEmpty(_address))
                {
                    throw new ArgumentNullException("String Address is null or missing");
                }

            }
        }

        public ContactPerson ContactPerson
        {
            get { return _contactPerson; }
            set { _contactPerson = value; }
        }
    }
}
