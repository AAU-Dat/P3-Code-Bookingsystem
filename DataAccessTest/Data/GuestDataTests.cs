using Autofac.Extras.Moq;
using DataAccess.Data;
using DataAccess.DbAccess;
using DataAccess.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace DataAccessTest
{
    public class GuestDataTests
    {
        private ITestOutputHelper _output;
        public GuestDataTests(ITestOutputHelper output)
        {
            _output = output;
        }
        private static IEnumerable<GuestModel> GetSampleGuestModels()
        {
            List<GuestModel> output = new();
            output.Add(new GuestModel()
            {
                Id = 1,
                Name = "Daniel Petersen",
                Address = "Gammelgade 1",
                Email = "daniel@mail.com",
                Phone = "12 23 34 45",
                AccountNumber = "0001-0000654321"
            });
            output.Add(new GuestModel()
            {
                Id = 2,
                Name = "Lars Hansen",
                Address = "Nygade 1",
                Email = "lars@mail.dk",
                Phone = "88 88 88 88",
                AccountNumber = "8888-0008088888"
            });
            output.Add(new GuestModel()
            {
                Id = 3,
                Name = "Elias Hajji",
                Address = "Lilletorv 1",
                Email = "elias@mail.dk",
                Phone = "24 24 35 35",
                AccountNumber = "0002-0000654321"
            });
            output.Add(new GuestModel()
            {
                Id = 4,
                Name = "Raymond Kacso",
                Address = "Storetorv 99",
                Email = "raymond@email.ru",
                Phone = "00 00 90 01",
                AccountNumber = "0101-1234567890"
            });

            return output.Where(x => true);
        }

        [Fact]
        public void DeleteGuestSuccessful()
        {
            var mock = new Mock<ISqlDbAccess>();
            mock
                .Setup(p => p.SaveData(It.IsAny<string>(), It.IsAny<object>(), "Default"));

            GuestData controller = new(mock.Object);

            controller.DeleteGuest(1);

            mock.Verify(x => x.SaveData("dbo.spGuest_Delete", It.Is<object>(o => o.GetHashCode() == (new { Id = 1 }).GetHashCode()), "Default"), Times.Once());
            mock.Verify(x => x.SaveData("dbo.spGuest_Delete", It.Is<object>(o => o.GetHashCode() == (new { Id = 2 }).GetHashCode()), "Default"), Times.Never());
            mock.Verify(x => x.SaveData("dbo.spGuest_Insert", It.Is<object>(o => o.GetHashCode() == (new { Id = 1 }).GetHashCode()), "Default"), Times.Never());
        }

        [Fact]
        public async Task GetGuestValid()
        {
            var mock = new Mock<ISqlDbAccess>();
            mock
                .Setup(p => p.LoadData<GuestModel, dynamic>(It.IsAny<string>(), It.IsAny<object>(), "Default"))
                .ReturnsAsync(GetSampleGuestModels());

            GuestData controller = new(mock.Object);

            GuestModel expected = GetSampleGuestModels().FirstOrDefault();
            GuestModel actual = await controller.GetGuest(1);

            mock.Verify(x => x.LoadData<GuestModel, dynamic>("dbo.spGuest_Get", It.Is<object>(o => o.GetHashCode() == (new { Id = 1 }).GetHashCode()), "Default"), Times.Once());
            mock.Verify(x => x.LoadData<GuestModel, dynamic>("dbo.spGuest_Get", It.Is<object>(o => o.GetHashCode() == (new { Id = 2 }).GetHashCode()), "Default"), Times.Never());
            mock.Verify(x => x.LoadData<GuestModel, dynamic>("dbo.spGuest_GetAll", It.Is<object>(o => o.GetHashCode() == (new { Id = 1 }).GetHashCode()), "Default"), Times.Never());
            Assert.Equal(expected.Id, actual.Id);
        }
        [Fact]
        public async Task GetGuestsValid()
        {
            var mock = new Mock<ISqlDbAccess>();
            mock
                .Setup(p => p.LoadData<GuestModel, dynamic>(It.IsAny<string>(), It.IsAny<object>(), "Default"))
                .ReturnsAsync(GetSampleGuestModels());

            GuestData controller = new(mock.Object);

            IEnumerable<GuestModel> expected = GetSampleGuestModels();
            IEnumerable<GuestModel> actual = await controller.GetGuests();

            mock.Verify(x => x.LoadData<GuestModel, dynamic>("dbo.spGuest_GetAll", It.Is<object>(o => o.GetHashCode() == (new { }).GetHashCode()), "Default"), Times.Once());
            mock.Verify(x => x.LoadData<GuestModel, dynamic>("dbo.spGuest_GetAll", It.Is<object>(o => o.GetHashCode() == (new { id = 1 }).GetHashCode()), "Default"), Times.Never());
            mock.Verify(x => x.LoadData<GuestModel, dynamic>("dbo.spGuest_Get", It.Is<object>(o => o.GetHashCode() == (new { }).GetHashCode()), "Default"), Times.Never());
            foreach (var (expectedItem, actualItem) in expected.Zip(actual))
            {
                Assert.Equal(expectedItem.Id, actualItem.Id);
            }
        }

        [Fact]
        public void InsertGuestSuccessful()
        {
            GuestModel guest = new();

            var mock = new Mock<ISqlDbAccess>();
            mock
                .Setup(p => p.SaveData(It.IsAny<string>(), It.IsAny<object>(), "Default"));

            GuestData controller = new(mock.Object);
            controller.InsertGuest(guest);

            mock.Verify(x => x.SaveData("dbo.spGuest_Insert", It.Is<object>(o => o.GetHashCode() == (new { guest.Name, guest.Address, guest.Email, guest.Phone, guest.AccountNumber }).GetHashCode()), "Default"), Times.Once());
            mock.Verify(x => x.SaveData("dbo.spGuest_Insert", It.Is<object>(o => o.GetHashCode() == (new { string.Empty, guest.Address, guest.Email, guest.Phone, guest.AccountNumber }).GetHashCode()), "Default"), Times.Never());
            mock.Verify(x => x.SaveData("dbo.spGuest_Delete", It.Is<object>(o => o.GetHashCode() == (new { guest.Name, guest.Address, guest.Email, guest.Phone, guest.AccountNumber }).GetHashCode()), "Default"), Times.Never());
        }

        [Fact]
        public void UpdateGuestSuccessful()
        {
            GuestModel guest1 = new();
            GuestModel guest2 = new();

            var mock = new Mock<ISqlDbAccess>();
            mock
                .Setup(p => p.SaveData(It.IsAny<string>(), It.IsAny<object>(), "Default"));

            GuestData controller = new(mock.Object);
            controller.UpdateGuest(guest1);

            mock.Verify(x => x.SaveData("dbo.spGuest_Update", guest1, "Default"), Times.Once());
            mock.Verify(x => x.SaveData("dbo.spGuest_Update", guest2, "Default"), Times.Never());
            mock.Verify(x => x.SaveData("dbo.spGuest_Insert", guest1, "Default"), Times.Never());

        }

        [Fact]
        public void InsertGuestWithReservationSuccesful()
        {
            GuestModel guest1 = new() { Name = "test1" };
            GuestModel guest2 = new() { Name = "test2" };
            ReservationModel reservation = new();

            var mock = new Mock<ISqlDbAccess>();
            mock
                .Setup(p => p.SaveData(It.IsAny<string>(), It.IsAny<object>(), "Default"));

            GuestData controller = new(mock.Object);
            controller.InsertGuestWithReservation(guest1, reservation);

            mock.Verify(x => x.SaveData(
                "dbo.spReservationGuest_Insert",
                It.Is<object>(o => o.GetHashCode() == (new
                {
                    guest1.Name,
                    guest1.Address,
                    guest1.Email,
                    guest1.Phone,
                    guest1.AccountNumber,
                    reservation.StartDate,
                    reservation.EndDate,
                    reservation.Information
                }).GetHashCode()),
                "Default"), Times.Once());
            mock.Verify(x => x.SaveData(
                "dbo.spReservationGuest_Insert",
                It.Is<object>(o => o.GetHashCode() == (new
                {
                    guest2.Name,
                    guest2.Address,
                    guest2.Email,
                    guest2.Phone,
                    guest2.AccountNumber,
                    reservation.StartDate,
                    reservation.EndDate,
                    reservation.Information
                }).GetHashCode()),
                "Default"), Times.Never());
            mock.Verify(x => x.SaveData(
                "dbo.spGuest_Update",
                It.Is<object>(o => o.GetHashCode() == (new
                {
                    guest2.Name,
                    guest2.Address,
                    guest2.Email,
                    guest2.Phone,
                    guest2.AccountNumber,
                    reservation.StartDate,
                    reservation.EndDate,
                    reservation.Information
                }).GetHashCode()),
                "Default"), Times.Never());
        }
    }
}
