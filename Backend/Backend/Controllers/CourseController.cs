using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public string GetCourse(int id)
        {
            return "value";
        }

        [HttpGet(Name = "GetAllCourses")]
        public string GetAllCourses(int id)
        {
            return "value";
        }


        [HttpPost]
        public void AddCourse([FromBody] string value)
        {
        }

        [HttpPut("{id}")]
        public void ModifyCourse(int id, [FromBody] string value)
        {
        }

      
       
    }
}
