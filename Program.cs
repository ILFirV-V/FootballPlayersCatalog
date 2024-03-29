using FootballPlayersCatalog.Filters;
using FootballPlayersCatalog.Logic.AutoMapper;
using FootballPlayersCatalog.Logic;
using FootballPlayersCatalog.Logic.Interfaces;
using FootballPlayersCatalog.Dal.Contexts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddSingleton<DalSetting>();
builder.Services.AddDbContext<ApplicationContext>();
builder.Services.AddScoped<ITeamManager, TeamManager>();
builder.Services.AddScoped<IPlayerManager, PlayerManager>();
builder.Services.AddScoped<ICountryManager, CountryManager>();
builder.Services.AddControllers(x =>
{
    x.Filters.Add<ExceptionFilter>();
});

var app = builder.Build();

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
