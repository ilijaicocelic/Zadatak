using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RepositoryServiceContract
{
    public class Course
    {
        public Course(Guid id, string name, string teacher)
        {
            Id = id;
            Name = name;
            Teacher = teacher;
        }

        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Teacher { get; set; }


    }
}
