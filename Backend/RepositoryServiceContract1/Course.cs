﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RepositoryServiceContract
{
    public class Course
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Teacher { get; set; }


    }
}
