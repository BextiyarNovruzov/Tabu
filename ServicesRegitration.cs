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
    }
}
