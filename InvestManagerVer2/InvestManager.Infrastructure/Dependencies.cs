using InvestManager.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InvestManager.Infrastructure
{
    public static class Dependencies
    {
        public static void ConfigureServices(IConfiguration configuration, IServiceCollection services)
        {
            services.AddDbContext<InvestManagerContext>(context =>
            context.UseSqlServer(configuration.GetConnectionString("InvestManagerConnection")));
        }
    }
}
