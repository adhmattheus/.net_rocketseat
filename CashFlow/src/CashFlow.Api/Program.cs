using CashFlow.Api.Filters;
using CashFlow.Api.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMvc(options => options.Filters.Add(typeof(ExcepetionFilter)));
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost5244",
        policy => policy.WithOrigins("http://localhost:5244")
                        .AllowAnyHeader()
                        .AllowAnyMethod());
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<CultureMiddleware>();

app.UseHttpsRedirection();

app.UseCors("AllowLocalhost5244");

app.UseAuthorization();

app.MapControllers();

app.Run();
