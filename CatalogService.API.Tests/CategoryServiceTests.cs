using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.API.Tests
{
    [TestClass]
    public class CategoryServiceTests : TestBase
    {
        [TestMethod]
        public async Task GetCategories()
        {
            var category = await catalogController.GetCategories();

            Assert.IsNotNull(category);
        }

        [TestMethod]
        public async Task GetItems()
        {
            int categoryId = 1;

            var items = await catalogController.GetItems(categoryId, 1, 10);

            Assert.IsNotNull(items);
        }

    }
}
