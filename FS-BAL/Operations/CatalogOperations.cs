using AutoMapper;
using FS_BAL.DTOs;
using FS_BAL.Interfaces;
using FS_DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace FS_BAL.Operations
{
    public class CatalogOperations : ICatalogOperations
    {
        private readonly IUOW _service;
        private readonly IMapper mapper;

        public CatalogOperations(IUOW service, IMapper mapper)
        {
            _service = service;
            this.mapper = mapper;
        }

        public IEnumerable<ProjectDTO> GetAllProjects() 
        {
            var data = _service.ProjectProduct.GetAll();
            var modiefedData = mapper.Map<IEnumerable<ProjectDTO>>(data);

            projectMultiMapping(modiefedData);

            return modiefedData;
        }

        public IEnumerable<ProjectDTO> Search(string search) 
        {
            var projects = _service.ProjectProduct.GetAll();
            var searchedProjects = projects.Where(e => EF.Functions.Like(e.ProjectName, $"%{search}%"));

            var modiefedData = mapper.Map<IEnumerable<ProjectDTO>>(searchedProjects);

            projectMultiMapping(modiefedData);

            return modiefedData;
        }


        public IEnumerable<ProjectDTO> getSpecificProjects(string name) 
        {
            var projects = _service.ProjectProduct.GetAll();
            var sphere = _service.Sphere.GetAll();
            var projecSphere = _service.ProjectSphere.GetAll();

            var specificID = sphere.Where(e => e.SphereName == name).Select(ex => ex.SphereKey).FirstOrDefault();

            var specificProjects = projecSphere.Where(e => e.SphereKey == specificID).Select(ex => ex.ProjectKey);

            var specificProjectsList = new List<ProjectProduct>();

            var projectsCount = projects.Count();
            for (int i = 0; i < projectsCount; i++)
            {
                for (int j = 0; j < specificProjects.Count(); j++)
                {
                    if (projects.ElementAt(i).ProjectKey == specificProjects.ElementAt(j)) 
                    {
                        specificProjectsList.Add(projects.ElementAt(i));
                    }
                }
            }

            IEnumerable<ProjectProduct> newProjects = specificProjectsList;

            var modiefedData = mapper.Map<IEnumerable<ProjectDTO>>(newProjects);

            projectMultiMapping(modiefedData);

            return modiefedData;
        }

        // mapping from distinct classes to one class
        public IEnumerable<ProjectDTO> projectMultiMapping(IEnumerable<ProjectDTO> modiefedData)
        {
            var projects = _service.ProjectProduct.GetAll();
            var type = _service.ProjectType.GetAll();
            var sphere = _service.Sphere.GetAll();
            var projecSphere = _service.ProjectSphere.GetAll();

            foreach (var item in modiefedData)
            {
                item.Type = type.Where(e => e.ProjectTypeKey == projects.Where(
                    x => x.ProjectKey == item.Id)
                .Select(ex => ex.ProjectTypeKey).FirstOrDefault())
                    .Select(exp => exp.ProjectTypeName).FirstOrDefault();

                var keys = projecSphere.Where(e => e.ProjectKey == item.Id).Select(x => x.SphereKey);
                var list = new List<string>();
                foreach (var key in keys)
                {
                    var oneKey = sphere.Where(e => e.SphereKey == key)
                    .Select(x => x.SphereName).FirstOrDefault();
                    list.Add(oneKey);
                }
                item.Sphere = list;
            }

            return modiefedData;

        }
    }
}
