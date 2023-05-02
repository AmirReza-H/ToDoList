using ToDoList.Infrastructure.Identity;
using FluentValidation.AspNetCore;
using ToDoList.Application.DTOs.Account;
using ToDoList.Infrastructure.Persistence;
using ToDoList.Application;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddIdentityInfrastructure(builder.Configuration);
builder.Services.AddJwt(builder.Configuration);
builder.Services.AddApplicationLayer();
builder.Services.AddServices();
builder.Services.AddPersistence(builder.Configuration);



// FluentValidation
builder.Services.AddControllers().AddFluentValidation(options =>
{
    options.ImplicitlyValidateChildProperties = true;

    options.RegisterValidatorsFromAssemblyContaining<RegisterRequest>();
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
