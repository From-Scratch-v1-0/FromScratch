using AutoMapper;
using FS_BAL.Interfaces;
using FS_DAL.Entities;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace FS_BAL.Operations
{
    public class AccountOperations : IAccountOperations
    {
        private readonly IUOW service;
        private readonly IMapper mapper;

        public AccountOperations(IUOW service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        public void createPerson(Person person) 
        {
            service.Person.AddPerson(person);
        }
    }
}
