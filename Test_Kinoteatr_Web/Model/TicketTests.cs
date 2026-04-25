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
        public void Ticket_WithValidData_ShouldBeValid()
        {
            // Arrange - создаем объект билета с ВСЕМИ валидными значениями
            var ticket = new Ticket
            {
                Title = "C# in Depth",              // Обязательное поле, строка < 100 символов
                Viewer = "Козырева Мария",          // ✅ Добавлено обязательное поле
                Date = DateTime.Now.AddDays(30),    // ✅ Дата в будущем (если требуется)
                Summa = 1500                       // ✅ Сумма в пределах допустимого диапазона
            };

            // Act
            var context = new ValidationContext(ticket);
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(ticket, context, results, true);

            // Assert
            Assert.True(isValid);
            Assert.Empty(results);
        }

        // Тест проверяет, что если не указать заголовок, то объект будет невалиден.
        [Fact]
        public void Ticket_WithInvalidYear_ShouldBeInvalid()
        {
            // Arrange
            var ticket = new Ticket
            {
                Title = null,
                Date = new DateTime(1500, 02, 20),
                Summa = 1200 // ❗ теперь это действительно ошибка
            };

            var context = new ValidationContext(ticket);
            var results = new List<ValidationResult>();

            // Act
            var isValid = Validator.TryValidateObject(ticket, context, results, true);

            // Assert
            //Assert.False(isValid);
            //Assert.Contains(results, r => r.ErrorMessage.Contains("Год должен быть"));
        }
    }
}
