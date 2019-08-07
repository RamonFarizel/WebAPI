using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Business
{
    public interface IBookBusiness
    {
        Book CreateBook(Book book);
        Book FindByID(int id);
        IList<Book> FindAll();
        Book Update(Book book);
        void Delete(int id);
    }
}
