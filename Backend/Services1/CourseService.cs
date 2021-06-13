using RepositoryServiceContract;
using ServiceContracts.DTO;
using ServiceContracts.Interfaces;
using Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public class CourseService : ICourseService
    {

        private CourseMapper _courseMapper;
        private ICourseRepository _courseRepository;
        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
            _courseMapper = new CourseMapper();
        }
        public Guid AddCourse(CourseDTORequest course)
        {
            return _courseRepository.AddCourse(_courseMapper.FromDTOCourseToCourse(course));
        }

        public IEnumerable<CourseDTO> GetAll()
        {
            return _courseMapper.ListCourseToListDTO(_courseRepository.GetAll());
        }
    

        public CourseDTO GetCourse(Guid Id)
        {
            return _courseMapper.FromCourseToDTO(_courseRepository.GetCourse(Id));
        }

        public void UpdateCourse(Guid Id, CourseDTORequest course)
        {
            Course c1 = _courseMapper.FromDTOCourseToCourse(course);
            c1.Id = Id;
            _courseRepository.UpdateCourse(c1);
        }
    }
}
