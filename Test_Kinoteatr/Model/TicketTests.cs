using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Kinoteatr.Model
{
    internal class TicketTests
    {
        [Fact]
        public void Book_WithValidData_ShouldBeValid()
        {
            // Создаем объект книги с валидными значениями.
            var ticket = new Ticket
            {
                Title = "C# in Depth",     // Обязательное поле, строка < 100 символов
                Viewer = new Viewer { Name = "Пушкин"},      // Обязательное поле, строка < 100 символов
                Date = 2020,               // В пределах допустимого диапазона 1000–2100
            };

            // Создаем контекст валидации на основе объекта
            var context = new ValidationContext(book);

            // Сюда будут записаны ошибки валидации, если они есть
            var result = new List<ValidationResult>();

            // Проводим валидацию объекта с учетом всех атрибутов [Required], [Range] и т.п.
            var isValid = Validator.TryValidateObject(book, context, result, true);

            // Ожидаем, что валидация прошла успешно (все поля корректны)
            Assert.True(isValid);

            // Также убеждаемся, что список ошибок пуст
            Assert.Empty(result);
        }

        // Тест проверяет, что если не указать заголовок, то объект будет невалиден.
        [Fact]
        public void Book_WithInvalidYear_ShouldBeInvalid()
        {
            // Arrange
            var book = new Book
            {
                Title = "Test Book",
                Author = new Author { Name = "Пушкин" },
                Year = 12 // ❗ теперь это действительно ошибка
            };

            var context = new ValidationContext(book);
            var results = new List<ValidationResult>();

            // Act
            var isValid = Validator.TryValidateObject(book, context, results, true);

            // Assert
            Assert.False(isValid);
            Assert.Contains(results, r => r.ErrorMessage.Contains("Год должен быть"));
        }
    }
}
