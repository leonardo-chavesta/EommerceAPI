
using Autofac.Extensions.DependencyInjection;
using Autofac;
using Infraestructure.Context;
using System.Reflection;

string _MyCors = "MyCors";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>();

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(options =>
    {
        options.RegisterAssemblyTypes(Assembly.Load("Infraestructure"))
        .Where(t => t.Name.EndsWith("Repository"))
        .AsImplementedInterfaces()
        .InstancePerLifetimeScope();

        options.RegisterAssemblyTypes(Assembly.Load("Application"))
       .Where(t => t.Name.EndsWith("Service"))
       .AsImplementedInterfaces()
       .InstancePerLifetimeScope();
    });

builder.Services.AddCors(options => {
    {
        options.AddPolicy(name: _MyCors, builder =>
        {
            builder.SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost")
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
    }
});

builder.Services.AddAutoMapper(Assembly.Load("Application"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(_MyCors);
app.UseAuthorization();

app.MapControllers();

app.Run();
