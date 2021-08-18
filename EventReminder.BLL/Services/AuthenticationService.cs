using EventBuilder.Constants;
using EventReminder.BLL.Abstractions;
using EventReminder.Models.Configuration;
using Microsoft.Extensions.Configuration;
using System;
using Microsoft.Extensions.DependencyInjection;
using EventReminder.Helpers;
using Arch.EntityFrameworkCore.UnitOfWork;
using EventReminder.DAL.Models;

namespace EventReminder.BLL.Services
{
    internal class AuthenticationService : IAuthenticationService
    {
        private IServiceProvider _provider;
        private IUnitOfWork _unitOfWork;

        public AuthenticationService(IServiceProvider provider, IUnitOfWork unitOfWork)
        {
            _provider = provider;
            _unitOfWork = unitOfWork;
        }

        public string CreateToken(string email)
        {
            var jwtSettings = new JwtSettings();
            var configuration = _provider.GetService<IConfiguration>();
            configuration.GetSection(ConfigurationConstants.JwtSectionName).Bind(jwtSettings);

            return TokenHelper.CreateToken(jwtSettings.SigningKey, jwtSettings.Issuer, jwtSettings.Audience, email);
        }

        public void CreateUserIfNotExist(string email)
        {
            var user = _unitOfWork.GetRepository<User>().GetFirstOrDefault<User>(x => x, x => x.Email == email);
            if (user != null)
            {
                _unitOfWork.GetRepository<User>().Insert(new User()
                {
                    Email = email
                });
                _unitOfWork.SaveChanges();
            }
        }
    }
}
