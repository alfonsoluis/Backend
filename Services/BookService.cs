using Backend.Entity;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services
{
    public class BookService : IBookService
    {
        private readonly BookDbContext _context;

        public BookService(BookDbContext context) { _context = context; }

        public async Task<List<Book>> GetAllBooks()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<Book?> GetBookById(int id)
        {
            return await _context.Books.FirstOrDefaultAsync(book => book.Id == id);
        }

        public async Task<Book?> AddBook(AddUpdateBook obj)
        {
            var addBook = new Book()
            {
                Title = obj.Title,
                Author = obj.Author,
                Genre = obj.Genre,
                PublishDate = obj.PublishDate,
            };

            _context.Books.Add(addBook);
            var result = await _context.SaveChangesAsync();
            return result >= 0 ? addBook : null;
        }

        public async Task<Book?> UpdateBook(int id, AddUpdateBook obj)
        {
            var book = await _context.Books.FirstOrDefaultAsync(index => index.Id == id);

            if (book != null)
            {
                book.Title = obj.Title;
                book.Author = obj.Author;
                book.Genre = obj.Genre;
                book.PublishDate = obj.PublishDate;

                var result = await _context.SaveChangesAsync();
                return result >= 0 ? book : null;
            }
            return null;
        }

        public async Task<bool> DeleteBookById(int id)
        {
            var book = await _context.Books.FirstOrDefaultAsync(index => index.Id == id);
            if (book != null)
            {
                _context.Books.Remove(book);
                var result = await _context.SaveChangesAsync();
                return result >= 0;
            }
            return false;
        }

    }
}
