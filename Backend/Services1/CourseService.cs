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
        private UserMapper _userMapper;
        private ICourseRepository _courseRepository;
        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
            _courseMapper = new CourseMapper();
            _userMapper = new UserMapper();
        }
        public Guid AddCourse(CourseDTORequest course)
        {
            return _courseRepository.AddCourse(_courseMapper.FromDTOCourseToCourse(course));
        }

        public void AddStudentToCourse(Guid UserId, Guid CourseId)
        {
            _courseRepository.AddStudentToCourse(UserId, CourseId);
        }

        public IEnumerable<CourseDTO> GetAll()
        {
            return _courseMapper.ListCourseToListDTO(_courseRepository.GetAll());
        }
    

        public CourseDTO GetCourse(Guid Id)
        {
            return _courseMapper.FromCourseToDTO(_courseRepository.GetCourse(Id));
        }

        public IEnumerable<UserDTO> GetStudents(Guid CourseId)
        {
            return _userMapper.ListUsertToListDTO(_courseRepository.GetStudents(CourseId));
        }

        public void RemoveStudentFromCourse(Guid UserId, Guid CourseId)
        {
            _courseRepository.RemoveStudentFromCourse(UserId, CourseId);
        }

        public void UpdateCourse(Guid Id, CourseDTORequest course)
        {
            Course c1 = _courseMapper.FromDTOCourseToCourse(course);
            c1.Id = Id;
            _courseRepository.UpdateCourse(c1);
        }
    }
}
