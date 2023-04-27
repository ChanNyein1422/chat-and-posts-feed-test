using ChatApi.Hub;
using ChatApi.Services.ChatService;
using ChatApi.Services.CommentService;
using ChatApi.Services.PostService;
using ChatApi.Services.UserService;
using Data.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

// Add services to the container.
builder.Services.AddSignalR();
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      builder =>
                      {
                          builder.WithOrigins("https://localhost:7278/"
                            )
                          .AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();
                      });
});

builder.Services.AddDbContext<DatabaseContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddScoped<IUser>(s => new UserBase(s.GetService<DatabaseContext>()));
builder.Services.AddScoped<IChat>(s => new ChatBase(s.GetService<DatabaseContext>()));
builder.Services.AddScoped<IPost>(s => new PostBase(s.GetService<DatabaseContext>()));
builder.Services.AddScoped<IComment>(s => new CommentBase(s.GetService<DatabaseContext>()));

var app = builder.Build();

//app.UseCors(MyAllowSpecificOrigins);

//app.UseCors();

app.UseCors(x => x.AllowAnyMethod().AllowAnyHeader().SetIsOriginAllowed(origin => true).AllowCredentials());
app.MapHub<ChatHub>("/chatHub");

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
