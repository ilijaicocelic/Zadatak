
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using RepositoryServiceContract;
using ServiceContracts;
using ServiceContracts.DTO;
using ServiceContracts.Interfaces;
using Services;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Service
{
    public class UserService : IUserService
    {
        private UserMapper _userMapper;
        private IUserRepository _repositoryuser;

        private readonly ApplicationSettings _appSettings;
        public UserService(IUserRepository userRepository, IOptions<ApplicationSettings> appSettings)
        {
            _repositoryuser = userRepository;
            _appSettings = appSettings.Value;
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

        public LoginResponse Login(LoginFormDTO loginFormDTO)
        {
            List<User> Users = _repositoryuser.GetAllUsers().ToList();

            User u1 = Users.Where(x => x.Username == loginFormDTO.Username && x.Password == loginFormDTO.Password).FirstOrDefault();
            if(u1 == null)
            {
                return null;
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                   {
                        new Claim("UserId",u1.Id.ToString()),
                        new Claim("Roles", u1.Role.ToString()),

                    }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.JWT_Secret)), SecurityAlgorithms.HmacSha256Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(securityToken);
            LoginResponse response = new LoginResponse();
            response.user = _userMapper.FromUserToDTO(u1);
            response.token = token;
            return response ;
        }

        public void ModifyStudent(Guid Id, UserDTORequest userDTO)
        {
            User user = _userMapper.FromDTOUserToUser(userDTO);
            user.Id = Id;
            _repositoryuser.UpdateUser(user);
        }
    }
}
