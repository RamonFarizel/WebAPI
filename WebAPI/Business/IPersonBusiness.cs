using System.Collections.Generic;
using WebAPI.Data.VO;

namespace WebAPI.Business
{
    public interface IPersonBusiness
    {
        PersonVO CreatePerson(PersonVO person);
        PersonVO FindByID(int id);
        IList<PersonVO> FindAll();
        PersonVO Update(PersonVO person);
        void Delete(int id);

    }
}
