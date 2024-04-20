using Backend.Models;

namespace Backend.Services
{
    public interface IBookService
    {
        List<Book> GetAllBooks();
        Book? GetBookById(int id);
        Book AddBook(AddUpdateBook obj);
        Book? UpdateBook(int id, AddUpdateBook obj);
        Book DeleteBookById(int id);
    }
}
