using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RepositoryServiceContract
{

    public enum Roles { Admin, Student};
    public enum Statuses { Regular, Extramural}
        
    public class User
    {
        public User(Guid id, string name, string surname, string indexNumber, uint year, string password, string username, Roles role, Statuses status)
        {
            Id = id;
            Name = name;
            Surname = surname;
            IndexNumber = indexNumber;
            Year = year;
            Password = password;
            Username = username;
            Role = role;
            Status = status;
        }

        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }
        
        public string Surname { get; set; }

        public string IndexNumber { get; set; }

        public uint Year { get; set; }

        public string Password { get; set; }

        public string Username { get; set; }

        public Roles Role { get; set; }

        public Statuses Status { get; set; }
    }
}
