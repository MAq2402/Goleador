﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Goleador.Application.Shared.Services;
using Goleador.Infrastructure.Auth;
using Goleador.Infrastructure.DbContext;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using OccBooking.Auth.Services;

namespace Goleador.Web.Auth
{
    public static class AuthExtensions
    {
        public static void ConfigureAuthentication(this IServiceCollection services, IConfiguration configuration,
            SymmetricSecurityKey securityKey)
        {
            var jwtAppSettingOptions = configuration.GetSection(nameof(JwtIssuerOptions));

            services.Configure<JwtIssuerOptions>(options =>
            {
                options.Issuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)];
                options.Audience = jwtAppSettingOptions[nameof(JwtIssuerOptions.Audience)];
                options.ValidFor = TimeSpan.FromMinutes(Convert.ToInt32(jwtAppSettingOptions[nameof(JwtIssuerOptions.ValidFor)]));
                options.SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            });

            TokenValidationParameters tokenValidationParameters =
                CreateTokenValidationParameters(securityKey, jwtAppSettingOptions);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(configureOptions =>
            {
                configureOptions.ClaimsIssuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)];
                configureOptions.TokenValidationParameters = tokenValidationParameters;
                configureOptions.SaveToken = true;
            });

            services.AddSingleton<IJwtFactory, JwtFactory>();
            services.AddScoped<IAuthService, AuthService>();

            var builder = services.AddIdentityCore<User>(o =>
            {
                o.Password.RequireDigit = false;
                o.Password.RequireLowercase = false;
                o.Password.RequireUppercase = false;
                o.Password.RequireNonAlphanumeric = false;
                o.Password.RequiredLength = 1;
                o.Password.RequiredUniqueChars = 0;
            });

            builder = new IdentityBuilder(builder.UserType, typeof(IdentityRole), builder.Services);
            builder.AddEntityFrameworkStores<GoleadorDbContext>().AddDefaultTokenProviders();
        }

        private static TokenValidationParameters CreateTokenValidationParameters(SymmetricSecurityKey securityKey,
            IConfigurationSection jwtAppSettingOptions)
        {
            return new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)],

                ValidateAudience = true,
                ValidAudience = jwtAppSettingOptions[nameof(JwtIssuerOptions.Audience)],

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = securityKey,

                RequireExpirationTime = false,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };
        }
    }
}
