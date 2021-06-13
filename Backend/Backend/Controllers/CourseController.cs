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
    public class CourseController : ControllerBase
    {
        private ICourseService _courseService;
        public CourseController(ICourseService service)
        {
            _courseService = service;
        }
        [HttpGet("{id}", Name = "GetCourse")]
        public ActionResult <CourseDTO>GetCourse(Guid id)
        {
            return Ok(_courseService.GetCourse(id));
        }

        [HttpGet(Name = "GetAllCourses")]
        public ActionResult <IEnumerable<CourseDTO>> GetAllCourses()
        {
            return Ok(_courseService.GetAll());
        }


        [HttpPost]
        public ActionResult AddCourse([FromBody] CourseDTORequest course)
        {
            return Created("GetCourse", _courseService.AddCourse(course));
        }

        [HttpPut("{id}")]
        public ActionResult ModifyCourse(Guid id, [FromBody] CourseDTORequest value)
        {
            _courseService.UpdateCourse(id, value);
            return NoContent();
        }

      
       
    }
}
