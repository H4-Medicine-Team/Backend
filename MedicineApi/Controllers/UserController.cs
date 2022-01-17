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
    /// <summary>
    /// Controller for the user login, roles & tokens
    /// </summary>
    [Route("api/[controller]")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserManager<UserLoginInfo> _userLoginManager;
        private readonly ILogger _logger;
        /// <summary>
        /// construct manager and logger
        /// </summary>
        public UserController(IUserManager<UserLoginInfo> userManager, ILogger<UserController> logger)
        {
            _userLoginManager = userManager ?? throw new ArgumentNullException($"Login Manager was not injected {typeof(UserController)}");
            _logger = logger ?? throw new ArgumentNullException($"Logger was not injected {typeof(UserController)}");
        }
        /// <summary>
        /// Log the user in
        /// </summary>
        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<string>> LoginAsync(UserLogin userInfo)
        {
            if (userInfo == null)
                return BadRequest("Username or Password is not valid");
            //checking if username and password is not null or empty
            if (string.IsNullOrEmpty(userInfo.Username) || string.IsNullOrEmpty(userInfo.Password))
                return BadRequest("Username or Password is not valid");
            try
            {
                //trying to login the user in, return BadRequest if wrong credentials
                if (!await _userLoginManager.LoginAsync(userInfo))
                    return BadRequest();
                else
                {
                    //Checking the user
                    var user = await _userLoginManager.GetUserByIDAsync(userInfo.Username);
                    //creating a token 
                    await _userLoginManager.GenerateTokenAsync(user);
                    //Validating if the generated token is ok then returning the token
                    if (await _userLoginManager.ValidateTokenAsync(user.UserToken))
                        return user.UserToken.Key;
                    //if token not valid return unauthorized
                    else return Unauthorized();
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
        /// <summary>
        /// Log the user in by token
        /// </summary>
        [HttpPost("tokenlogin")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<string>> LoginWithTokenAsync(Token token)
        {
            //checking if username and password is not null or empty

            if (token == null || string.IsNullOrEmpty(token.Key))
                return BadRequest();

            try
            {
                //logging the user  in
                if (await _userLoginManager.LoginWithTokenAsync(token))
                {
                    //Checking the user
                    var user = await _userLoginManager.GetUserWithTokenAsync(token);
                    //creating a token 
                    await _userLoginManager.GenerateTokenAsync(user);
                    //Validating if the generated token is ok
                    if (await _userLoginManager.ValidateTokenAsync(token))
                        //returning the token
                        return user.UserToken.Key;
                    //if token not valid return unauthorized
                    else return Unauthorized();
                }
                    //return not forund
                else
                    return NotFound();
                
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
        /// <summary>
        /// validate if current token timestamp is valid;
        /// </summary>
        [HttpGet("validtoken")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<bool>> ValidateTokenAsync(Token token)
        {
            try
            {
                //Check if userid is null or empty
                if (token == null || string.IsNullOrEmpty(token.Key))
                    return BadRequest("token is null or empty");
                //validating user token. if valid return true if not return unauthorized
                if (await _userLoginManager.ValidateTokenAsync(token))
                    return true;
                else return Unauthorized();
            }
            catch (Exception)
            {
                return Unauthorized();
            }
        }
        /// <summary>
        /// getting the user role
        /// </summary>
        [HttpGet("getrole")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Role>> GetRoleAsync(string UserID)
        {
            try
            {
                //Check if userid is null or empty
                if (string.IsNullOrEmpty(UserID))
                    return BadRequest("Userid is null or empty");
                //Gets user by id and validating user token. if valid return true if not return unauthorized
                var user = await _userLoginManager.GetUserByIDAsync(UserID);
                //Validating the token to be sure that login is valid
                if (await _userLoginManager.ValidateTokenAsync(user.UserToken))
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
        /// <summary>
        /// sets the user role
        /// </summary>
        [HttpPost("setrole")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<bool>> SetRoleAsync(string userID, Role role)
        {
            try
            {
                //Check if userid is null or empty
                if (string.IsNullOrEmpty(userID))
                    return BadRequest("Userid is null or empty");
                //Gets user by id and validating user token. if valid return true if not return unauthorized
                var user = await _userLoginManager.GetUserByIDAsync(userID);
                if (await _userLoginManager.ValidateTokenAsync(user.UserToken))
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
