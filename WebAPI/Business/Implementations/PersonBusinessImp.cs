using System;
using System.Collections.Generic;
using System.Linq;
using WebAPI.Data.Converters;
using WebAPI.Data.VO;
using WebAPI.Models;
using WebAPI.Models.Context;
using WebAPI.Repository;
using WebAPI.Repository.Generic;

namespace WebAPI.Business.Implementations
{
    public class PersonBusinessImp : IPersonBusiness
    {
        private readonly PersonConverter _converter;
        private IRepository<Person> _repository;

        public PersonBusinessImp(IRepository<Person> repository)
        {
            _repository = repository;
            _converter = new PersonConverter();
        }

        public PersonVO CreatePerson(PersonVO person)
        {
            var personEntity = _converter.Parse(person);
            personEntity = _repository.Create(personEntity);
            return _converter.Parse(personEntity);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public IList<PersonVO> FindAll()
        {
            return _converter.ParseList(_repository.FindAll());
        }

        public PersonVO FindByID(int id)
        {
            return _converter.Parse(_repository.FindByID(id));
        }

        public PersonVO Update(PersonVO person)
        {
            var personEntity = _converter.Parse(person);
            personEntity = _repository.Update(personEntity);

            return _converter.Parse(personEntity);
        }
    }
}
