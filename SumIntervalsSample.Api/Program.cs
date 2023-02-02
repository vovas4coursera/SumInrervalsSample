using FluentValidation.AspNetCore;
using SumIntervalsSample.BusinessLibrary.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

var assemblyBL = AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(x =>
{
    return x.GetName().Name.Equals("SumIntervalsSample.BusinessLibrary");
});

// Add services to the container.
builder.Services.AddControllers()
    .AddFluentValidation(options =>
                {
                    // Validate child properties and root collection elements
                    options.ImplicitlyValidateChildProperties = true;
                    options.ImplicitlyValidateRootCollectionElements = true;

                    // Automatic registration of validators in assembly
                    options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
                    options.RegisterValidatorsFromAssembly(assemblyBL);
                });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//configure DI
builder.Services.AddScoped<IIntervalSevice, IntervalSevice>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
