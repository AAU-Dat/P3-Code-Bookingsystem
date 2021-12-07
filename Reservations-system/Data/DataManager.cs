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
        private List<Reservation> _reservations;
        private List<Guest> _guests;

        public DataManager(IReservationData reservationData, IGuestData guestData)
        {
            _reservationDataAccess = reservationData;
            _guestDataAccess = guestData;
        }

        public List<Reservation> Reservations
        {
            get
            {
                return _reservations;
            }
        }

        public void AddReservation(Reservation reservation) //Adds a reservation to DB and list
        {
            _guestDataAccess.InsertGuestWithReservation(new GuestModel()
            {
                Name = reservation.Guest.Name,
                Address = reservation.Guest.Address,
                Phone = reservation.Guest.PhoneNumber,
                Email = reservation.Guest.Mail,
                AccountNumber = reservation.Guest.AccountNumber,
            },
            new ReservationModel()
            {
                StartDate = reservation.StartDate,
                EndDate = reservation.EndDate
            });

            Reservations.Add(reservation);
        }

        public void DeleteReservation(Reservation reservation) //Removes a reservation from DB and local list
        {
            _reservationDataAccess.DeleteReservation(reservation.Id);
            Reservations.Remove(reservation);
        }

        public void UpdateReservation(Reservation reservation) //Updates a reservation in list to be given reservation. matches by ID
        {
            _reservationDataAccess.UpdateReservation(ReservationToReservationModel(reservation));
            for (int i = 0; i < _reservations.Count; i++)
            {
                if (_reservations[i].Id.Equals(reservation.Id))
                {
                    _reservations[i] = reservation;
                }
            }
        }

        public void UpdateGuest(Guest guest) //Updates a guest in list to be given guest. matches by ID
        {
            _guestDataAccess.UpdateGuest(GuestToGuestModel(guest));
            for (int i = 0; i < _guests.Count; i++)
            {
                if (_guests[i].Id.Equals(guest.Id))
                {
                    _guests[i] = guest;
                }
            }
        }

        private GuestModel GuestToGuestModel(Guest guest) //Converts guest obejct to guest model object
        {
            GuestModel guestModel = new()
            {
                Name = guest.Name,
                Address = guest.Address,
                Email = guest.Mail,
                AccountNumber = guest.AccountNumber
            };
            return guestModel;
        }

        private ReservationModel ReservationToReservationModel(Reservation reservation) //Coverts reservation object to reservation model object
        {
            ReservationModel reservationModel = new()
            {
                StartDate = reservation.StartDate,
                EndDate = reservation.EndDate,
                GuestId = reservation.Guest.Id
            };
            return reservationModel;
        }

        private Reservation ReservationModelToReservation(ReservationModel reservationModel) //Coverts reservation model object to reservation object
        {
            Reservation reservation = new()
            {
                StartDate = reservationModel.StartDate,
                EndDate = reservationModel.EndDate,
                Guest = GetGuestWithMatchingID(reservationModel.GuestId),
                Id = reservationModel.Id
            };
            return reservation;
        }

        private Guest GuestModelToGuest(GuestModel guestModel) //Converts a guest model object to a guest object
        {
            Guest guest = new()
            {
                Name = guestModel.Name,
                Address = guestModel.Address,
                Mail = guestModel.Email,
                AccountNumber = guestModel.AccountNumber,
                Id = guestModel.Id
            };
            return guest;
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

        private async Task<List<Guest>> GetGuestsFromDBAsync() //Async mehtod that returns all guests in DB
        {
            List<Guest> guests = new();
            IEnumerable<GuestModel> guestModelsFromDB = await _guestDataAccess.GetGuests();

            foreach (GuestModel guestModel in guestModelsFromDB)
            {
                guests.Add(GuestModelToGuest(guestModel));
            }
            return guests;
        }

        private Guest GetGuestFromLocalList(int guestId)
        {
            foreach (Guest guest in _guests)
            {
                if (guest.Id.Equals(guestId))
                {
                    return guest;
                }
            }
            return null;
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
    }
}

//Create list of reservations with guests in
//Create a number of methods to update lists, locally and in DB
//Make it an interface and add it as singleton transient dependecy thing
//Update models, Guests reservation etc..... Remove shitty validation make better
