using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SGE.HexagonalArchiPattern.Core.Ports.Driven;
using SGE.HexagonalArchiPattern.Core.Ports.Driving;
using SGE.HexagonalArchiPattern.Core.Services;
using SGE.HexagonalArchiPattern.Messaging.Publishers;
using SGE.HexagonalArchiPattern.Persistence.Database;


namespace SGE.HexagonalArchiPattern.Persistence.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddPersistenceLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext(configuration);
            services.AddRepositories();
            services.AddBusinessServices();
            services.AddMessaging();
        }
        public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<SgeHexagonaleDbContext>(options =>
               options.UseSqlServer(connectionString,
                   builder => builder.MigrationsAssembly(typeof(SgeHexagonaleDbContext).Assembly.FullName)));
        }
        public static void AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<IArticleService, ArticleService>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IWritingService, WritingService>();
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IArticleRepository, ArticleRepository>();
            services.AddScoped<IStudentRepository, StudentRepository>();
        }
        public static void AddMessaging(this IServiceCollection services)
        {
            services.AddScoped<IMessagePublisher, MessagePublisher>();
        }
    }
}
