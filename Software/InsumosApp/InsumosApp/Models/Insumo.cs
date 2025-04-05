using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsumosApp.Models
{
    public class Insumo
    {
        public int IdInsumo { get; private set; }
        public string Nombre { get; private set; }
        public string UnidadMedida { get; private set; }
        public double CantidadInventario { get; private set; }
        public string FechaCaducidad { get; private set; }
        public string Proveedor { get; private set; }
        public double CostoUnitario { get; private set; }
        public string Categoria { get; private set; }
        public string FechaEntrada { get; private set; }
        public double CantidadMinimaAlerta { get; private set; }

        public Insumo(int idInsumo, string nombre, string unidadMedida, double cantidadInventario,
                      string fechaCaducidad, string proveedor, double costoUnitario,
                      string categoria, string fechaEntrada, double cantidadMinimaAlerta)
        {
            if (idInsumo <= 0) throw new ArgumentException("El ID del insumo debe ser mayor a 0.");
            if (string.IsNullOrWhiteSpace(nombre)) throw new ArgumentException("El nombre no puede estar vacío.");
            if (string.IsNullOrWhiteSpace(unidadMedida)) throw new ArgumentException("La unidad de medida no puede estar vacía.");
            if (cantidadInventario < 0) throw new ArgumentException("La cantidad en inventario no puede ser negativa.");
            if (string.IsNullOrWhiteSpace(fechaCaducidad)) throw new ArgumentException("La fecha de caducidad no puede estar vacía.");
            if (string.IsNullOrWhiteSpace(proveedor)) throw new ArgumentException("El proveedor no puede estar vacío.");
            if (costoUnitario < 0) throw new ArgumentException("El costo unitario no puede ser negativo.");
            if (string.IsNullOrWhiteSpace(categoria)) throw new ArgumentException("La categoría no puede estar vacía.");
            if (string.IsNullOrWhiteSpace(fechaEntrada)) throw new ArgumentException("La fecha de entrada no puede estar vacía.");
            if (cantidadMinimaAlerta < 0) throw new ArgumentException("La cantidad mínima de alerta no puede ser negativa.");

            IdInsumo = idInsumo;
            Nombre = nombre;
            UnidadMedida = unidadMedida;
            CantidadInventario = cantidadInventario;
            FechaCaducidad = fechaCaducidad;
            Proveedor = proveedor;
            CostoUnitario = costoUnitario;
            Categoria = categoria;
            FechaEntrada = fechaEntrada;
            CantidadMinimaAlerta = cantidadMinimaAlerta;
        }
    }
}

