using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InsumosApp.Models;

namespace InsumosApp.Services
{
    public class InsumoService
    {
        private List<Insumo> _insumos = new List<Insumo>();

        // Crear un insumo
        public void AgregarInsumo(Insumo insumo)
        {
            if (insumo == null) throw new ArgumentNullException(nameof(insumo));
            _insumos.Add(insumo);
        }

        // Obtener todos los insumos
        public List<Insumo> ObtenerInsumos()
        {
            return _insumos;
        }

        // Obtener un insumo por ID
        public Insumo ObtenerInsumoPorId(int id)
        {
            return _insumos.FirstOrDefault(i => i.IdInsumo == id);
        }

        // Actualizar un insumo
        public bool ActualizarInsumo(int id, Insumo nuevoInsumo)
        {
            var insumoExistente = ObtenerInsumoPorId(id);
            if (insumoExistente == null) return false;

            _insumos.Remove(insumoExistente);
            _insumos.Add(nuevoInsumo);
            return true;
        }

        // Eliminar un insumo
        public bool EliminarInsumo(int id)
        {
            var insumo = ObtenerInsumoPorId(id);
            if (insumo == null) return false;

            _insumos.Remove(insumo);
            return true;
        }
    }
}
