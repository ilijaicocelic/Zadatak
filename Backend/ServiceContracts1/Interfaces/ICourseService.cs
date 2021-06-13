using ServiceContracts.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceContracts.Interfaces
{
    public interface ICourseService
    {
        CourseDTO GetCourse(Guid Id);

       void UpdateCourse(Guid Id,CourseDTORequest course);

        Guid AddCourse(CourseDTORequest course);

        IEnumerable<CourseDTO> GetAll();

        void AddStudentToCourse(Guid UserId, Guid CourseId);

        void RemoveStudentFromCourse(Guid UserId, Guid CourseId);

        IEnumerable<UserDTO> GetStudents(Guid CourseId);


    }
}
