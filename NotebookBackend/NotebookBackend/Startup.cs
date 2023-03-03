using Microsoft.EntityFrameworkCore;
using NotebookBackend.Data;
using NotebookBackend.Implementations;
using NotebookBackend.Models;
using NotebookBackend.Services;

namespace NotebookBackend;

internal class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<IGreeter, ConsoleGreeter>();
        services.AddScoped<IRepository<Note>, NoteRepository>();
        services.AddControllers();

        services.AddCors(setup =>
        {
            setup.AddDefaultPolicy(policy =>
            {
                policy
                    .WithOrigins("http://localhost:3000")
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });
        });

        var connectionString = Configuration.GetConnectionString("Database") ?? throw new NullReferenceException();
        services.AddDbContext<DatabaseContext>(options => options.UseNpgsql(connectionString));
    }

    public void Configure(IApplicationBuilder app)
    {
        app.UseRouting();
        app.UseCors();
        app.UseEndpoints(endpoints => endpoints.MapDefaultControllerRoute());
    }
}