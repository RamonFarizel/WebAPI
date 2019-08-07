using System;
using System.Collections.Generic;
using System.Linq;
using WebAPI.Models;
using WebAPI.Models.Context;
using WebAPI.Repository;

namespace WebAPI.Business.Implementations
{
    public class PersonBusinessImp : IPersonBusiness
    {
        private IPersonRepository _repository;

        public PersonBusinessImp(IPersonRepository repository)
        {
            _repository = repository;
        }

        public Person CreatePerson(Person person)
        {
            return _repository.CreatePerson(person); ;
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public IList<Person> FindAll()
        {
            return _repository.FindAll();
        }

        public Person FindByID(int id)
        {
            return _repository.FindByID(id);
        }

        public Person Update(Person person)
        {
            return _repository.Update(person);
        }
    }
}
