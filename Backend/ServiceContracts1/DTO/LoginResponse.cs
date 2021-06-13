using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceContracts.DTO
{
    public class LoginResponse
    {
        public string token { get; set; }

        public UserDTO user { get; set; } 
    }
}
