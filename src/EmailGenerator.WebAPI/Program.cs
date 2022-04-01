using EmailGenerator.WebAPI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApiDocument(); // add OpenAPI v3 document

builder.Services.AddDbContext<EmailGeneratorContext>();

builder.Services.AddCors(x =>
{
    x.AddDefaultPolicy(x =>
    {
        x.AllowAnyHeader();
        x.AllowAnyOrigin();
        x.AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseOpenApi();
app.UseSwaggerUi3();
app.UseReDoc();

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();