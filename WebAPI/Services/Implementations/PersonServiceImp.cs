using System;
using System.Collections.Generic;
using WebAPI.Models;
using WebAPI.Models.Context;

namespace WebAPI.Services.Implementations
{
    public class PersonServiceImp : IPersonService
    {
        private SQLContext _context;

        public PersonServiceImp(SQLContext context)
        {
            _context = context;
        }

        public Person CreatePerson(Person person)
        {
            try
            {
                _context.Add(person);
                
                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return person;
        }

        public void Delete(int id)
        {
            
        }

        public IList<Person> FindAll()
        {
            return new List<Person>
            {
                new Person { ID = 1, FirstName = "Ramon", LastName = "Farizel", AddressPerson = "Pavuna", Gender = "Masculino" },
                new Person { ID = 2, FirstName = "Ramon", LastName = "Farizel", AddressPerson = "Pavuna", Gender = "Masculino" },
                new Person { ID = 3, FirstName = "Ramon", LastName = "Farizel", AddressPerson = "Pavuna", Gender = "Masculino" },
                new Person { ID = 4, FirstName = "Ramon", LastName = "Farizel", AddressPerson = "Pavuna", Gender = "Masculino" },
                new Person { ID = 5, FirstName = "Ramon", LastName = "Farizel", AddressPerson = "Pavuna", Gender = "Masculino" },
                new Person { ID = 6, FirstName = "Ramon", LastName = "Farizel", AddressPerson = "Pavuna", Gender = "Masculino" }
            };
        }

        public Person FindByID(int id)
        {
            return new Person { ID = 1, FirstName = "Ramon", LastName = "Farizel", AddressPerson = "Pavuna", Gender = "Masculino" };
        }

        public Person Update(Person person)
        {
            return person;
        }
    }
}
