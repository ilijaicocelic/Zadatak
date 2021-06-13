using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceContracts.DTO
{
    public class CourseDTO
    {
        public CourseDTO(Guid id, string name, string teacher)
        {
            Id = id;
            Name = name;
            Teacher = teacher;
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Teacher { get; set; }
    }
}
