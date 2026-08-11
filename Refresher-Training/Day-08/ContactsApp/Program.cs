using ContactsApp.Data;
using ContactsApp.Endpoints;
using ContactsApp.Interface;
using ContactsApp.Repository;
using ContactsApp.Service;

// Configure application services.
var builder = WebApplication.CreateBuilder(args);

// Dependency Injection

builder.Services.AddSingleton<DbConnection>();

builder.Services.AddScoped<IContactRepository, ContactRepository>();

builder.Services.AddScoped<IContactService, ContactService>();

var app = builder.Build();

// Map Minimal API endpoints.

app.MapContactEndpoints();

app.Run();