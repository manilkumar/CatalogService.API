using CatalogService.API.Controllers;
using CatalogService.API.Data.Interfaces;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.API.Tests
{
    public class TestBase
    {
        public CatalogController catalogController;

        public TestBase()
        {
            var loggerMock = new Mock<ILogger<CatalogController>>();
            var catalogRepoMock = new Mock<ICatalogRepository>();

            catalogController = new CatalogController(catalogRepoMock.Object, loggerMock.Object);
        }
    }
}
