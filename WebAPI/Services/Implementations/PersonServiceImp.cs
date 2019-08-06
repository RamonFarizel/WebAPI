using System;
using System.Collections.Generic;
using System.Linq;
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
            var result = _context.Persons.SingleOrDefault(p => p.ID.Equals(ID));
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
            if (!Exist(person.ID))
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

        private bool Exist(int? iD)
        {
            return _context.Persons.Any(p => p.ID.Equals(iD));
        }
    }
}
