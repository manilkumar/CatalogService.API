using CatalogService.API.Data.Interfaces;
using CatalogService.API.Entities;
using CatalogService.API.Models;
using Microsoft.EntityFrameworkCore;

namespace CatalogService.API.Data.Repositories
{
    public class CatalogRepository : ICatalogRepository
    {
        public CatalogDBContext _context;

        public CatalogRepository(CatalogDBContext context)
        {
            _context = context;
        }

        public async Task<object?> AddCategory(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();

            var categories = await _context.Categories.ToListAsync();

            if (categories != null && categories.Any())
            {
                var links = new List<Link>();

                foreach (var cat in categories)
                {
                    links.Add(new Link { Rel = "self", Href = $"/Category/GetCategory/{cat.Id}" });
                }

                return new {  Links = links };
            }

            return null;
        }

        public async Task DeleteCategory(int categoryId)
        {
            var categoryItems = await _context.Items.Where(i => i.CategoryId == categoryId).ToListAsync();

            if (categoryItems.Any())
            {
                _context.Items.RemoveRange(categoryItems);
            }

            var category = await _context.Categories.Where(i => i.Id == categoryId).FirstOrDefaultAsync();

            if (category != null)
            {
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Category>> GetCategories()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task UpdateCategory(Category category)
        {

            var categoryToUpdate = await _context.Categories.Where(i => i.Id == category.Id).FirstOrDefaultAsync();

            if (categoryToUpdate != null)
            {
                categoryToUpdate.Name = category.Name;
                categoryToUpdate.ImageURL = category.ImageURL;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Category> GetCategory(int categoryId)
        {
            var category = await _context.Categories.Where(i => i.Id == categoryId).FirstOrDefaultAsync();

            return category;
        }

        public async Task<object?> AddItem(Item item)
        {
            await _context.Items.AddAsync(item);
            await _context.SaveChangesAsync();

            var items = await _context.Items.Where(i => i.CategoryId == item.CategoryId).ToListAsync();

            if (items != null && items.Any())
            {
                var links = new List<Link>();

                foreach (var i in items)
                {
                    links.Add(new Link { Rel = "self", Href = $"/item/{i.Id}" });
                }

                return new { CateogryId = item.CategoryId, Links = links };
            }

            return null;
        }

        public async Task DeleteItem(int categoryId, int itemId)
        {
            var item = await _context.Items.Where(i => i.CategoryId == categoryId && i.Id == itemId).FirstOrDefaultAsync();

            if (item != null)
            {
                _context.Items.Remove(item);
            }
        }

        public async Task<List<Item>> GetItems(int categoryId, int startPage, int endPage)
        {
            var items = await _context.Items.Where(i => i.CategoryId == categoryId).Skip(startPage).Take(endPage).ToListAsync();

            return items;
        }

        public async Task<Item> GetItem(int categoryId, int itemId)
        {
            var item = await _context.Items.Where(i => i.CategoryId == categoryId && i.Id == itemId).FirstOrDefaultAsync();

            return item;
        }

        public async Task UpdateItem(Item item)
        {
            var itemToUpdate = await _context.Items.Where(i => i.Id == item.Id).FirstOrDefaultAsync();

            if (itemToUpdate != null)
            {
                itemToUpdate.Name = item.Name;
                itemToUpdate.ImageURL = item.ImageURL;
                await _context.SaveChangesAsync();
            }
        }
    }
}
