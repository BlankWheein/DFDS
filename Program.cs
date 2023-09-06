using AutoMapper;
using DFDS;
using DFDS.Controllers.Repositories;
using DFDS.DatabaseModels;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers(/*opt => opt.Filters.Add<HttpResponseExceptionFilter>()*/).AddNewtonsoftJson(op =>
{
    op.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
    op.SerializerSettings.DefaultValueHandling = Newtonsoft.Json.DefaultValueHandling.Ignore;

});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<DatabaseContext>( dbContextOptions => dbContextOptions.UseMySql(new MySqlServerVersion(new Version(8, 0, 27)), o =>
{
    o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
    o.EnableRetryOnFailure(3);
})

    );


var mapperconfig = new MapperConfiguration(mc =>
{
    mc.CreateMap<Booking, BookingDto>();
    mc.CreateMap<Passenger, PassengerDto>();
    mc.CreateMap<Passport, PassportDto>();
});

Mapper mapper = new(mapperconfig);
builder.Services.AddSingleton(mapper);

builder.Services.AddScoped<BookingRepository>();
builder.Services.AddScoped<PassportRepository>();
builder.Services.AddScoped<PassengerRepository>();


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
