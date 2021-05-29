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
    }
}
