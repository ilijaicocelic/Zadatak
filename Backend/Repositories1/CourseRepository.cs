using RepositoryServiceContract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories
{
    public class CourseRepository : ICourseRepository
    {

        private DataBaseDB _context;

        public CourseRepository(DataBaseDB dataContext)
        {
            _context = dataContext;
        }
        public Guid AddCourse(Course course)
        {
            _context.Courses.Add(course);
            _context.SaveChanges();
            return course.Id;
        }

        public IEnumerable<Course> GetAll()
        {
            return _context.Courses;
        }

        public Course GetCourse(Guid Id)
        {
            return _context.Courses.Find(Id); ;
        }

        public void UpdateCourse(Course course)
        {
            Course CourseForUpdate = _context.Courses.Find(course.Id);

            if (CourseForUpdate == null)
            {
                throw new KeyNotFoundException();
            }
            CourseForUpdate.Name = course.Name;
            CourseForUpdate.Teacher = course.Teacher;

            _context.Entry(CourseForUpdate).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
