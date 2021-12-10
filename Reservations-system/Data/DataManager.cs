using DataAccess.Data;
using DataAccess.Models;
using Reservations_system.Classes;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reservations_system.Data
{
    public class DataManager : IDataManager
    {
        private readonly IReservationData _reservationDataAccess;
        private readonly IGuestData _guestDataAccess;
        private readonly IAssociationData _associationData;
        private List<Reservation> _reservations;
        private List<Renter> _guests;

        public DataManager(IReservationData reservationData, IGuestData guestData, IAssociationData associationData)
        {
            _reservationDataAccess = reservationData;
            _guestDataAccess = guestData;
            _associationData = associationData;
        }

        public List<Reservation> Reservations
        {
            get
            {
                return _reservations;
            }
            set
            {
                _reservations = value;
            }
        }

        public void AddReservation(Reservation reservation) //Adds a reservation to DB and list
        {
            _guestDataAccess.InsertGuestWithReservation(GuestToGuestModel(reservation.Guest), ReservationToReservationModel(reservation));
            Reservations.Add(reservation);
        }

        public void DeleteReservation(Reservation reservation) //Removes a reservation from DB and local list
        {
            _reservationDataAccess.DeleteReservation(reservation.Id);
            Reservations.Remove(reservation);
        }

        public void UpdateReservation(Reservation reservation) //Updates a reservation in DB to be given reservation. matches by ID 
        {
            _reservationDataAccess.UpdateReservation(ReservationToReservationModel(reservation));
        }

        public void UpdateGuest(Renter guest) //Updates a guest in DB to be given guest. matches by ID
        {
            _guestDataAccess.UpdateGuest(GuestToGuestModel(guest));
        }

        private GuestModel GuestToGuestModel(Renter guest) //Converts guest obejct to guest model object
        {
            GuestModel guestModel = new()
            {
                Id = guest.Id,
                Name = guest.Name,
                Address = guest.Address,
                Phone = guest.PhoneNumber,
                Email = guest.Mail,
                AccountNumber = guest.AccountNumber,
            };
            return guestModel;
        }
        
        private Guest GuestModelToGuest(GuestModel guestModel) //Converts a guest model object to a guest object
        {
            Guest guest = new()
            {
                Id = guestModel.Id,
                Name = guestModel.Name,
                Mail = guestModel.Email,
                Address = guestModel.Address,
                PhoneNumber = guestModel.Phone,
                AccountNumber = guestModel.AccountNumber
            };
            return guest;
        }

        private ReservationModel ReservationToReservationModel(Reservation reservation) //Coverts reservation object to reservation model object
        {
            ReservationModel reservationModel = new()
            {
                Id=reservation.Id,
                StartDate = reservation.StartDate,
                EndDate = reservation.EndDate,
                Approved = reservation.Confirmed,
                RentPaid = reservation.RentPaid,
                DepositPaid = reservation.DepositPaid,
                DepositRefunded = reservation.DepositRefunded,
                Cancelled = reservation.Cancelled,
                Information = reservation.Information
            };
            return reservationModel;
        }

        private Reservation ReservationModelToReservation(ReservationModel reservationModel) //Coverts reservation model object to reservation object
        {
            Reservation reservation = new()
            {
                Id = reservationModel.Id,
                Guest = GetGuestWithMatchingID(reservationModel.GuestId),
                StartDate = reservationModel.StartDate,
                EndDate = reservationModel.EndDate,
                Confirmed = reservationModel.Approved,
                RentPaid = reservationModel.RentPaid,
                DepositPaid = reservationModel.DepositPaid,
                DepositRefunded = reservationModel.DepositRefunded,
                Cancelled = reservationModel.Cancelled,
                Information= reservationModel.Information
            };
            return reservation;
        }

        private Guest GetGuestWithMatchingID(int id) //Searches through list of guests to find guest with mathcing given ID
        {
            foreach (Guest guest in _guests)
            {
                if (guest.Id.Equals(id))
                {
                    return guest;
                }
            }
            return null;
        }

        private async Task<List<Renter>> GetGuestsFromDBAsync() //Async mehtod that returns all guests in DB
        {
            List<Renter> guests = new();
            IEnumerable<GuestModel> guestModelsFromDB = await _guestDataAccess.GetGuests();

            foreach (GuestModel guestModel in guestModelsFromDB)
            {
                guests.Add(GuestModelToGuest(guestModel));
            }
            return guests;
        }

        private async Task<List<Reservation>> GetReservationsFromDBAsync() //Async method that returns all reservations in DB
        {
            List<Reservation> reservations = new();
            IEnumerable<ReservationModel> reservationModelsFromDB = await _reservationDataAccess.GetReservations();
            foreach (ReservationModel reservationModel in reservationModelsFromDB)
            {
                reservations.Add(ReservationModelToReservation(reservationModel));
            }
            return reservations;
        }

        public Reservation GetReservationFromLocalList(int reservationId)
        {
            foreach (Reservation reservation in _reservations)
            {
                if (reservation.Id.Equals(reservationId))
                {
                    return reservation;
                }
            }
            return null;
        }

        public async Task<List<Reservation>> ReservationsDataFromDBAsync() //Returns a list of all reservations and creates the local list of guests to be used by other functions
        {
            _guests = await GetGuestsFromDBAsync();
            _reservations = await GetReservationsFromDBAsync();
            return _reservations;
        }

        public async Task<CitizenAssociationModel> GetAssociationInformation()
        {
            CitizenAssociationModel association = await _associationData.GetAssociation(1);
            return association;
        }

        public void UpdateAssociationInformation(CitizenAssociationModel association)
        {
            _associationData.UpdateAssociation(association);
        }
    }
}

//Create list of reservations with guests in
//Create a number of methods to update lists, locally and in DB
//Make it an interface and add it as singleton transient dependecy thing
//Update models, Guests reservation etc..... Remove shitty validation make better
