using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceContracts.DTO
{
    public class AddStudentDTO
    {
        public Guid userId { get; set; }

        public Guid courseId { get; set; }
    }
}
