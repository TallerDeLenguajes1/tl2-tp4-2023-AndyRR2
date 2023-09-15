namespace EspacioCliente;
using System;

public class Cliente{
    private string? nombre;
    private string? direccion;
    private double telefono;
    private string? datosReferenciaDireccion;
    

    public string? Nombre { get => nombre; set => nombre = value; }
    public string? Direccion { get => direccion; set => direccion = value; }
    public double Telefono { get => telefono; set => telefono = value; }
    public string? DatosReferenciaDireccion { get => datosReferenciaDireccion; set => datosReferenciaDireccion = value; }
    

    //se crea el cliente 
    public Cliente(string nombre, string direccion, double telefono, string referencia){
        this.nombre = nombre;
        this.direccion = direccion;
        this.telefono = telefono;
        this.datosReferenciaDireccion = referencia;
    }
    
}
