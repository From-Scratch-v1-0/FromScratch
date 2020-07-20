using FS_BAL.Constants;
using FS_DAL.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Text;

namespace FS_BAL.DTOs
{
    public class UserInfoDTO
    {
        public string Id { get; set; } // aspUser
        public string Email { get; set; } // aspUser
        public double Rating { get; set; } // aspUser
        public string FullName { get; set; } // person
        public string PhoneNumber { get; set; } // person
        public GenderEnum GenderKey { get; set; }
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; } // person
        public string Address { get; set; } // person
        public string Proffesion { get; set; } // person
        public string Education { get; set; } // person
        public string AboutMe { get; set; } // person
        public string? ProfilePic { get; set; }
        public ContryEnum CountryKey { get; set; } // person
        public IEnumerable<string> Skills { get; set; } // skills


        public IEnumerable<string> CurrentProjects { get; set; } //project

    }
}
