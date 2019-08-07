using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Repository
{
    public interface IPersonRepository
    {
        Person CreatePerson(Person person);
        Person FindByID(int id);
        IList<Person> FindAll();
        Person Update(Person person);
        void Delete(int id);
        bool Exists(long? id);
    }
}
