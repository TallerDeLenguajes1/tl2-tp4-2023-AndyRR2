using Microsoft.AspNetCore.Mvc;
using EspacioCadeteria;
using EspacioCadete;
using EspacioPedido;


namespace Tp4.Controllers;


[ApiController]
[Route("[controller]")]
public class CadeteriaController : ControllerBase
{
    private readonly ILogger<CadeteriaController > _logger;
    Cadeteria cadeteria;
    public CadeteriaController(ILogger<CadeteriaController > logger)
    {
      _logger = logger;
      cadeteria = Cadeteria.GetCadeteria();
    }

    [HttpGet(Name = "CadeteriaController")]//el primer metodo toma el nombre de la clase aunque no se ponga name
    public ActionResult<string> GetNombreCadeteria()//debe retornar algo
    {
      if (cadeteria!=null)
      {
        return Ok(cadeteria.Nombre);
      }else
      {
        return NotFound("No existe una cadeteria");
      }
    }

    [HttpGet]
    [Route("Cadetes")]
    public ActionResult<string> GetCadetes(){
      if (cadeteria.ListaDeCadetes!=null)
      {
        //return Ok(cadeteria.mostrarDatosCadetes());//retorna como una texto string
        return Ok(cadeteria.ListaDeCadetes);//retorna con estructura json
      }else
      {
        return NotFound("No existen cadetes cargados");
      }
    }

    [HttpGet]
    [Route("Pedidos")]
    public ActionResult<string> GetPedidos(){
      if (cadeteria.ListaPedidosCadeteria!=null)
      {
        //return Ok(cadeteria.mostrarPedidosCadeteria());//retorna como una texto string
        return Ok(cadeteria.ListaPedidosCadeteria);//retorna con estructura json
      }else
      {
        return NotFound("No existen pedidos cargados");
      }
    }

    [HttpGet]
    [Route("Cadete_De_Pedido")]
    public ActionResult<string> GetCadeteDePedido(int idPedido){
      if (cadeteria.ListaPedidosCadeteria!=null)
      {
        return Ok(cadeteria.GetCadeteDePedido(idPedido));
      }else
      {
        return NotFound("No existen el pedido con ese ID");
      }
    }

    [HttpPost]
    [Route("Add_Pedido")]
    public ActionResult<string> AgregarPedido(int numero_de_pedido, string? observacion, string? nombre_cliente, string? direccion,int telefono, string? referencia){
      return Ok(cadeteria.AgregarPedido(numero_de_pedido, observacion, nombre_cliente, direccion, telefono, referencia));
    }
    [HttpPut]
    [Route("Cambiar_Estado_Pedido")]
    public ActionResult CambiarEstadoPedido(int idPedido,int newEstado){
      return Ok(cadeteria.CambiarEstadoPedido(idPedido,newEstado));
    }

    [HttpPut]
    [Route("Asignar_Pedido")]
    public ActionResult<string> AsignarPedido(int idPedido,int idCadete){
      if (cadeteria.ListaDeCadetes!=null)
      {
        return Ok(cadeteria.AsignarCadeteAPedido(idCadete,idPedido));
      }else
      {
        return NotFound("No existen cadetes cargados");
      }
    }

}