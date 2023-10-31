using CatalogService.API.Entities;

namespace CatalogService.API.Data.Interfaces
{
    public interface ICatalogRepository
    {
        Task<List<Category>> GetCategories();
        Task<object?> AddCategory(Category category);
        Task UpdateCategory(Category category);
        Task DeleteCategory(int categoryId);
        Task<List<Item>> GetItems(int categoryId, int startPage, int endPage);
        Task<object?> AddItem(Item item);
        Task UpdateItem(Item item);
        Task DeleteItem(int categoryId, int itemId);
        Task<Category> GetCategory(int categoryId);
        Task<Item> GetItem(int categoryId, int itemId);
    }
}
