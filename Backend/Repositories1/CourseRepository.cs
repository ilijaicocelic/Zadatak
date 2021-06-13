using RepositoryServiceContract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories
{
    public class CourseRepository : ICourseRepository
    {
        public Guid AddCourse(Course course)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Course> GetAll()
        {
            throw new NotImplementedException();
        }

        public Course GetCourse(Guid Id)
        {
            throw new NotImplementedException();
        }

        public void UpdateCourse(Course course)
        {
            throw new NotImplementedException();
        }
    }
}
