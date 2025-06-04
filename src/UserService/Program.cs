using Microsoft.EntityFrameworkCore;
using UserService.Data;

var builder = WebApplication.CreateBuilder(args);

// 1. Registrar servicios para controladores
builder.Services.AddControllers();

// 2. Configurar Entity Framework Core
builder.Services.AddDbContext<UserDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

app.UseHttpsRedirection(); // Puedes mantener esto comentado por ahora si sigues teniendo problemas con el puerto HTTPS
app.UseAuthorization();
app.MapControllers();
app.Run();