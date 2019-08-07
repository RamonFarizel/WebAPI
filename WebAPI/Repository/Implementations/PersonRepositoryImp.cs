using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Models.Context;

namespace WebAPI.Repository.Implementations
{
    public class PersonRepositoryImp : IPersonRepository
    {
        private SQLContext _context;

        public PersonRepositoryImp(SQLContext context)
        {
            _context = context;
        }
        public Person CreatePerson(Person person)
        {
            try
            {
                _context.Persons.Add(person);
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
            var result = _context.Persons.SingleOrDefault(p => p.ID.Equals(id));

            try
            {
                if (result != null)
                {
                    _context.Persons.Remove(result);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Exists(long? id)
        {
            return _context.Persons.Any(p => p.ID.Equals(id));
        }

        public IList<Person> FindAll()
        {
           return _context.Persons.ToList();
        }

        public Person FindByID(int id)
        {
            return _context.Persons.SingleOrDefault(p => p.ID.Equals(id));
        }

        public Person Update(Person person)
        {
            if (!Exists(person.ID))
                return new Person();

            var result = _context.Persons.SingleOrDefault(p => p.ID.Equals(person.ID));
            try
            {
                _context.Entry(result).CurrentValues.SetValues(person);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return person;
        }
    }
}
