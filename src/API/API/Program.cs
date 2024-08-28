using CleanArchitecture.API.DependencyInjections;
using CleanArchitecture.API.Middlewares;
using CleanArchitecture.Application.DependencyInjections;

var builder = WebApplication.CreateBuilder(args);

// Add services.
builder.Services.ConfigureAPIServices();
builder.Services.ConfigureApplicationServices();
builder.Services.ConfigureInfrastructure(builder.Configuration);

var app = builder.Build();

// Configure middleware.
app.UseSwagger();
app.UseHttpsRedirection();
app.UseCors();
app.UseMiddleware<ExceptionMiddleware>();
app.UseAuthorization();

app.MapControllers();

// Initialize and run the app.
app.InitializeInfrastructure();
app.InitializeBackgroundJobs();

app.Run();

