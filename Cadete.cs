namespace EspacioCadete;
using System;
using System.ComponentModel;
using EspacioPedido;

public class Cadete{

    private int id;
    private string? nombre;
    private string? direccion;
    private string? telefono;
    

    public int Id { get => id; set => id = value; }
    public string? Nombre { get => nombre; set => nombre = value; }
    public string? Direccion { get => direccion; set => direccion = value; }
    public string? Telefono { get => telefono; set => telefono = value; }
    //public List<Pedido>? ListadoDePedidos { get => listadoDePedidos; set => listadoDePedidos = value; }

    public Cadete(int id, string nombre, string direccion, string telefono){
        this.id = id;
        this.nombre = nombre;
        this.direccion = direccion;
        this.telefono = telefono;
    }
    public string MostrarDatosCadete(){
        return("Datos Cadete: " +
        "\nId: " + id +
        "\nNombre: " + nombre +
        "\nDireccion: " + direccion +
        "\nTelefono: " + telefono);
    }
    /*public void MostrarPedidosDelCadete(){
        foreach (var pedido in listadoDePedidos)
        {
            Console.WriteLine("Numero: " + pedido.Nro);
            Console.WriteLine("Observacion: " + pedido.Obs);
            Console.WriteLine("Estado: " + pedido.Estado);
            Console.WriteLine("Precio: " + pedido.Precio);
            MostrarDatosCliente();
        }
    }*/
    
    
    
}