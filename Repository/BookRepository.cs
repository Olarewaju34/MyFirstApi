using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using MyFirstApi.Data;
using MyFirstApi.Model;
using static System.Reflection.Metadata.BlobBuilder;

namespace MyFirstApi.Repository
{
    public class BookRepository(BookStoreContext _context) : IBookRepository
    {
        public async Task<List<BookModel>> GetAllbooksAsync()
        {
            var books = await _context.Books.Select(bk => new BookModel()
            {
                Id = bk.Id,
                Title = bk.Title,
                Description = bk.Description
            }).ToListAsync();


            return books;

        }       
        public async Task<BookModel> GetBookByIdAsync(int id)
        {
            var books = await _context.Books.Where(bk=>bk.Id==id).Select(bk => new BookModel()
            {
                Id = bk.Id,
                Title = bk.Title,
                Description = bk.Description
            }).FirstOrDefaultAsync();


            return books;

        }
        public async Task<int> AddAsync(BookModel books)
        {
;
          var book = new Books()
          {
              Title = books.Title,
              Description = books.Description,
          };
            await _context.AddAsync(book);
            await _context.SaveChangesAsync();
            return book.Id;
        }
        public async Task UpdateBookAsync(int id, BookModel model)
        {
            var book = new Books()
            {
                Id = id,
                Title = model.Title,
                Description = model.Description,
            };
            _context.Books.Update(book);
            await _context.SaveChangesAsync();
            
        }

        public async Task UpdateBookPatchAsync(int id, JsonPatchDocument model)
        {
            var book = await _context.Books.FindAsync(id);  
            if(book is not null)
            {
                model.ApplyTo(book);
                await _context.SaveChangesAsync();
            }
        }
    }
}
