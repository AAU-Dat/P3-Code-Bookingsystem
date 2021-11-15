using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

public class Reservation
{
    public Reservation()
    {
    }

    public Reservation(DateTime startDate, DateTime finishDate, string firstName, string lastName, string phoneNumber, string mail, string accountNumber, string registrationNumber, bool cleaning, bool isOver18, string otherInfo)
    {
        StartDate = startDate;
        FinishDate = finishDate;
        FirstName = firstName;
        LastName = lastName;
        PhoneNumber = phoneNumber;
        Mail = mail;
        AccountNumber = accountNumber;
        RegistrationNumber = registrationNumber;
        Cleaning = cleaning;
        IsOver18 = isOver18;
        OtherInfo = otherInfo;
        Confirmed = false;
    }

    [Required]
    public DateTime StartDate { get; set;} = DateTime.Now;
    [Required]

    public DateTime FinishDate { get; set; } = DateTime.Now.AddDays(1);
    [Required]

    public string FirstName { get; set; }
    [Required]

    public string LastName { get; set; }
    [Required]

    public string PhoneNumber { get; set; }
    [Required]

    public string Mail { get; set; }
    [Required]

    public string AccountNumber { get; set; }
    [Required]

    public string RegistrationNumber { get; set; }

    public bool Cleaning { get; set; } = false;
    
    [Required]
    public bool IsOver18 { get; set; }
    
    public string OtherInfo { get; set; }

    public bool Confirmed { get; set; }

}

