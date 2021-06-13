using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        [HttpGet("{id}", Name = "GetUser")]
        public ActionResult <UserDTO> GetUser(Guid id)
        {
            return Ok(_userservice.GetUser(id));
        }

        [HttpGet( Name = "GetAllUsers")]
        public ActionResult< IEnumerable<UserDTO>> GetAllUsers()
        {
            return Ok(_userservice.GetAllUsers());
        }

        // POST: api/User
        [HttpPost]
        public ActionResult AddUser([FromBody] UserDTORequest user)
        {
            return Created("GetUser",_userservice.AddUser(user));
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public ActionResult ModifyStudent(Guid id, [FromBody] UserDTORequest value)
        {
            _userservice.ModifyStudent(id, value);
            return NoContent();
        }

        [HttpPost]
        public ActionResult Login([FromBody] LoginFormDTO form)
        {
            return Ok(_userservice.Login(form));
        }

    }
}
