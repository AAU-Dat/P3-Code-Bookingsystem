using DataAccess.Data;
using DataAccess.Models;
using Moq;
using Reservations_system.Classes;
using Reservations_system.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Test_ReservationsSystem.Test_DataManager
{
    public class DataManagerTests
    {
        [Fact]
        public void AddReservationValidData()
        {
            Renter guest = new Guest("Lars", "88888888", "mail@mail.dk", "gade1", new ContactPerson(),"123456789123456");
            Reservation reservation = new();
            GuestModel guestModel = new();
            ReservationModel reservationModel = new();

            var guestDataMock = new Mock<IGuestData>();
            var reservationDataMock = new Mock<IReservationData>();
            guestDataMock.Setup(p => p.InsertGuestWithReservation(guestModel, reservationModel));
            DataManager controller = new(reservationDataMock.Object, guestDataMock.Object);

            controller.Reservations = new List<Reservation>();

            controller.AddReservation(reservation);

            Assert.NotEmpty(controller.Reservations);
            Assert.Single(controller.Reservations);

            guestDataMock.Verify(p => p.InsertGuestWithReservation(It.IsAny<GuestModel>(), It.IsAny<ReservationModel>()), Times.Once());
        }

        [Fact]
        public void RemoveReservationValidData()
        {
            Renter guest = new Guest();
            Reservation reservation = new();
            GuestModel guestModel = new();
            ReservationModel reservationModel = new();

            var guestDataMock = new Mock<IGuestData>();
            var reservationDataMock = new Mock<IReservationData>();
            reservationDataMock.Setup(p => p.DeleteReservation(reservationModel.Id));
            DataManager controller = new(reservationDataMock.Object, guestDataMock.Object);

            controller.Reservations = new List<Reservation>();

            Assert.Empty(controller.Reservations);
            controller.AddReservation(reservation);
            Assert.NotEmpty(controller.Reservations);
            controller.DeleteReservation(reservation);
            Assert.Empty(controller.Reservations);

            reservationDataMock.Verify(p => p.DeleteReservation(It.IsAny<int>()), Times.Once());
        }

        [Fact]
        public void UpdateReservationValidData()
        {
            Renter guest = new Guest();
            Reservation reservation = new() //The reservation thats put into the list
            {
                Id = 1,
                Guest = guest,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now
            };
            
            GuestModel guestModel = new();
            ReservationModel reservationModel = new();

            var guestDataMock = new Mock<IGuestData>();
            var reservationDataMock = new Mock<IReservationData>();
            reservationDataMock.Setup(p => p.UpdateReservation(reservationModel));

            DataManager controller = new(reservationDataMock.Object, guestDataMock.Object);
            controller.Reservations = new List<Reservation>();

            controller.AddReservation(reservation); //Adds the first reservation to the list
            controller.UpdateReservation(reservation); //Updates the reservation that matches by ID

            
            reservationDataMock.Verify(p => p.UpdateReservation(It.IsAny<ReservationModel>()), Times.Once());
        }

        [Fact]
        public void UpdateGuestValidData()
        {
            Renter guest = new Guest()
            {
                Name = "Lars",
                PhoneNumber = "88888888",
                Mail = "mail@mail.dk",
                Address = "gade 1",
                AccountNumber = "123456789123456",
                Id = 1
            };
            Reservation reservation = new(); //The reservation thats put into the list
            GuestModel guestModel = new();
            ReservationModel reservationModel = new();

            var guestDataMock = new Mock<IGuestData>();
            var reservationDataMock = new Mock<IReservationData>();
            guestDataMock.Setup(p => p.UpdateGuest(guestModel));

            DataManager controller = new(reservationDataMock.Object, guestDataMock.Object);
            controller.Reservations = new List<Reservation>();

            controller.AddReservation(reservation); //Adds the first reservation to the list
            controller.UpdateGuest(guest);

            guestDataMock.Verify(p => p.UpdateGuest(It.IsAny<GuestModel>()), Times.Once());
        }
    }
}
