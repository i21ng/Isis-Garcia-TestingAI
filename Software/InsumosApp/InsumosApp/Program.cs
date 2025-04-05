using System;
using InsumosApp.Models;
using InsumosApp.Services;

class Program
{
    static InsumoService _service = new InsumoService();

    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== GESTIÓN DE INSUMOS ===");
            Console.WriteLine("1. Agregar Insumo");
            Console.WriteLine("2. Listar Insumos");
            Console.WriteLine("3. Buscar Insumo por ID");
            Console.WriteLine("4. Actualizar Insumo");
            Console.WriteLine("5. Eliminar Insumo");
            Console.WriteLine("6. Salir");
            Console.Write("Seleccione una opción: ");

            string opcion = Console.ReadLine();
            switch (opcion)
            {
                case "1": AgregarInsumo(); break;
                case "2": ListarInsumos(); break;
                case "3": BuscarInsumoPorId(); break;
                case "4": ActualizarInsumo(); break;
                case "5": EliminarInsumo(); break;
                case "6": return;
                default: Console.WriteLine("Opción inválida. Presione una tecla para continuar..."); Console.ReadKey(); break;
            }
        }
    }

    static void AgregarInsumo()
    {
        Console.WriteLine("\n--- Agregar Nuevo Insumo ---");
        int id = LeerEntero("Ingrese ID del insumo: ");
        string nombre = LeerTexto("Ingrese nombre del insumo: ");
        string unidadMedida = LeerTexto("Ingrese unidad de medida: ");
        double cantidadInventario = LeerDouble("Ingrese cantidad en inventario: ");
        string fechaCaducidad = LeerTexto("Ingrese fecha de caducidad (YYYY-MM-DD): ");
        string proveedor = LeerTexto("Ingrese proveedor: ");
        double costoUnitario = LeerDouble("Ingrese costo unitario: ");
        string categoria = LeerTexto("Ingrese categoría: ");
        string fechaEntrada = LeerTexto("Ingrese fecha de entrada (YYYY-MM-DD): ");
        double cantidadMinimaAlerta = LeerDouble("Ingrese cantidad mínima de alerta: ");

        try
        {
            var insumo = new Insumo(id, nombre, unidadMedida, cantidadInventario, fechaCaducidad, proveedor, costoUnitario, categoria, fechaEntrada, cantidadMinimaAlerta);
            _service.AgregarInsumo(insumo);
            Console.WriteLine("✅ Insumo agregado con éxito.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Error: {ex.Message}");
        }

        Console.WriteLine("Presione una tecla para continuar...");
        Console.ReadKey();
    }

    static void ListarInsumos()
    {
        Console.WriteLine("\n--- Lista de Insumos ---");
        var insumos = _service.ObtenerInsumos();
        if (insumos.Count == 0)
        {
            Console.WriteLine("No hay insumos registrados.");
        }
        else
        {
            foreach (var insumo in insumos)
            {
                Console.WriteLine($"ID: {insumo.IdInsumo} | Nombre: {insumo.Nombre} | Cantidad: {insumo.CantidadInventario} {insumo.UnidadMedida}");
            }
        }
        Console.WriteLine("\nPresione una tecla para continuar...");
        Console.ReadKey();
    }

    static void BuscarInsumoPorId()
    {
        Console.WriteLine("\n--- Buscar Insumo por ID ---");
        int id = LeerEntero("Ingrese el ID del insumo: ");
        var insumo = _service.ObtenerInsumoPorId(id);

        if (insumo == null)
        {
            Console.WriteLine("❌ Insumo no encontrado.");
        }
        else
        {
            Console.WriteLine($"✅ Insumo encontrado: {insumo.Nombre}, {insumo.CantidadInventario} {insumo.UnidadMedida}");
        }

        Console.WriteLine("\nPresione una tecla para continuar...");
        Console.ReadKey();
    }

    static void ActualizarInsumo()
    {
        Console.WriteLine("\n--- Actualizar Insumo ---");
        int id = LeerEntero("Ingrese el ID del insumo a actualizar: ");
        var insumoExistente = _service.ObtenerInsumoPorId(id);

        if (insumoExistente == null)
        {
            Console.WriteLine("❌ Insumo no encontrado.");
        }
        else
        {
            Console.WriteLine("Ingrese los nuevos datos del insumo:");
            string nombre = LeerTexto("Nuevo nombre: ");
            string unidadMedida = LeerTexto("Nueva unidad de medida: ");
            double cantidadInventario = LeerDouble("Nueva cantidad en inventario: ");
            string fechaCaducidad = LeerTexto("Nueva fecha de caducidad (YYYY-MM-DD): ");
            string proveedor = LeerTexto("Nuevo proveedor: ");
            double costoUnitario = LeerDouble("Nuevo costo unitario: ");
            string categoria = LeerTexto("Nueva categoría: ");
            string fechaEntrada = LeerTexto("Nueva fecha de entrada (YYYY-MM-DD): ");
            double cantidadMinimaAlerta = LeerDouble("Nueva cantidad mínima de alerta: ");

            var nuevoInsumo = new Insumo(id, nombre, unidadMedida, cantidadInventario, fechaCaducidad, proveedor, costoUnitario, categoria, fechaEntrada, cantidadMinimaAlerta);
            _service.ActualizarInsumo(id, nuevoInsumo);
            Console.WriteLine("✅ Insumo actualizado correctamente.");
        }

        Console.WriteLine("\nPresione una tecla para continuar...");
        Console.ReadKey();
    }

    static void EliminarInsumo()
    {
        Console.WriteLine("\n--- Eliminar Insumo ---");
        int id = LeerEntero("Ingrese el ID del insumo a eliminar: ");
        bool eliminado = _service.EliminarInsumo(id);

        if (eliminado)
        {
            Console.WriteLine("✅ Insumo eliminado con éxito.");
        }
        else
        {
            Console.WriteLine("❌ No se encontró un insumo con ese ID.");
        }

        Console.WriteLine("\nPresione una tecla para continuar...");
        Console.ReadKey();
    }

    // Métodos auxiliares para entrada segura de datos
    static int LeerEntero(string mensaje)
    {
        int valor;
        while (true)
        {
            Console.Write(mensaje);
            if (int.TryParse(Console.ReadLine(), out valor)) return valor;
            Console.WriteLine("❌ Entrada inválida. Intente nuevamente.");
        }
    }

    static double LeerDouble(string mensaje)
    {
        double valor;
        while (true)
        {
            Console.Write(mensaje);
            if (double.TryParse(Console.ReadLine(), out valor)) return valor;
            Console.WriteLine("❌ Entrada inválida. Intente nuevamente.");
        }
    }

    static string LeerTexto(string mensaje)
    {
        Console.Write(mensaje);
        return Console.ReadLine();
    }
}
