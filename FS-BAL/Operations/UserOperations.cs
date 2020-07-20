using AutoMapper;
using FS_BAL.DTOs;
using FS_BAL.Interfaces;
using FS_DAL.Entities;
using Services.Contracts;
using System;
using System.Collections.Generic;
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

        public IEnumerable<UserInfoDTO> UserInfoDestMapping(IEnumerable<UserInfoDTO> userInfos)
        { 

            return userInfos;
        }

    }
}
