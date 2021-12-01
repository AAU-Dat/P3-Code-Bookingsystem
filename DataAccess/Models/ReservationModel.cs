using System;

namespace DataAccess.Models
{
    public class ReservationModel
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime Approved { get; set; }
        public DateTime DepositPaid { get; set; }
        public DateTime RentPaid { get; set; }
        public DateTime DepositRefunded { get; set; }
        public DateTime Cancelled { get; set; }
        public int GuestId { get; set; }
    }
}
