using Microsoft.EntityFrameworkCore;
using server.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
	options.AddPolicy("VueCorsPolicy",
		builder =>
		{
			builder.WithOrigins("http://localhost:8080")
				   .AllowAnyHeader()
				   .AllowAnyMethod();
		});
});


builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("VueCorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
