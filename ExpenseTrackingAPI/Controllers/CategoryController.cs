using ExpenseTrackingAPI.BRule.BusinessLayer.Categorie;
using ExpenseTrackingAPI.Models.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTrackingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategory _category;

        public CategoryController(ICategory category)
        {
            _category = category;
        }

        [HttpGet("Category")]
        public async Task<ActionResult<List<CategoryModel>>> Category()
        {
            List<CategoryModel> categoryModelList = new List<CategoryModel>();
            try
            {
                categoryModelList = await _category.GetCategory();

                if (categoryModelList == null)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
            return Ok(categoryModelList);
        }

        [HttpPost("Category")]
        public async Task<ActionResult> Category(CategoryModel categoryModel)
        {
            try
            {
                await _category.InsertGetCategory(categoryModel);

            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
            return Ok();
        }

        [HttpPut("UpdateCategory")]
        public async Task<ActionResult> UpdateCategory(CategoryModel categoryModel)
        {
            try
            {
                await _category.UpdateCategory(categoryModel);

            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
            return Ok();
        }

        [HttpDelete("DeleteCategory/{CategoryID}")]
        public async Task<ActionResult> DeleteCategory(Int32 CategoryID)
        {
            try
            {
                await _category.DeleteCategory(CategoryID);

                
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
            return Ok();
        }
    }
}
