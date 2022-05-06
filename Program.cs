using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using UuidMasterApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Reverse proxy.
builder.Services.Configure<ForwardedHeadersOptions>(options => {
    options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
});

// Database.
var connectionString =
builder.Services.AddDbContext<UuidMasterApiDbContext>(
    dbContextOptions => dbContextOptions.UseSqlServer(
        builder.Configuration["ConnectionStrings:UuidMasterApiDbConnectionString"]
    )
);

// Controllers
builder.Services.AddControllers(options => {
    options.ReturnHttpNotAcceptable = true;
});

// Entity-model mapper.
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Documentation.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();// Disabled due to reverse proxy in production.

app.UseAuthorization();

app.MapControllers();

app.Run(async (context) => {
   await context.Response.WriteAsync("Hello test!");
});

app.Run();
