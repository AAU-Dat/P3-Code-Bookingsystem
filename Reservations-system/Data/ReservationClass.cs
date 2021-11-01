using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

public class Reservation
{
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

}

