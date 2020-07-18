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
        public int Id { get; set; }
        //public string UserName { get; set; }
        public string FullName { get; set; }
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }
        public string Proffesion { get; set; }
        public string Education { get; set; }
        public double Rating { get; set; }
        public string AboutMe { get; set; }
        public IEnumerable<Skills> Skills { get; set; }
        public IEnumerable<Project> CurrentProjects { get; set; }

    }
}
