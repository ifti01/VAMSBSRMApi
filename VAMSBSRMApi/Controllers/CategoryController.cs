using Microsoft.AspNetCore.Mvc;
using VAMSBSRMApi.Application.Dtos;
using VAMSBSRMApi.Persistance.Services;

namespace VAMSBSRMApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryService _categoryService;
        public CategoryController(CategoryService categoryService) 
        {
            _categoryService = categoryService;
        }

        [HttpPost("CreateVehicleCategory")]
        public async Task<IActionResult> CreateVehicleCategory([FromBody] CreateVehicleCategoryDto categoryDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingCategory = await _categoryService.GetByNameAsync(categoryDto.Name);
            if (existingCategory != null)
            {
                return Conflict("Category already exists.");
            }

            var category = await _categoryService.CreateCategoryAsync(categoryDto);

            return CreatedAtAction(nameof(GetCategoryById), new { id = category.Id }, category);
        }

        [HttpGet("GetCategory")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        [HttpGet("GetCategoryList")]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();
            return Ok(categories);
        }

        [HttpDelete("DeleteVehicleCategory")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var success = await _categoryService.DeleteCategoryAsync(id);
            if (!success)
            {
                return NotFound(); // If category not found
            }

            return NoContent(); // Return 204 No Content on successful deletion
        }

    }
}
