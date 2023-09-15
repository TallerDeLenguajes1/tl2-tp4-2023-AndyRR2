namespace EspacioPedido;
using System;
using EspacioCadete;
using EspacioCliente;

public class Pedido{
    private int nro;
    private string? obs;
    private string? estado;
    private float precio;
    private Cliente? cliente;
    private Cadete? cadete;

    public int Nro { get => nro; set => nro = value; }
    public string? Obs { get => obs; set => obs = value; }
    public Cliente? Cliente { get => cliente; set => cliente = value; }
    public string? Estado { get => estado; set => estado = value; }
    public Cadete? Cadete { get => cadete; set => cadete = value; }
    public float Precio { get => precio; set => precio = value; }

    //se crea el pedido luego de crear el cliente
    public Pedido(int nro, string obs, string nombreCliente, string direccion, double telefono, string referencia){
        cliente = new Cliente(nombreCliente,direccion,telefono,referencia);
        this.nro = nro;
        this.obs = obs;
        this.estado = "Pendiente";
    }
    public string VerDireccionCliente(){
        return("Direccion: " + cliente.Direccion);
    }
    public string VerDatosCliente(){
        return("Nombre: " + cliente.Nombre +
        "\nTelefono: " + cliente.Telefono +
        "\nReferencia: " + cliente.DatosReferenciaDireccion);
    }
    public string MostrarCadete(){
        return(Cadete.Nombre + 
        "\n" + Cadete.Direccion +
        "\n" + Cadete.Id +
        "\n" + Cadete.Telefono);
    }

}