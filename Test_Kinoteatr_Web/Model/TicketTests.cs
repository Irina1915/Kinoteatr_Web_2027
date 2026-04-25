using Kinoteatr_Web_2027.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Kinoteatr_Web.Model
{
    public class TicketTests
    {
        [Fact]
        public void Event_WithValidData_ShouldBeValid()
        {

            var ticketItem = new Ticket
            {
                Title = "Фильм",
                Viewer = "Козырева Мария",
                Date = DateTime.Now.AddDays(30),
                Summa = 1000
            };


            var context = new ValidationContext(ticketItem);
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(ticketItem, context, results, true);


            Assert.True(isValid);
            Assert.Empty(results);
        }

        [Fact]
        public void Event_WithMissingLocation_ShouldBeInvalid()
        {
            // Arrange
            var ticketItem = new Ticket
            {
                Title = "Фильм",
                Viewer = "Козырева Мария",
                Date = DateTime.Now.AddDays(30),
                Summa = 1000,
            };

            // Act
            var context = new ValidationContext(ticketItem);
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(ticketItem, context, results, true);

        }
    }
}
