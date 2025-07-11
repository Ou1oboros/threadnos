using Threadnos_API.Presentation.Config;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddSwagger();
builder.Services.AddAutoMapperProfile();
builder.Services.AddProjectServices(builder.Configuration);

var app = builder.Build();


app.UseSwaggerIfDev(app.Environment);
app.UseCustomMiddlewares();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();