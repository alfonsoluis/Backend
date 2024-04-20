using Backend.Models;

namespace Backend.Services
{
    public class BookService : IBookService
    {
        private readonly List<Book> _bookList;

        public BookService()
        {
            _bookList = new List<Book>()
            {
                new Book()
                {
                    Id = 1,
                    Title = "The Name of The Wind",
                    Author = "Patrick Rothfus",
                    Genre = "Fantasy",
                    PublisDate = new DateTime(2007, 3, 27)
                }
            };
        }

        public List<Book> GetAllBooks()
        {
            return _bookList;
        }

        public Book? GetBookById(int id)
        {
            return _bookList.FirstOrDefault(book => book.Id == id);
        }

        public Book AddBook(AddUpdateBook obj)
        {
            var newBook = new Book()
            {
                Id = _bookList.Max(book => book.Id) + 1,
                Title = obj.Title,
                Author = obj.Author,
                Genre = obj.Genre,
                PublisDate = obj.PublisDate
            };

            _bookList.Add(newBook);

            return newBook;
        }

        public Book? UpdateBook(int id, AddUpdateBook obj)
        {
            var bookIndex = _bookList.FindIndex(book => book.Id == id);

            if (bookIndex > 0)
            {
                var book = _bookList[bookIndex];

                book.Title = obj.Title;
                book.Author = obj.Author;
                book.Genre = obj.Genre;
                book.PublisDate = obj.PublisDate;

                _bookList[bookIndex] = book;

                return book;
            }
            else 
            {
                return null;
            }
        }

        public Book DeleteBookById(int id)
        {
            var book = _bookList.FirstOrDefault(book => book.Id == id);

            if (book != null)
            {
                _bookList.Remove(book);
            }

            return book;
        }   
    }
}
