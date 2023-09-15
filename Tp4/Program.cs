using EspacioAccesoADatos;
//using EspacioCadeteria;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/*//-------------
int opcion = 0;
      Console.WriteLine("Cargar Datos con 1-CSV o 2-JSON");
      string? entrada = Console.ReadLine();
      bool result = int.TryParse(entrada, out opcion);
      
      AccesoADatos acceso = new AccesoADatos();
      string? direccion = "Cadetes";
      if (opcion==1)
      {
        acceso = new AccesoCSV();
      }else if (opcion==2)
      {
        acceso = new AccesoJSON();
      }
      acceso.cargarCadetes(direccion);
//-----------------*/

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
