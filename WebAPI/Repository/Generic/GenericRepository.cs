using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models.Base;
using WebAPI.Models.Context;

namespace WebAPI.Repository.Generic
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly SQLContext _context;
        private DbSet<T> _dataset;

        public GenericRepository(SQLContext context)
        {
            _context = context;
            _dataset = _context.Set<T>();
        }

        public T Create(T item)
        {
            try
            {
                _dataset.Add(item);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return item;
        }

        public void Delete(int id)
        {
            var result = _dataset.SingleOrDefault(p => p.ID.Equals(id));

            try
            {
                if (result != null)
                {
                    _dataset.Remove(result);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Exists(int? id)
        {
            return _dataset.Any(p => p.ID.Equals(id));
        }

        public IList<T> FindAll()
        {
            return _dataset.ToList();
        }

        public T FindByID(int id)
        {
            return _dataset.SingleOrDefault(p => p.ID.Equals(id));
        }

        public T Update(T item)
        {
            if (!Exists(item.ID))
                return null;

            var result = _dataset.SingleOrDefault(p => p.ID.Equals(item.ID));
            try
            {
                _context.Entry(result).CurrentValues.SetValues(item);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return item;
        }
    }
}
