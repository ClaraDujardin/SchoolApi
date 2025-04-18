using Microsoft.EntityFrameworkCore;
using SchoolApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=school.db"));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Auto-migrate DB
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}

//faut installer la bibliothèque swagger avant de pouvoir le use la commande se trouve dans le readme du prof
if (app.Environment.IsDevelopment())//permet d'utiliser swagger
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "SchoolAPI V1");//standard de ou est ce qu'on peut retrouver swagger
        options.RoutePrefix = "swagger";
    });
}



app.UseAuthorization();
app.MapControllers();
app.Run();