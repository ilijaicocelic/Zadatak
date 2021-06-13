using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceContracts.DTO
{
    public class UserDTORequest
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string IndexNumber { get; set; }

        public uint Year { get; set; }

        public string Password { get; set; }

        public string Username { get; set; }

        public string Role { get; set; }

        public string Status { get; set; }
    }
}
