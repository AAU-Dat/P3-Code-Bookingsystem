using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Bunit;
using Reservations_system.Components;
using Reservations_system.Data;
using Moq;
using DataAccess.Models;
using Reservations_system.Classes;
using DataAccess.Data;
using MailService;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Test_ReservationsSystem.Test_Components
{
    public class AdminHomePageTests
    {
        [Fact]
        public void TestEditModeValue()
        {
            //Arrange
            Renter guest = new Guest("Lars", "88888888", "mail@mail.dk", "gade1", new ContactPerson(), "123456789123456");
            Reservation reservation = new Reservation(guest, DateTime.Now, DateTime.Now.AddDays(2));


            using var ctx = new TestContext();
            var extService = new TaskCompletionSource<string>();
            //            var componentTest = ctx.RenderComponent<AdminHomePage>(parameters => parameters
            //  .Add(p => p.TextService, textService.Task)
            //);


            ctx.Services.Replace(ServiceDescriptor.Transient<IDataManager, DataManagerTest>());


            var componentTest = ctx.RenderComponent<AdminHomePage>();

            //load db
            //tryk pa knap



            //act
            //var expectedEditModeValueBeforeFirstFuncCall = false;
            //var actualEditModeValue = componentTest.editMode;


            //componentTest.UpdateChosenReservation(reservation);

            //assert
           // Assert.Equal(expectedEditModeValueBeforeFirstFuncCall, actualEditModeValue);

            //
            componentTest.InvokeAsync(() => componentTest.Instance.editMode = true);

            Assert.True(componentTest.Instance.editMode);
            Assert.NotNull(componentTest.Instance.listOfReservations);
            Assert.NotEmpty(componentTest.Instance.listOfReservations);
            //componentTest.ChangeEditMode();

            //var expectedEditModeValueAfterFirstFuncCall = true;
            //Assert.Equal(actualEditModeValue, expectedEditModeValueAfterFirstFuncCall);


            //            IDataManagerMock.Verify(p => p.UpdateGuest(It.IsAny<Renter>()), Times.Once());
            //          IDataManagerMock.Verify(p => p.UpdateReservation(It.IsAny<Reservation>()), Times.Once());



        }


        [Fact]
        public void UpdateGuestDUUUH()
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

            using var ctx = new TestContext();
            var componentTest = ctx.RenderComponent<AdminHomePage>().Instance;
            var expectedEditModeValueBeforeFirstFuncCall = false;
            var actualEditModeValue = componentTest.editMode;
            Assert.Equal(expectedEditModeValueBeforeFirstFuncCall, actualEditModeValue);

            componentTest.ChangeEditMode();
            var expectedEditModeValueAfterFirstFuncCall = true;
            Assert.Equal(actualEditModeValue, expectedEditModeValueAfterFirstFuncCall);


            var guestDataMock = new Mock<IGuestData>();
            var reservationDataMock = new Mock<IReservationData>();
            var associationDataMock = new Mock<IAssociationData>();
            var mailDataMock = new Mock<ISendMail>();
            reservationDataMock.Setup(p => p.UpdateReservation(reservationModel));

            DataManager controller = new(reservationDataMock.Object, guestDataMock.Object, associationDataMock.Object, mailDataMock.Object);
            controller.Reservations = new List<Reservation>();




            controller.AddReservation(reservation); //Adds the first reservation to the list
            controller.UpdateReservation(reservation); //Updates the reservation that matches by ID

            reservationDataMock.Verify(p => p.UpdateReservation(It.IsAny<ReservationModel>()), Times.Once());
        }

    }
}
