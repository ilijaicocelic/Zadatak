using ServiceContracts.DTO;
using ServiceContracts.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public class CourseService : ICourseService
    {
        public Guid AddCourse(CourseDTORequest course)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CourseDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public CourseDTO GetCourse(Guid Id)
        {
            throw new NotImplementedException();
        }

        public void UpdateCourse(Guid Id, CourseDTORequest course)
        {
            throw new NotImplementedException();
        }
    }
}
