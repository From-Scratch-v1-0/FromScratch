using FS_DAL.Context;
using FS_DAL.Entities;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Repositories
{
    public class PersonRepository : BaseRepository<Person>, IPersonRepository
    {
        public PersonRepository(FSContext context) : base(context)
        {
        }

        public void AddPerson(Person person) 
        {
            Context.Add(person);
            Context.SaveChanges();
        }

        public Person GetPersobById(string id)
        {
            var person = Context.Person.Find(id);
            return person;
        }
    }
}
