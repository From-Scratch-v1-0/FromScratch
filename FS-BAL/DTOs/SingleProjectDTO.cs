using FS_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace FS_BAL.DTOs
{
    public class SingleProjectDTO
    {
        public int Id { get; set; } // from ProjectProduct (ProjectProductKey)
        public string ProjectName { get; set; } // from ProjectProduct (ProjectName)
        public IEnumerable<Discussion> Discussions { get; set; } // from Discussion (Comment Collection Data)
        public string Description { get; set; } // from ProjectProduct (Description)

        //public string Author { get; set; }  not today :)
        public string? Difficulty { get; set; } //from ProjectProduct (Difficulty)
        public int Rating { get; set; } //from ProjectProduct (Rating)
    }
}
