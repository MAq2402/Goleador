using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Goleador.Application.Shared.Services;
using Microsoft.AspNetCore.Identity;

namespace OccBooking.Auth.Services
{
    public class AuthService : IAuthService
    { 
        private UserManager<Goleador.Infrastructure.Auth.User> _userManager;
        private IJwtFactory _jwtFactory;

        public AuthService(UserManager<Goleador.Infrastructure.Auth.User> userManager, IJwtFactory jwtFactory)
        {
            _userManager = userManager;
            _jwtFactory = jwtFactory;
        }

        public async Task<Goleador.Application.Shared.Types.User> LoginAsync(string userName, string password)
        {
            var user = await _userManager.FindByNameAsync(userName);

            if (user == null)
            {
                throw new ArgumentException("User with given user name does not exist");
            }

            if (!await _userManager.CheckPasswordAsync(user, password))
            {
                throw new ArgumentException("User with given user name does not exist");
            }

            var jwt = _jwtFactory.GenerateJwt(user.Id);

            return new Goleador.Application.Shared.Types.User
            {
                Id = user.Id,
                UserName = user.UserName,
                Token = jwt
            };
        }

        public async Task RegisterAsync(string userName, string password)
        {
            var user = new Goleador.Infrastructure.Auth.User
            {
                UserName = userName
            };

            var result = await _userManager.CreateAsync(user, password);

            if(!result.Succeeded)
            {
                throw new Exception($"Registration of {user.UserName} failed");
            }
        }
    }
}
