using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceContracts.DTO
{
    public class SimplifiedCourseDTO
    {
        public SimplifiedCourseDTO(Guid value, string text)
        {
            Value = value;
            Text = text;
        }

        public Guid Value { get; set; }

        public string Text { get; set; }
    }
}
