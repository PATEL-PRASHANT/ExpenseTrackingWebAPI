using ExpenseTrackingAPI.Models.Model;
using ExpenseTrackingAPI.Services.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTrackingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("GetAllUser")]
        public async Task<ActionResult<List<UserModel>>> GetAllUser()
        {
            List<UserModel> userModelList = new List<UserModel>();
            try
            {
                userModelList = await _userService.GetAllUser();
                if (userModelList[0].UserID == 0)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return NotFound();
            }
            return Ok(userModelList);
        }

        [HttpGet("GetUser/{UserID}")]
        public async Task<ActionResult<UserModel>> GetUser(Int32 UserID)
        {
            UserModel userModel = new UserModel();
            try
            {
                userModel = await _userService.GetUser(UserID);
                if (userModel.UserID == 0)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(userModel);
        }

        [HttpPost("AddUser")]
        public async Task<ActionResult<UserModel>> AddUser(UserModel userModel)
        {
            try
            {
                await _userService.AddUser(userModel);                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        [HttpPut("UpdateUser")]
        public async Task<ActionResult> UpdateUser(UserModel userModel)
        {
            try
            {
                await _userService.UpdateUser(userModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        [HttpDelete("DeleteUser/{UserID}")]
        public async Task<ActionResult> DeleteUser(Int32 UserID)
        {
            try
            {
                await _userService.DeleteUser(UserID);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }
    }

}
