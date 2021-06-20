using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceContracts.DTO;
using ServiceContracts.Interfaces;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userservice;
        public UserController(IUserService service)
        {
            _userservice = service;
        }

        // GET: api/User/5
        [HttpGet]
        [Route("GetUser/{id}")]
        public ActionResult <UserDTO> GetUser(Guid id)
        {
            return Ok(_userservice.GetUser(id));
        }

        [HttpGet]
        [Route("GetAllUsers")]
        public ActionResult< IEnumerable<UserDTO>> GetAllUsers()
        {
            return Ok(_userservice.GetAllUsers());
        }

        // POST: api/User
        [HttpPost]
        [Route("AddUser")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult AddUser(UserDTORequest user)
        {
            return Created("GetUser",_userservice.AddUser(user));
        }

        // PUT: api/User/5
        [HttpPut]
        [Route("ModifyStudent/{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult ModifyStudent(Guid id, UserDTORequest value)
        {
            _userservice.ModifyStudent(id, value);
            return NoContent();
        }

        [HttpPost]
        [Route("Login")]
        public ActionResult Login( LoginFormDTO form)
        {
            var data = _userservice.Login(form);
            if (data != null)
                return Ok(data);
            else
                return BadRequest();
        }

    }
}
