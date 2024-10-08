using Domain.UseCases.GetClientsUseCases.Boundaries;
using Infra.Extensions;
using parana_bank_credit_client.Extensions;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddApiVersioningExtension();
builder.Services.AddSwaggerGen(options =>
{
    options.EnableAnnotations();
});

builder.Services.AddSwaggerOptions();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(GetClientsInput).Assembly));
builder.Services.AddHttpContextAccessor();
builder.Services.AddProducers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.AddSwaggerConfiguration();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
