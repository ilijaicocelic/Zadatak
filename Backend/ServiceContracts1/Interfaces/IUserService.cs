using ServiceContracts.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceContracts.Interfaces
{
    public interface IUserService
    {

        string Login(LoginFormDTO loginFormDTO);

        UserDTO GetUser(Guid Id);

        IEnumerable<UserDTO> GetAllUsers();

        void ModifyStudent(Guid Id, UserDTORequest userDTO);

        Guid AddUser(UserDTORequest userDTO);



        //void UpdateUser(User user);

        //IEnumerable<User> GetAllUsers();

        //Guid AddUser(User user);
    }
}
