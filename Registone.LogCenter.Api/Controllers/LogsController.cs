using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Registone.LogCenter.Domain.DataTransferObjects;
using Registone.LogCenter.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace Registone.LogCenter.Api.Controllers
{
    [Route("api/log")]
    [Authorize]
    [ApiController]  
    public class LogsController : ControllerBase
    {
        #region Properties

        private readonly ILogService Service;
       
        #endregion

        #region Constructor

        public LogsController(ILogService service)
        {
            Service = service;      
        }

        #endregion

        #region Actions

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public ActionResult<IList<LogDto>> Get()
        {
            try
            {
                return Ok(Service.GetLogs());
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
            
        }

        [HttpGet("fileds")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public ActionResult<IList<LogDto>> GetLogsFiled()
        {
            try
            {
                return Ok(Service.GetLogsFiled());
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        [HttpGet("title/{title}"), ActionName("title")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public ActionResult<IList<LogDto>> GetByTitle(string title)
        {
            if (string.IsNullOrEmpty(title)) return BadRequest("Title is required");

            try
            {
                return Ok(Service.FindByTitle(title));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("level/{level}"), ActionName("level")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public ActionResult<IList<LogDto>> GetByLevel(string level)
        {
            if (string.IsNullOrEmpty(level)) return BadRequest("Level is required");

            try
            {
                return Ok(Service.GetLogs());
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("origin/{origin}"), ActionName("origin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public ActionResult<IList<LogDto>> GetByOrigin(string origin)
        {
            if (string.IsNullOrEmpty(origin)) return BadRequest("Origin is required");
            try
            {
                return Ok(Service.GetLogs());
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public ActionResult Post([FromBody] LogRegisterDto log)
        {
            try
            {
                Service.Register(log);
                return Created(string.Empty, log);
            }
            catch (Exception)
            {
                return UnprocessableEntity(log);
            }

        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public ActionResult Put(int id)
        {
            try
            {
                Service.ArchiveLog(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public ActionResult Delete(int id)
        {
            try
            {
                Service.Remove(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        #endregion
    }
}
