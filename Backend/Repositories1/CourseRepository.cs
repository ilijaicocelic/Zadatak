using RepositoryServiceContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;

using Microsoft.EntityFrameworkCore;

using System.Threading.Tasks;

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

        public Guid AddStudentToCourse(Guid UserId, Guid CourseId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Course> GetAll()
        {
            return _context.Courses;
        }

        public Course GetCourse(Guid Id)
        {
            return _context.Courses.Find(Id); ;
        }

        public IEnumerable<User> GetStudents(Guid CourseId)
        {
            return _context.Courses.Include(x => x.Students).Where(x => x.Id == CourseId).First().Students;
        }

        public void RemoveStudentFromCourse(Guid UserId, Guid CourseId)
        {
            User u1 = _context.Users.Find(UserId);
            _context.Courses.Include(x => x.Students).Where(x => x.Id == CourseId).First().Students.Remove(u1);
            _context.SaveChanges();
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
