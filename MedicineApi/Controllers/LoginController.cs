using MedicineApi.Data.Enums;
using MedicineApi.Data.Interfaces;
using MedicineApi.Models.UserLoginModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineApi.Controllers
{
    [Route("api/user")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUserManager<UserLoginInfo> _userLoginManager;
        private readonly ILogger _logger;
        public LoginController(IUserManager<UserLoginInfo> userManager, ILogger<LoginController> logger)
        {
            _userLoginManager = userManager ?? throw new ArgumentNullException($"Login Manager was not injected {typeof(LoginController)}");
            _logger = logger ?? throw new ArgumentNullException($"Logger was not injected {typeof(LoginController)}");

        }

        /// <summary>
        /// Retrieves a medicinecard for the given user.
        /// </summary>
        /// <param name="cprNumber">The users cpr numbers</param>
        /// <returns>The medicinecard specified by the cpr number</returns>
        [HttpGet("Login")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<string>> Login(string username, string password)
        {
            //checking if username and password is not null or empty
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return BadRequest("Username or Password is not valid");

            try
            {
                //logging the user  in
                if (await _userLoginManager.LoginAsync(username, password))
                {
                    //Checking the user
                    var user = await _userLoginManager.GetUserByIDAsync(username);
                    //creating a token 
                    await _userLoginManager.GenerateTokenAsync(user);
                    //Validating if the generated token is ok
                    if (await _userLoginManager.ValidateTokenAsync(user))
                        //returning the token
                        return user.Token;
                    //if token not valid return unauthorized
                    else return Unauthorized();
                }
                else
                {
                    //return not forund
                    return NotFound();
                }
            }
            catch (ArgumentException e)
            {
                _logger.LogError("Bad request for login " + e.Message);
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                _logger.LogError("Could not perform request login" + e.Message);
                return Problem(e.Message, e.Source, 500, e.InnerException.HResult.ToString());
            }
        }

        [HttpGet("IsTokenValid")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<bool>> ValidateToken(string userID)
        {
            try
            {
                //Check if userid is null or empty
                if (string.IsNullOrEmpty(userID))
                    return BadRequest("Userid is null or empty");
                //Gets user by id and validating user token. if valid return true if not return unauthorized
                if (await _userLoginManager.ValidateTokenAsync(await _userLoginManager.GetUserByIDAsync(userID)))
                    return true;
                else return Unauthorized();
            }
            catch (ArgumentException e)
            {
                _logger.LogError("Bad request for login " + e.Message);
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                _logger.LogError("Could not perform request login" + e.Message);
                return Problem(e.Message, e.Source, 500, e.InnerException.HResult.ToString());
            }
        }

        [HttpGet("getrole")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Role>> GetRole(string UserID)
        {
            try
            {
                //Check if userid is null or empty
                if (string.IsNullOrEmpty(UserID))
                    return BadRequest("Userid is null or empty");
                //Gets user by id and validating user token. if valid return true if not return unauthorized
                var user = await _userLoginManager.GetUserByIDAsync(UserID);
                //Validating the token to be sure that login is valid
                if (await _userLoginManager.ValidateTokenAsync(user))
                {
                    //Getting the user role and returning it
                    return await _userLoginManager.GetRoleAsync(UserID);
                }
                else return Unauthorized();
            }
            catch (ArgumentException e)
            {
                _logger.LogError("Bad request for login " + e.Message);
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                _logger.LogError("Could not perform request login" + e.Message);
                return Problem(e.Message, e.Source, 500, e.InnerException.HResult.ToString());
            }
        }

        [HttpGet("setrole")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<bool>> SetRole(string userID, Role role)
        {
            try
            {
                //Check if userid is null or empty
                if (string.IsNullOrEmpty(userID))
                    return BadRequest("Userid is null or empty");
                //Gets user by id and validating user token. if valid return true if not return unauthorized
                var user = await _userLoginManager.GetUserByIDAsync(userID);
                if (await _userLoginManager.ValidateTokenAsync(user))
                {
                    //Setting User role
                    return await _userLoginManager.SetRoleAsync(user, role);
                }
                else return Unauthorized();
            }
            catch (ArgumentException e)
            {
                _logger.LogError("Bad request for login " + e.Message);
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                _logger.LogError("Could not perform request login" + e.Message);
                return Problem(e.Message, e.Source, 500, e.InnerException.HResult.ToString());
            }
        }
    }
}
