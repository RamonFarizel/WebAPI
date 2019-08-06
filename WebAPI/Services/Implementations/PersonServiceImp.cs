using System;
using System.Collections.Generic;
using WebAPI.Models;

namespace WebAPI.Services.Implementations
{
    public class PersonServiceImp : IPersonService
    {
        public Person CreatePerson(Person person)
        {
            return person;
        }

        public void Delete(int id)
        {
            
        }

        public IList<Person> FindAll()
        {
            return new List<Person>
            {
                new Person { ID = 1, FirstName = "Ramon", LastName = "Farizel", Address = "Pavuna", gender = "Masculino" },
                new Person { ID = 2, FirstName = "Ramon", LastName = "Farizel", Address = "Pavuna", gender = "Masculino" },
                new Person { ID = 3, FirstName = "Ramon", LastName = "Farizel", Address = "Pavuna", gender = "Masculino" },
                new Person { ID = 4, FirstName = "Ramon", LastName = "Farizel", Address = "Pavuna", gender = "Masculino" },
                new Person { ID = 5, FirstName = "Ramon", LastName = "Farizel", Address = "Pavuna", gender = "Masculino" },
                new Person { ID = 6, FirstName = "Ramon", LastName = "Farizel", Address = "Pavuna", gender = "Masculino" }
            };
        }

        public Person FindByID(int id)
        {
            return new Person { ID = 1, FirstName = "Ramon", LastName = "Farizel", Address = "Pavuna", gender = "Masculino" };
        }

        public Person Update(Person person)
        {
            return person;
        }
    }
}
