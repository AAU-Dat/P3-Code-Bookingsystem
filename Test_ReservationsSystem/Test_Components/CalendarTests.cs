using System;
using System.Collections.Generic;
using Xunit;
using Bunit;
using Reservations_system.Components;
using Reservations_system.Classes;


namespace Test_ReservationsSystem.Test_Components
{
    public class CalendarTests
    {
        private static DateTime firstDate = DateTime.Now.AddDays(1);
        private static DateTime secondDate = DateTime.Now.AddDays(3);
        private static DateTime thirdDate = DateTime.Now.AddDays(7);


        public static List<Guest> guests = new()
        {
            new Guest("Mike Mazowsky", "88888888", "verylongemailhere@gmail.com", "Torsvej 12", new ContactPerson(), "980321890132"),
            new Guest("John Wiener", "22222222", "shortmail@gmail.com", "Larspogade 19", new ContactPerson(), "0219321"),
            new Guest("Ukendt", "12345678", "mail@yahoo.com", "Ukendt Adresse", new ContactPerson(), "38970432")
        };

        public static List<Reservation> ListOfReservations = new()
        {
            new Reservation(guests[0], firstDate, firstDate),
            new Reservation(guests[1], secondDate, secondDate),
            new Reservation(guests[2], thirdDate, thirdDate),
        }; 

        [Fact]
        public void TestCalendarNextMonthAndPreviousMonthButtons()
        {
            //Arrange
            DateTime OnRenderDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

            using var ctx = new TestContext();

            //act
            var cut = ctx.RenderComponent<Calendar>(parameters => parameters
                .Add(p => p.Reservationer, ListOfReservations));

            //assert
            //tests if the component has been rendered properly for the test
            cut.Find("h4").MarkupMatches("<h4>" + OnRenderDate.ToString("MMMM yyyy") + "</h4>");

            //act
            var ListOfButtons = cut.FindAll("button");
            ListOfButtons[1].Click();

            //assert
            //tests if the month has changed
            cut.Find("h4").MarkupMatches("<h4>" + OnRenderDate.AddMonths(1).ToString("MMMM yyyy") + "</h4>");

            ListOfButtons[0].Click();

            //assert
            //tests if the month has changed
            cut.Find("h4").MarkupMatches("<h4>" + OnRenderDate.ToString("MMMM yyyy") + "</h4>");
        }
    }
}
