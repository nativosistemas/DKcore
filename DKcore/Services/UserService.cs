﻿using DKbase.Entities;
using DKbase.Models;
using DKcore.Helpers;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DKcore.Services
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
    }
    public class UserService : IUserService
    {
        private readonly AppSettings _appSettings;

        public UserService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            //string userAgent = System.Web.HttpContext.Current.Request.UserAgent;
            //string ip = System.Web.HttpContext.Current.Server.HtmlEncode(System.Web.HttpContext.Current.Request.UserHostAddress);
            //string hostName = System.Web.HttpContext.Current.Request.UserHostName;
            if (string.IsNullOrEmpty(model.login) || string.IsNullOrEmpty(model.pass)) return null;
            //DataTable dt = DKbase.baseDatos.StoredProcedure.Login(model.login, model.pass, "", "", "");

            DKbase.web.Usuario userLogin = DKbase.web.acceso.Login(model.login, model.pass, "", "", "");

            if (userLogin == null || userLogin.id ==  -1) return null;
            User o = new User();
            o.usu_codigo = userLogin.id;
            o.idRol = userLogin.idRol;
            if (userLogin.usu_codCliente.HasValue)
            {
                o.cli_codigo = userLogin.usu_codCliente.Value;
            }
            o.login = model.login;

            // authentication successful so generate jwt token
            var token = generateJwtToken(o);

            return new AuthenticateResponse(o, token, userLogin.ApNombre);
            
        }
        private string generateJwtToken(User user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("usu_codigo", user.usu_codigo.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
    public class UserServiceTest : IUserService
    {
        // users hardcoded for simplicity, store in a db with hashed passwords in production applications
        private List<User> _users = new List<User>
        {
            new User { usu_codigo = 1,cli_codigo=233, login = "test"}
        };

        private readonly AppSettings _appSettings;

        public UserServiceTest(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var user = _users.SingleOrDefault(x => x.login == model.login );

            // return null if user not found
            if (user == null) return null;

            // authentication successful so generate jwt token
            var token = generateJwtToken(user);

            return new AuthenticateResponse(user, token);
        }

        public IEnumerable<User> GetAll()
        {
            return _users;
        }

        public User GetById(int usu_codigo)
        {
            return _users.FirstOrDefault(x => x.usu_codigo == usu_codigo);
        }

        // helper methods

        private string generateJwtToken(User user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("usu_codigo", user.usu_codigo.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
