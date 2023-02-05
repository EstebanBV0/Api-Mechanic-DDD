using Mechanic.DDD.api.AplicationServices;
using Mechanic.DDD.api.Queries;
using Mechanic.DDD.api.Utilidades;
using Mechanic.DDD.Domain.Repositories;
using Mechanic.DDD.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAutoMapper(typeof(Program).Assembly, typeof(AutoMapperProfiles).Assembly);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle.3+02-
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DatabaseContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("demo"));
});
builder.Services.AddScoped<IMecanicoRepository, MecanicoRepository>();
builder.Services.AddScoped<IServicioRepository, ServicioRepository>();
builder.Services.AddScoped<IRepuestoRepository, RepuestoRepository>();
builder.Services.AddScoped<IVehiculoRepository, VehiculoRepository>();
builder.Services.AddScoped<IDuenoRepository, DuenoRepository>();

builder.Services.AddScoped<VehiculoQueries>();
builder.Services.AddScoped<VehiculoServices>();
builder.Services.AddScoped<MecanicoQueries>();
builder.Services.AddScoped<MechanicServices>();
builder.Services.AddScoped<DuenoQueries>();
builder.Services.AddScoped<DuenoServices>();
builder.Services.AddScoped<RepuestoQueries>();
builder.Services.AddScoped<RepuestoServices>();
builder.Services.AddScoped<ServicioQueries>();
builder.Services.AddScoped<ServicioServices>();





var app = builder.Build();
builder.Services.AddCors();
app.UseCors(options =>
   options.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader());

// Configure the HTTP request pipeline.







if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
