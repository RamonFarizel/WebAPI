using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Repository.Generic;

namespace WebAPI.Business.Implementations
{
    public class BookBusinessImp : IBookBusiness
    {
        private IRepository<Book> _repository;

        public BookBusinessImp(IRepository<Book> repository)
        {
            _repository = repository;
        }
        public Book CreateBook(Book book)
        {
            return _repository.Create(book);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public IList<Book> FindAll()
        {
           return _repository.FindAll();
        }

        public Book FindByID(int id)
        {
            return _repository.FindByID(id);
        }

        public Book Update(Book book)
        {
            return _repository.Update(book);
        }
    }
}
