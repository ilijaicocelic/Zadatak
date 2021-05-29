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
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        

        public string Surname { get; set; }

        public string IndexNumber { get; set; }

        public uint Year { get; set; }



        public Roles Role { get; set; }

        public Statuses Status { get; set; }
    }
}
