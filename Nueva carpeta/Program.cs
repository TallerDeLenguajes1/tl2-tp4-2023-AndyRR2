using System;
using EspacioCadeteria;
using EspacioPedido;
using EspacioAccesoADatos;
using EspacioCadete;

public class Program{
    
    private static void Main(){

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
    
      double telefonoCadeteria = 326579254;
      string? nombreCadeteria = "Mensajes Cadeteria";
      Cadeteria cadeteria = new Cadeteria(nombreCadeteria , telefonoCadeteria, acceso.ListaCadetes);
     
      Console.WriteLine("Opciones:");
      Console.WriteLine("1-Dar de Alta pedido");//ok
      Console.WriteLine("2-Asignar cadete a pedido");//ok
      Console.WriteLine("3-Cambiar estado de pedido");//ok
      Console.WriteLine("4-Reasignar cadete a otro pedido");//*************
      Console.WriteLine("5-Mostrar cadete de un pedido");//ok
      Console.WriteLine("6-Mostrar datos de los cadetes de la cadeteria");//ok
      Console.WriteLine("7-Mostrar datos y direccion de los clientes registrados");//ok
      Console.WriteLine("8-Mostrar pedidos de la cadeteria");//ok
      Console.WriteLine("9-Eliminar pedido");//*************
      Console.WriteLine("0-Cerrar");
       entrada = Console.ReadLine();
       result = int.TryParse(entrada, out opcion);
      while (opcion!=0)
      {
        switch (opcion)
        {
          case 1: 
          cadeteria.DarDeAltaPedido();
          break;

          case 2: 
          int numero, id;
          Console.WriteLine("Entre numero del pedido a asignar: ");
          entrada = Console.ReadLine();
          result = int.TryParse(entrada, out numero);
          Console.WriteLine("Entre el id del cadete: ");
          entrada = Console.ReadLine();
          result = int.TryParse(entrada, out id);
          if (cadeteria.AsignarCadeteAPedido(id,numero))
          {
            Console.WriteLine("Pedido Asignado Correctamente");
          }else
          {
            Console.WriteLine("Error al asignar el Pedido");
          }
          break;
          
          case 3:
          Console.WriteLine("Entre numero del pedido a modificar: ");
          entrada = Console.ReadLine();
          result = int.TryParse(entrada, out numero);
          Console.WriteLine("1-Entregar, 2-Cancelar: ");
          entrada = Console.ReadLine();
          result = int.TryParse(entrada, out opcion);
          if (cadeteria.CambiarEstadoPedido(numero,opcion))
          {
            Console.WriteLine("Estado Cambiado Correctamente");
          }else
          {
            Console.WriteLine("Error al cambiar el Estado");
          }
          break;

          case 4:
          Console.WriteLine("Entre numero del pedido a reasignar: ");
          entrada = Console.ReadLine();
          result = int.TryParse(entrada, out numero);
          Console.WriteLine("Entre el id del cadete: ");
          entrada = Console.ReadLine();
          result = int.TryParse(entrada, out id);
          /*
          cadeteria.ReasignarPedido(numero, id);
          */
          break;

          case 5:
          Console.WriteLine("Entre el numero del pedido: ");
          entrada = Console.ReadLine();
          result = int.TryParse(entrada, out numero);
          Console.WriteLine(cadeteria.mostrarCadeteDePedido(numero));
          break;
          
          case 6: 
          Console.WriteLine(cadeteria.mostrarDatosCadetes());
          break;
          
          case 7:
          Console.WriteLine(cadeteria.mostrarDatosClientes());
          break;
          
          case 8:
          Console.WriteLine(cadeteria.mostrarPedidosCadeteria());
          break;

          case 9:
          Console.WriteLine("Entre numero del pedido a eliminar: ");
          entrada = Console.ReadLine();
          result = int.TryParse(entrada, out numero);
          cadeteria.RemoverPedidoCadeteria(numero);
          break;
        }
        Console.WriteLine("Opciones:");
        Console.WriteLine("1-Dar de Alta pedido");
        Console.WriteLine("2-Asignar cadete a pedido");
        Console.WriteLine("3-Cambiar estado de pedido");
        Console.WriteLine("4-Reasignar cadete a otro pedido");
        Console.WriteLine("5-Mostrar cadete de un pedido");
        Console.WriteLine("6-Mostrar datos de los cadetes de la cadeteria");
        Console.WriteLine("7-Mostrar datos y direccion de los clientes registrados");
        Console.WriteLine("8-Mostrar pedidos de la cadeteria");
        Console.WriteLine("9-Eliminar pedido");
        Console.WriteLine("0-Cerrar");
        entrada = Console.ReadLine();
        result = int.TryParse(entrada, out opcion);
        
      }
      

      
    }

    
}
