using Registone.LogCenter.Api.Configurations;
using Registone.LogCenter.Domain.DataTransferObjects;
using Registone.LogCenter.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Text;

namespace Registone.LogCenter.Api.Controllers
{
    [Route("api/account")]
    [ApiController]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        #region Properties

        private readonly IUserService _service;
        private readonly AppSettings _appSettings;

        #endregion

        #region Constructor

        public AuthController(IUserService service, IOptions<AppSettings> appSettings)
        {
            _service = service;
            _appSettings = appSettings.Value;
        }

        #endregion

        #region Actions

        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public ActionResult Register(UserDto user)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                _service.Register(user);
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex.Message);
            }
                        
            return Created(string.Empty, user.Email);
        }

        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Authenticate([FromBody] UserDto user)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                var result = _service.Authenticate(user, Encoding.ASCII.GetBytes(_appSettings.SecretKey));

                if (result is null)
                {
                    return BadRequest();
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }    
        }

        #endregion
    }
}
