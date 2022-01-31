using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MyEwalletApp.Services.Implementation;
using MyEWalletApp.Commons;
using MyEWalletApp.DataAccess;
using MyEWalletApp.DataAccess.Implementation;
using MyEWalletApp.DataAccess.Interface;
using MyEWalletApp.Models.Models;
using MyEWalletApp.Services.Implementation;
using MyEWalletApp.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MyEWalletApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContextPool<MyEWalletAppContext>(options => options.UseSqlite(Configuration.GetConnectionString("MyEWalletAppDb")));
            services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<MyEWalletAppContext>()
                .AddDefaultTokenProviders();

            services.AddTransient<Seeder>();
            services.AddTransient<IWalletRepository, WalletRepository>();
            services.AddTransient<ICurrencyRepository, CurrencyRepository>();
            services.AddTransient<IWalletCurrencyRepository, WalletCurrencyRepository>();
            services.AddTransient<ITransactionRepository, TransactionRepository>();

            services.AddTransient<IJWTService, JWTService>();  
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IUserService, UserService>(); 
            services.AddTransient<IWalletService, WalletService>(); 
            services.AddTransient<ICurrencyService, CurrencyService>();
            services.AddTransient<IWalletCurrencyService, WalletCurrencyService>();
            services.AddTransient<ITransactionService, TransactionService>();
            services.AddTransient<ICurrencyConversionService, CurrencyConversionService>();






            //services.AddAutoMapper(typeof(Startup));
            var mapperConfig = new MapperConfiguration(cf =>
            {
                cf.AddProfile(new AutoMapping());
            });
            services.AddSingleton(mapperConfig.CreateMapper());
            services.AddCors();
            services.AddSwaggerGen(c => 
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My-EWallet-App", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme."
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });

            });

            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(option => {
                var param = new TokenValidationParameters();
                param.IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Key"]));
                param.ValidateIssuer = false;
                param.ValidateAudience = false;
                option.TokenValidationParameters = param;
            });
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, Seeder seeder)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            seeder.SeedMe().Wait();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(x => x.SwaggerEndpoint("/swagger/v1/swagger.json", "My-EWallet-App-v1"));
        }
    }
}
