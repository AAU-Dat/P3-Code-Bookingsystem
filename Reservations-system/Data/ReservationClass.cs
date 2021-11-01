using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class Reservation
{

    public DateTime StartDate { get; set;} = DateTime.Now;

    public DateTime FinishDate { get; set; } = DateTime.Now;

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string PhoneNumber { get; set; }

    public string Mail { get; set; }

    public string AccountNumber { get; set; }

    public string RegistrationNumber { get; set; }

    public bool Cleaning { get; set; } = false;

    public bool IsOver18 { get; set; }

    public string OtherInfo { get; set; }

}

