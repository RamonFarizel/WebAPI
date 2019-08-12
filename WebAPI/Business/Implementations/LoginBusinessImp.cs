using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Repository;
using WebAPI.Security.Configuration;

namespace WebAPI.Business.Implementations
{
    public class LoginBusinessImp : ILoginBusiness
    {
        private IUsuarioRepository _repository;
        private SigningConfiguration _signingConfiguration;
        private TokenConfiguration _tokenConfiguration;

        public LoginBusinessImp(IUsuarioRepository repository,
            SigningConfiguration signingConfiguration,
            TokenConfiguration tokenConfiguration
            )
        {
            _repository = repository;
            _signingConfiguration = signingConfiguration;
            _tokenConfiguration = tokenConfiguration;
        }

        public object FindByLogin(Usuarios login)
        {
            bool credentialsIsValid = false;

            if (login != null && !string.IsNullOrWhiteSpace(login.Usuario))
            {
                var baseUsuario = _repository.FindByLogin(login.Usuario);
                credentialsIsValid = (baseUsuario != null && login.Usuario == baseUsuario.Usuario && login.Senha == baseUsuario.Senha);
            }
            if (credentialsIsValid)
            {
                ClaimsIdentity identity = new ClaimsIdentity
                    (
                    new GenericIdentity(login.Usuario, "Login"),
                    new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString("N")),
                        new Claim(JwtRegisteredClaimNames.UniqueName,login.Usuario)
                    });

                DateTime createDate = DateTime.Now;
                DateTime expirationDate = createDate + TimeSpan.FromSeconds(_tokenConfiguration.Seconds);

                var handler = new JwtSecurityTokenHandler();
                string token = CreateToken(identity, createDate, expirationDate, handler);

                return SuccessObject(createDate,expirationDate,token);
            }

            else
                return ExceptionObject();

        }

        private string CreateToken(ClaimsIdentity identity, DateTime createDate, DateTime expirationDate, JwtSecurityTokenHandler handler)
        {
            var securityToken = handler.CreateToken(new Microsoft.IdentityModel.Tokens.SecurityTokenDescriptor
            {
                Issuer = _tokenConfiguration.Issuer,
                Audience = _tokenConfiguration.Audience,
                SigningCredentials = _signingConfiguration.SigningCredentials,
                Subject = identity,
                NotBefore = createDate,
                Expires = expirationDate
            });

            var token = handler.WriteToken(securityToken);
            return token;
        }

        private object ExceptionObject()
        {
            return new
            {
                autenticated = false,
                message = "Autenticação falhou"
            };
        }

        private object SuccessObject(DateTime createDate, DateTime expirationDate, string token)
        {
            return new
            {
                autenticated = true,
                created = createDate.ToString("yyyy-MM-dd HH:mm:ss"),
                accessToken = token,
                message = "Ok"
            };
        }
    }
}

