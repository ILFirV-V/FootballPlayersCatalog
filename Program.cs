using FootballPlayersCatalog.Filters;
using FootballPlayersCatalog.Logic.AutoMapper;
using FootballPlayersCatalog.Logic;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddTransient<ManagerTeam>();
builder.Services.AddTransient<ManagerFootballPlayer>();
builder.Services.AddTransient<CountryManager>();

builder.Services.AddTransient<ApplicationContext>();
builder.Services.AddControllers(x =>
{

    x.Filters.Add<ExceptionFilter>();
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(builder => builder
       .WithOrigins("http://localhost:4200")
       .AllowAnyHeader()
       .AllowAnyMethod()
       .AllowAnyOrigin()
    );
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
