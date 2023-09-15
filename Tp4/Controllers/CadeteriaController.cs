using Microsoft.AspNetCore.Mvc;
//using EspacioPedido;
using EspacioCadeteria;
using EspacioCadete;
using EspacioAccesoADatos;


namespace Tp4.Controllers;


[ApiController]
[Route("[controller]")]
public class CadeteriaController : ControllerBase
{
    private readonly ILogger<CadeteriaController > _logger;
    Cadeteria cadeteria;
    public CadeteriaController(ILogger<CadeteriaController > logger)
    {
      //----------------
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
      cadeteria= new Cadeteria("Nombre cadeteria",3816161383,acceso.ListaCadetes);//instancio a la clase en en logger
      //-----------------
      
        _logger = logger;
    }


    
    [HttpGet(Name = "CadeteriaController")]//el primer metodo toma el nombre de la clase aunque no se ponga name
    public ActionResult<string> GetNombreCadeteria()//debe retornar algo
    {
        return(cadeteria.Nombre);
    }
}