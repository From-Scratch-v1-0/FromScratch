using FS_BAL.DTOs;
using FS_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FS_BAL.Interfaces
{
    public interface ICatalogOperations
    {
        IEnumerable<ProjectDTO> GetAllProjects();
        IEnumerable<ProjectDTO> Search(string search);
    }
}
