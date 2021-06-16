using RepositoryServiceContract;
using ServiceContracts.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services
{
    public class UserMapper
    {
        public UserDTO FromUserToDTO(User user)
        {

            return new UserDTO(user.Id,user.Name,user.Surname,user.IndexNumber,user.Year,user.Username,user.Role.ToString(),user.Status.ToString());

        }

        public IEnumerable<UserDTO> ListUsertToListDTO(IEnumerable<User> userList)
        {
            return userList.Select(user => FromUserToDTO(user)).ToList();
        }

        public User FromDTOUserToUser(UserDTORequest userDTO)
        {

            Roles role = (Roles)System.Enum.Parse(typeof(Roles), userDTO.Role);
            Statuses status = (Statuses)System.Enum.Parse(typeof(Statuses), userDTO.Status);
            return new User(Guid.NewGuid(), userDTO.Name, userDTO.Surname, userDTO.IndexNumber, userDTO.Year, userDTO.Password, userDTO.Username, role, status);
        }
    }
}
