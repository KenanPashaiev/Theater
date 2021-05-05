using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Theater.BL.Services;
using Theater.DAL;
using Theater.DAL.Abstractions;
using Theater.DAL.Repositories;
using FluentValidation.AspNetCore;
using FluentValidation;
using Theater.Validators;
using Theater.BL.Models.Note;
using Theater.BL.Models.Hall;
using Theater.BL.Models.Session;
using Theater.BL.Models.User;
using Theater.BL.Utils;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Theater
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                .AddFluentValidation();

            services.AddTransient<IValidator<NoteCreateUpdateDto>, NoteCreateUpdateDtoValidator>();
            services.AddTransient<IValidator<HallCreateDto>, HallCreateDtoValidator>();
            services.AddTransient<IValidator<HallUpdateDto>, HallUpdateDtoValidator>();
            services.AddTransient<IValidator<SessionCreateUpdateDto>, SessionCreateUpdateDtoValidator>();
            services.AddTransient<IValidator<UserRegisterDto>, UserRegisterDtoValidator>();
            services.AddTransient<IValidator<UserLoginDto>, UserLoginDtoValidator>();
            services.AddTransient<IValidator<UserUpdateDto>, UserUpdateDtoValidator>();

            services.AddTransient<INoteService, NoteService>();
            services.AddTransient<IHallService, HallService>();
            services.AddTransient<ISessionService, SessionService>();
            services.AddTransient<ITransactionService, TransactionService>();
            services.AddTransient<IUserService, UserService>();

            services.AddTransient<INoteRepository, NoteRepository>();
            services.AddTransient<IHallRepository, HallRepository>();
            services.AddTransient<ISessionRepository, SessionRepository>();
            services.AddTransient<ITransactionRepository, TransactionRepository>();
            services.AddTransient<IUserRepository, UserRepository>();

            services.AddTransient<JwtService>();
            services.AddTransient<PasswordHasher<object>>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.RequireHttpsMetadata = false;
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            // укзывает, будет ли валидироваться издатель при валидации токена
                            ValidateIssuer = true,
                            // строка, представляющая издателя
                            ValidIssuer = AuthOptions.ISSUER,

                            // будет ли валидироваться потребитель токена
                            ValidateAudience = true,
                            // установка потребителя токена
                            ValidAudience = AuthOptions.AUDIENCE,
                            // будет ли валидироваться время существования
                            ValidateLifetime = true,

                            // установка ключа безопасности
                            IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                            // валидация ключа безопасности
                            ValidateIssuerSigningKey = true,
                        };
                    });

            services.AddAutoMapper(typeof(Startup));
            services.AddDbContext<ApplicationContext>();
            services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
