using Backend.Models;

namespace Backend.Services
{
    public interface IBookService
    {
        Task<List<Book>> GetAllBooks();
        Task<Book?> GetBookById(int id);
        Task<Book?> AddBook(AddUpdateBook obj);
        Task<Book?> UpdateBook(int id, AddUpdateBook obj);
        Task<bool> DeleteBookById(int id);
    }
}
