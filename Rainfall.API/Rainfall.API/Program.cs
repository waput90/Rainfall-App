using Rainfall.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var service = builder.Services;

service.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
service.AddEndpointsApiExplorer();
service.AddSwaggerGen();
service.RegisterService();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(option =>
    {
        option.SwaggerEndpoint("/swagger/v1/swagger.json", "Rainfall Api");
        option.DocumentTitle = "Rainfall Api";
        option.SwaggerEndpoint("https://localhost:3000", "Rainfall Api");
        option.RoutePrefix = "swagger";
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
