namespace EspacioAccesoADatos;
using EspacioCadeteria;
using EspacioCadete;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class AccesoADatos{
   private List<Cadete>? listaCadetes;
    public List<Cadete>? ListaCadetes { get => listaCadetes; set => listaCadetes = value; }

    public virtual void cargarCadetes(string archivo){
        Console.WriteLine("Base");
    }

}

public class AccesoCSV: AccesoADatos{
    public override void cargarCadetes(string archivo){
        List<Cadete> cadetes = new List<Cadete>();
        var cadetesCargados = File.ReadAllLines(archivo + ".csv")
        .Skip(1).                           //Saltea el encabezado
        Select(line => line.Split(',')).
        Select(parts => new Cadete(int.Parse(parts[0]), parts[1], parts[2], parts[3]));
        cadetes.AddRange(cadetesCargados);
        ListaCadetes = cadetes;
        Console.WriteLine("Cadetes cargados correctamente");
    }

}

public class AccesoJSON: AccesoADatos{
    public override void cargarCadetes(string archivo)
    {

        List<Cadete> cadetes = new List<Cadete>();
        try{
            // Lee el contenido del archivo JSON
            string jsonText = File.ReadAllText(archivo + ".json");

            // Deserializa el JSON en una lista de objetos Cadete
            cadetes = JsonSerializer.Deserialize<List<Cadete>>(jsonText);

            ListaCadetes = cadetes;
            Console.WriteLine("Cadetes cargados correctamente");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al cargar cadetes desde el archivo JSON: {ex.Message}");
        }
    }
}
