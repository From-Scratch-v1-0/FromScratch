using AutoMapper;
using FS_BAL.DTOs;
using FS_BAL.Interfaces;
using FS_DAL.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FS_BAL.Operations
{
    public class UserOperations : IUserOperations
    {
        private readonly IUOW service;
        private readonly IMapper mapper;

        public UserOperations(IUOW service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        public UserInfoDTO UserInfoMapping(UserInfoDTO userInfo)
        {
            var id = userInfo.Id;
            var skillNames = service.Skills.GetByCondition(e => e.UserFKey == id).Select(x => x.SkillName);

            var projectIds = service.Project.GetByCondition(e => e.UserKey == id).Select(x => x.ProjectKey);
            var projectProduct = service.ProjectProduct.GetAll();

            var list = new List<string>();

            var length = projectProduct.Count();
            var length2 = projectIds.Count();
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length2; j++)
                {
                    if (projectProduct.ElementAt(i).ProjectKey == projectIds.ElementAt(j)) 
                    {
                        list.Add(projectProduct.ElementAt(i).ProjectName);
                    }
                }
            }

            userInfo.Skills = skillNames;
            userInfo.CurrentProjects = list;
            return userInfo;
        }


        public UserInfoDTO GetUserInfoById(string id) 
        {
            var person = service.Person.GetPersobById(id);
            var user = service.User.GetUserById(id);

            var mappedData = mapper.Map<UserInfoDTO>(person);
            mappedData = mapper.Map<UserInfoDTO>(user);

            var lastChange = UserInfoMapping(mappedData);
            return lastChange;
        }


    }
}
