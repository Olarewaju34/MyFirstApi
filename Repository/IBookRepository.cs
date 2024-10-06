using Microsoft.AspNetCore.JsonPatch;
using MyFirstApi.Model;

namespace MyFirstApi.Repository
{
    public interface IBookRepository
    {
        Task<List<BookModel>> GetAllbooksAsync();
        Task<BookModel> GetBookByIdAsync(int id);
        Task<int> AddAsync(BookModel books);
        Task UpdateBookAsync(int id, BookModel model);
        Task UpdateBookPatchAsync(int id, JsonPatchDocument model);
    }
}
