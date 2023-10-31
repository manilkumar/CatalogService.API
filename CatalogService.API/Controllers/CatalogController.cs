using CatalogService.API.Data.Interfaces;
using CatalogService.API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CatalogService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly ILogger<CatalogController> logger;
        private readonly ICatalogRepository catalogRepository;

        public CatalogController(ICatalogRepository catalogRepository, ILogger<CatalogController> logger)
        {
            this.catalogRepository = catalogRepository;
            this.logger = logger;
        }

        // GET: api/<CatalogController>
        [HttpGet]
        [Route("Category/GetCategory/{categoryId}")]
        public async Task<IActionResult> GetCategory(int categoryId)
        {
            if (categoryId <= 0)
            {
                return BadRequest("Invalid Category Id");
            }

            try
            {
                var result = await catalogRepository.GetCategory(categoryId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // GET: api/<CatalogController>
        [HttpGet]
        [Route("Category/GetCategories")]
        public async Task<IActionResult> GetCategories()
        {
            try
            {
                var result = await catalogRepository.GetCategories();
                return Ok(result);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

            }
        }

        // POST api/<CatalogController>
        [HttpPost]
        [Route("Category/AddCategory")]
        public async Task<IActionResult> AddCategory([FromBody] Category entity)
        {
            try
            {
                var result = await catalogRepository.AddCategory(entity);
                return Ok(result);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

            }
        }

        // POST api/<CatalogController>
        [HttpPost]
        [Route("Category/UpdateCategory")]
        public async Task<IActionResult> UpdateCategory([FromBody] Category entity)
        {
            try
            {
                await catalogRepository.UpdateCategory(entity);
                return Ok();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

            }
        }

        // DELETE api/<CatalogController>/delete/5
        [HttpDelete("Category/DeleteCategory/{categoryId}")]
        public async Task<IActionResult> DeleteCategory(int categoryId)
        {
            try
            {
                await catalogRepository.DeleteCategory(categoryId);
                return Ok();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

            }
        }

        // GET: api/<CatalogController>
        [HttpGet]
        [Route("Item/GetItem/{categoryId}/{itemId}")]
        public async Task<IActionResult> GetItem(int categoryId, int itemId)
        {
            if (itemId <= 0)
            {
                return BadRequest("Invalid Item Id");
            }

            try
            {
                var result = await catalogRepository.GetItem(categoryId, itemId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

            }
        }

        // GET: api/<CatalogController>
        [HttpGet]
        [Route("Item/GetItem/{categoryId}/{start}/{end}")]
        public async Task<IActionResult> GetItems(int categoryId, int start, int end)
        {
            if (categoryId <= 0)
            {
                return BadRequest("Invalid Category Id");
            }

            try
            {
                var result = await catalogRepository.GetItems(categoryId, start, end);
                return Ok(result);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // POST api/<CatalogController>
        [HttpPost]
        [Route("Item/AddItem")]
        public async Task<IActionResult> AddItem([FromBody] Item entity)
        {
            try
            {
                var result = await catalogRepository.AddItem(entity);
                return Ok(result);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // POST api/<CatalogController>
        [HttpPost]
        [Route("Item/UpdateItem")]
        public async Task<IActionResult> UpdateItem([FromBody] Item entity)
        {
            try
            {
                await catalogRepository.UpdateItem(entity);
                return Ok();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // DELETE api/<CatalogController>/delete/1/2
        [HttpDelete("Item/DeleteItem/{catergoryId}/{itemId}")]
        public async Task<IActionResult> DeleteItem(int categoryId, int itemId)
        {
            if (itemId <= 0)
            {
                return BadRequest("Invalid Item Id");
            }
            try
            {
                await catalogRepository.DeleteItem(categoryId, itemId);
                return Ok();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
