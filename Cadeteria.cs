namespace EspacioCadeteria;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using EspacioCadete;
using EspacioPedido;
using EspacioAccesoADatos;
using System.Text;

public class Cadeteria{
    private string? nombre;
    private double telefono;
    private List<Pedido> listaPedidosCadeteria = new List<Pedido>(); 
    private List<Cadete>? listaDeCadetes;

    public string? Nombre { get => nombre; set => nombre = value; }
    public double Telefono { get => telefono; set => telefono = value; }
    public List<Cadete>? ListaDeCadetes { get => listaDeCadetes; set => listaDeCadetes = value; }
    public List<Pedido> ListaPedidosCadeteria { get => listaPedidosCadeteria; set => listaPedidosCadeteria = value; }

    //crea cadeteria
    public Cadeteria(string nombre, double telefono, List<Cadete> listaCadetes){
        this.nombre = nombre;
        this.telefono = telefono;
        this.ListaDeCadetes = listaCadetes;
    }
    public void DarDeAltaPedido(){//*********************
        int numero;
        string? obs, nombreCliente, direccion, referencia;
        double telefonoCliente;
        
        Console.WriteLine("Ingrese el numero de pedido");
        string? entrada = Console.ReadLine();
        bool result = int.TryParse(entrada, out numero);
        
        Console.WriteLine("Ingrese la observación del pedido");
        obs = Console.ReadLine();
        
        Console.WriteLine("Ingrese el nombre del cliente");
        nombreCliente = Console.ReadLine();
        
        Console.WriteLine("Ingrese la dirección del cliente");
        direccion = Console.ReadLine();
        
        Console.WriteLine("Ingrese el teléfono del cliente");
        entrada = Console.ReadLine();
        result = double.TryParse(entrada, out telefonoCliente);
        
        Console.WriteLine("Ingrese una referencia para la dirección");
        referencia = Console.ReadLine();
        Pedido pedido = new Pedido(numero, obs, nombreCliente, direccion, telefonoCliente, referencia);
        listaPedidosCadeteria.Add(pedido);
    }
    
    public string mostrarDatosCadetes(){//ok
        if (listaDeCadetes!=null)
        {
            StringBuilder datosCadete = new StringBuilder();
            foreach(Cadete cadete in listaDeCadetes){
                datosCadete.AppendLine(cadete.MostrarDatosCadete());
            }
            return(datosCadete.ToString());
        }else
        {
            return("Lista de Cadetes vacia");
        }
    }
    
    public string mostrarPedidosCadeteria(){//ok
    if (listaPedidosCadeteria!=null)
    {
        StringBuilder PedidosCadeteria = new StringBuilder();
        foreach (var pedido in listaPedidosCadeteria){
            PedidosCadeteria.AppendLine(pedido.Nro.ToString());
            PedidosCadeteria.AppendLine(pedido.Obs);
            PedidosCadeteria.AppendLine(pedido.Estado);
            PedidosCadeteria.AppendLine(pedido.Precio.ToString());
            PedidosCadeteria.AppendLine(pedido.VerDatosCliente());
            PedidosCadeteria.AppendLine(pedido.VerDireccionCliente());
        }
        return(PedidosCadeteria.ToString());
    }else
    {
        return("Lista de Pedidos Cadeteria vacia");
    }
    
    }
    public string mostrarDatosClientes(){//ok
        if (listaPedidosCadeteria!=null)
        {
            StringBuilder DatosClientes = new StringBuilder();
            foreach (var pedido in ListaPedidosCadeteria) 
            {
                DatosClientes.AppendLine(pedido.VerDatosCliente());  
                DatosClientes.AppendLine(pedido.VerDireccionCliente());  
            }
            return(DatosClientes.ToString());
        }else
        {
            return("No hay pedidos -> no hay clientes :(");
        }
    }
    public bool CambiarEstadoPedido(int numero,int opcion){//ok
        bool var=false;
        foreach (var pedido in listaPedidosCadeteria)
        {
            if (pedido.Nro==numero)
            {
                switch(opcion){
                    case 1:
                    pedido.Estado="Entregado";
                    break;
                    case 2:
                    pedido.Estado="Cancelado";
                    break;
                }
                var=true;
            }
        }
        return(var);
    }
    public void RemoverPedidoCadeteria(int numero){//****
        listaPedidosCadeteria.RemoveAt(numero-1);
    }
    public bool AsignarCadeteAPedido(int id, int numero){//ok
        bool var=false;
        foreach (var pedido in listaPedidosCadeteria)
        {
            if (pedido.Nro==numero)
            {
                foreach (var cadete in listaDeCadetes)
                {
                    if (cadete.Id==id)
                    {
                        pedido.Cadete=cadete;
                    }
                }
                var=true;
            }
        }
        return(var);
    }
    public string mostrarCadeteDePedido(int numero){//ok
        if (listaPedidosCadeteria!=null)
        {
            StringBuilder Cadetes = new StringBuilder();
            foreach (var pedido in listaPedidosCadeteria)
            {
                if (pedido.Nro==numero)
                {
                    Cadetes.AppendLine(pedido.MostrarCadete());
                }
            }
            return(Cadetes.ToString());
        }else
        {
            return("No hay pedidos -> no hay cadetes");
        }
        
    }
    /*public void AsignarPedidoACadete(int numero , int id){
        foreach (var cadete in listaDeCadetes)
        {   
            if (cadete.Id==id){
                cadete.ListadoDePedidos.Add(listaPedidosCadeteria[numero-1]);
                Console.WriteLine("Asignado pedido: " + numero + " al cadete id: " + id);
            }
        }
    }*/
    /*public void mostrarPedidosDeCadeteID(int id){
        foreach (var cadete in listaDeCadetes)
        {
            if (cadete.Id==id)
            {
                cadete.MostrarPedidosDelCadete();
            }
        }
    }*/
    /*public void RemoverPedidoCadete(int numero){
        foreach (var cadete in listaDeCadetes)
        {
            cadete.RemoverPedido(numero);
        }
    }*/
    /*public void ReasignarPedido(int numero, int id){
        foreach (var pedido in listaPedidosCadeteria)
        {
            if (pedido.Nro==numero)
            {
                RemoverPedidoCadete(numero);
                AsignarPedidoACadete(numero, id);
            }
        }
    }*/
    /*public float JornalACobrar(int id){
        
        return(monto);
    }*/

    

    
}
