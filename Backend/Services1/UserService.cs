
using RepositoryServiceContract;
using ServiceContracts.DTO;
using ServiceContracts.Interfaces;
using Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public class UserService : IUserService
    {
        private UserMapper _userMapper;
        private IUserRepository _repositoryuser;
        public UserService(IUserRepository userRepository)
        {
            _repositoryuser = userRepository;
            _userMapper = new UserMapper();
        }


        public Guid AddUser(UserDTORequest userDTO)
        {
            return _repositoryuser.AddUser(_userMapper.FromDTOUserToUser(userDTO));
        }

        public IEnumerable<UserDTO> GetAllUsers()
        {
            return _userMapper.ListUsertToListDTO(_repositoryuser.GetAllUsers());
        }

        public UserDTO GetUser(Guid Id)
        {
            return _userMapper.FromUserToDTO(_repositoryuser.GetUser(Id));
        }

        public string Login(LoginFormDTO loginFormDTO)
        {
            return "";
        }

        public void ModifyStudent(Guid Id, UserDTORequest userDTO)
        {
            User user = _userMapper.FromDTOUserToUser(userDTO);
            user.Id = Id;
            _repositoryuser.UpdateUser(user);
        }
    }
}
