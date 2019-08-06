using System.Collections.Generic;
using WebAPI.Models;

namespace WebAPI.Business
{
    public interface IPersonBusiness
    {
        Person CreatePerson(Person person);
        Person FindByID(int id);
        IList<Person> FindAll();
        Person Update(Person person);
        void Delete(int id);

    }
}
