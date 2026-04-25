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
        public void Book_WithValidData_ShouldBeValid()
        {
            // Arrange
            var book = new Ticket
            {
                Title = "C# in Depth",           // Обязательное поле, строка < 100 символов
                Viewer = new Viewer { Name = "Козырева" }, // Обязательное поле
                Date = 2020,                     // В пределах 1000–2100
                Summa = 1000,                    // Предположим, это сумма
            };

            // Act
            var context = new ValidationContext(book);
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(book, context, results, true);

            // Assert
            Assert.True(isValid);
            Assert.Empty(results);
        }

        [Fact]
        public void Book_WithInvalidYear_ShouldBeInvalid()
        {
            // Arrange
            var book = new Ticket
            {
                Title = "Test Book",
                Viewer = new Viewer { Name = "Козырева" },
                Date = 12  // Год вне допустимого диапазона
            };

            var context = new ValidationContext(book);
            var results = new List<ValidationResult>();

            // Act
            var isValid = Validator.TryValidateObject(book, context, results, true);

            // Assert
            Assert.False(isValid);
            Assert.Contains(results, r => r.ErrorMessage != null &&
                                         r.ErrorMessage.Contains("Год должен быть"));
        }
    }

    // Пример классов с атрибутами валидации
    public class Ticket
    {
        [Required(ErrorMessage = "Название обязательно")]
        [StringLength(100, ErrorMessage = "Название не должно превышать 100 символов")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Зритель обязателен")]
        public Viewer Viewer { get; set; }

        [Range(1000, 2100, ErrorMessage = "Год должен быть между 1000 и 2100")]
        public int Date { get; set; }

        [Range(0, 1000000, ErrorMessage = "Цена должна быть положительной")]
        public decimal Summa { get; set; }
    }

    public class Viewer
    {
        [Required(ErrorMessage = "Имя Зрителя обязательно")]
        [StringLength(100)]
        public string Name { get; set; }
    }
}

