using FS_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;
using System.Text;

namespace FS_BAL.DTOs
{
    public class ProjectDTO
    {
        // name, description, sphere - primary
        // type, rating,  - seconday
        
        public int Id { get; set; }
        public string ProjectName { get; set; } //
        public string Description { get; set; } //
        public List<string> Sphere { get; set; }
        
        public string Type { get; set; }
        public int Rating { get; set; } //
    }
}
