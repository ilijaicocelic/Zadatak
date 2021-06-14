using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
    public class CourseController : ControllerBase
    {
        private ICourseService _courseService;
        public CourseController(ICourseService service)
        {
            _courseService = service;
        }
        [HttpGet]
        [Route("GetCourse/{id}")]
        public ActionResult <CourseDTO>GetCourse(Guid id)
        {
            return Ok(_courseService.GetCourse(id));
        }

        [HttpGet]
        [Route("GetAllCourses")]
        public ActionResult <IEnumerable<CourseDTO>> GetAllCourses()
        {
            return Ok(_courseService.GetAll());
        }


        [HttpPost]
        [Route("AddCourse")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult AddCourse(CourseDTORequest course)
        {
            return Created("GetCourse", _courseService.AddCourse(course));
        }

        [HttpPut]
        [Route("GetAllCourses/{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult ModifyCourse(Guid id, [FromBody] CourseDTORequest value)
        {
            _courseService.UpdateCourse(id, value);
            return NoContent();
        }


        [HttpGet]
        [Route("GetStudents/{Id}")]
        public ActionResult<IEnumerable<CourseDTO>> GetStudents(Guid Id)
        {
           
            return Ok(_courseService.GetStudents(Id));
        }

        [HttpPut]
        [Route("AddStudent/{userId}/{CourseId}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult AddStudent(Guid userId, Guid CourseId)
        {
            _courseService.AddStudentToCourse(userId, CourseId);
            return NoContent();
        }

        [HttpDelete]
        [Route("RemoveStudent/{userId}/{CourseId}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

        public ActionResult RemoveStudent(Guid userId, Guid CourseId)
        {
            _courseService.RemoveStudentFromCourse(userId, CourseId);
            return Ok();
        }



    }
}
