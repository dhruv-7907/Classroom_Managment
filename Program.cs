using Classroom_Managment.Entity;
using Classroom_Managment.Interface;
using Classroom_Managment.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Add Swagger for API documentation.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add the DbContext with the connection string from appsettings.json.
builder.Services.AddDbContext<ClassroomContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("WebApiDatabase")));

// Register the LoginRepository for ILoginInterface.
builder.Services.AddScoped<ILoginInterface, LoginRepository>();
builder.Services.AddScoped<IClassroomInterface, ClassroomRepository>();
builder.Services.AddScoped<IWorkInterface, WorkRepository>();
builder.Services.AddScoped<IstudentWorkInterface, studentworkRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles();  // This allows serving static files like images, CSS, etc.
app.UseAuthorization();

app.MapControllers();

app.Run();
