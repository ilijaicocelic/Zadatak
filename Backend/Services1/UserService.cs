
using ServiceContracts.DTO;
using ServiceContracts.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public class UserService : IUserService
    {
        public Guid AddUser(UserDTORequest userDTO)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserDTO> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public UserDTO GetUser(Guid Id)
        {
            throw new NotImplementedException();
        }

        public string Login(LoginFormDTO loginFormDTO)
        {
            throw new NotImplementedException();
        }

        public void ModifyStudent(Guid Id, UserDTORequest userDTO)
        {
            throw new NotImplementedException();
        }
    }
}
