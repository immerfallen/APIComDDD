using Api.Domain.DTOs;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.User;
using Api.Domain.Repository;
using Api.Domain.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace Api.Service.Services.LoginService
{
    public class LoginService : ILoginService
    {
        private IUserRepository _repository;
        private SignInConfigurations _signingConfigurations;
        private TokenConfiguration _tokenconfiguration;
        private IConfiguration _configuration;

        public LoginService(IUserRepository repository,
            SignInConfigurations signingConfigurations,
            TokenConfiguration tokenconfiguration,
            IConfiguration configuration)
        {
            _repository = repository;
            _signingConfigurations = signingConfigurations;
            _tokenconfiguration = tokenconfiguration;
            _configuration = configuration;
        }
        public async Task<object> FindByLogin(LoginDTO user)
        {
            var baseUser = new UserEntity();
            if (user != null && !string.IsNullOrWhiteSpace(user.Email))
            {
                baseUser = await _repository.FindByLogin(user.Email);
                if (baseUser == null)
                {
                    return new
                    {
                        authenticated = false,
                        message = "Falha ao autenticar"
                    };
                }
                else
                {
                    ClaimsIdentity identity = new ClaimsIdentity(
                        new GenericIdentity(user.Email),
                        new[]
                        {
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                            new Claim(JwtRegisteredClaimNames.UniqueName, user.Email),

                        });

                    DateTime createdDate = DateTime.Now;
                    DateTime expirationDate = createdDate + TimeSpan.FromSeconds(_tokenconfiguration.Seconds);

                    var handler = new JwtSecurityTokenHandler();

                    string token = CreateToken(identity, createdDate, expirationDate, handler);

                    return SuccessObject(createdDate, expirationDate, token, user);
                }
            }
            else
            {
                return null;
            }
        }

        private string CreateToken(ClaimsIdentity identity, DateTime createdDate, DateTime expirationDate, JwtSecurityTokenHandler handler)
        {
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _tokenconfiguration.Issuer,
                Audience = _tokenconfiguration.Issuer,
                SigningCredentials = _signingConfigurations.SigningCredentials,
                Subject = identity,
                NotBefore = createdDate,
                Expires = expirationDate
            });

            var token = handler.WriteToken(securityToken);
            return token;
        }

        private object SuccessObject(DateTime createdDate, DateTime expirationDate, string token, LoginDTO user)
        {
            return new
            {
                authenticated = true,
                created = createdDate.ToString("yyyy-MM-dd HH:mm:ss"),
                expiration = expirationDate.ToString("yyyy-MM-dd HH:mm:ss"),
                accessToken = token,
                userName = user.Email,
                message = "Usuário logado com sucesso"
            };
        }
    }
}
