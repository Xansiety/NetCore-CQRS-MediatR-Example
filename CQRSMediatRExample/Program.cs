

using CQRSMediatRExample.Context;
using CQRSMediatRExample.MediatR.Behaviors;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMediatR(typeof(Program)); // Code before NuggetPackage < 12
//builder.Services.AddMediatR(c => c.RegisterServicesFromAssemblyContaining<Program>());  // Code for NuggetPackage >= 12
builder.Services.AddSingleton<FakeDataStore>();
builder.Services.AddSingleton(typeof(IPipelineBehavior<,>), typeof(LogginBehavior<,>));



builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
