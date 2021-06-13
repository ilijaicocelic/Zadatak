using RepositoryServiceContract;
using ServiceContracts.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services
{
    public class CourseMapper
    {
        public CourseDTO FromCourseToDTO(Course course)
        {

            return new CourseDTO(course.Id, course.Name, course.Teacher);

        }

        public IEnumerable<CourseDTO> ListCourseToListDTO(IEnumerable<Course> courseList)
        {
            return courseList.Select(course => FromCourseToDTO(course)).ToList();
        }

        public Course FromDTOCourseToCourse(CourseDTORequest courseDTO)
        {
            return new Course(Guid.NewGuid(), courseDTO.Name, courseDTO.Teacher);
        }
    }
}
