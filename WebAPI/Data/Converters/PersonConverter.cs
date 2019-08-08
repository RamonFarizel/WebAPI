using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Data.Converter;
using WebAPI.Data.VO;
using WebAPI.Models;

namespace WebAPI.Data.Converters
{
    public class PersonConverter : IParser<PersonVO, Person>, IParser<Person, PersonVO>
    {
        //infomrmação pro banco de dados
        public PersonVO Parse(Person origem)
        {
            if (origem == null)
                return new PersonVO();

            return new PersonVO
            {
                ID = origem.ID,
                AddressPerson = origem.AddressPerson,
                Gender = origem.Gender,
                FirstName = origem.FirstName,
                LastName = origem.LastName
            };
        }

        //Informação pro usuário
        public Person Parse(PersonVO origem)
        {
            if (origem == null)
                return new Person();

            return new Person
            {
                ID = origem.ID,
                AddressPerson = origem.AddressPerson,
                Gender = origem.Gender,
                FirstName = origem.FirstName,
                LastName = origem.LastName
            };
                
        }

        public IList<PersonVO> ParseList(IList<Person> Origin)
        {
            if (Origin == null)
                return new List<PersonVO>();

            return Origin.Select(item => Parse(item)).ToList();
        }

        public IList<Person> ParseList(IList<PersonVO> Origin)
        {

            if (Origin == null)
                return new List<Person>();

            return Origin.Select(item => Parse(item)).ToList();
        }
    }
}
