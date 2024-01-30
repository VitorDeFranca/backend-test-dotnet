using System.Text.Json.Serialization;
using TesteFCamara.Persistence;
using TesteFCamara.Persistence.Contexts;

var builder = WebApplication.CreateBuilder(args);

//Obt�m a string de conex�o, define o provedor e registra servi�os dos reposit�rios de ve�culo e estabelecimento
builder.Services.ConfigurePersistenceApp(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    })
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
    });

var app = builder.Build();

CreateDatabase(app);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();
app.MapControllers();
app.Run();

static void CreateDatabase(WebApplication app)
{
    var serviceScope = app.Services.CreateScope();
    var dataContext = serviceScope.ServiceProvider.GetService<DataContext>();
    dataContext?.Database.EnsureCreated();
}