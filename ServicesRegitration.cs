using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http.Features;
using Tabu.Exceptions;
using Tabu.Services.Abstracts;
using Tabu.Services.Implements;

namespace Tabu
{
    public static class ServicesRegitration
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ILanguagesServise, LanguagesService>();
            services.AddScoped<IWordsServise, WordsServise>();
            services.AddScoped<IBannedWordServise, BannedWordServise>();
            services.AddScoped<IGameServise, GamesServise>();
            return services;
        }
        public static IApplicationBuilder UseTabuExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(
                opt =>
                {
                    opt.Run(async context =>
                    {
                        var feature = context.Features.GetRequiredFeature<IExceptionHandlerFeature>();
                        var exception = feature.Error;

                        if (exception is IBaseException baseException)
                        {
                            context.Response.StatusCode = baseException.StatusCode;
                            await context.Response.WriteAsJsonAsync(new
                            {
                                ErrorMessage = baseException.ErrorMessage,
                            });
                        }
                        else
                        {
                            context.Response.StatusCode = 400;
                            await context.Response.WriteAsJsonAsync(new
                            {
                                Message = "Gozlenilmeyen Xeta Bas Verdi"
                            });
                        }
                    });

                });
            return app;
        }
    }
}
