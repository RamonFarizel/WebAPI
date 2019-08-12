using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Models.Context;

namespace WebAPI.Repository.Implementations
{
    public class UsuarioRepositoryImp : IUsuarioRepository
    {
        private SQLContext _context;

        public UsuarioRepositoryImp(SQLContext context)
        {
            _context = context;
        }

        public Usuarios FindByLogin(string login)
        {
            return _context.Users.SingleOrDefault(x => x.Usuario.Equals(login));
        }




    }
}
