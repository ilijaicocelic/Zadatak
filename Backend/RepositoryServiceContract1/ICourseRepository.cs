using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryServiceContract
{
    public interface ICourseRepository
    {
         Course GetCourse(Guid Id);

        void UpdateCourse(Course course);

        Guid AddCourse(Course course);

        IEnumerable<Course> GetAll();

        IEnumerable<User> GetStudents(Guid CourseId);

        void AddStudentToCourse(Guid UserId, Guid CourseId);

        void RemoveStudentFromCourse(Guid UserId, Guid CourseId);
    }
}
