using FS_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Contracts
{
    public interface IPersonRepository : IBaseRepository<Person>
    {
        void AddPerson(Person person);
        Person GetPersobById(string id);
    }
}
