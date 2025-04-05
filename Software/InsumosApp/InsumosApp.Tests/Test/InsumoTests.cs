using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InsumosApp.Models;
using InsumosApp.Services;
using NUnit.Framework;

namespace InsumosApp.Tests
{
    [TestFixture]
    public class InsumoTests
    {
        [Test]
        public void CrearInsumo_DeberiaCrearUnInsumoConDatosValidos()
        {
            // Arrange
            int id = 1;
            string nombre = "Harina";
            string unidadMedida = "kg";
            double cantidadInventario = 50.0;
            string fechaCaducidad = "2025-12-31";
            string proveedor = "ProveedorX";
            double costoUnitario = 10.5;
            string categoria = "Alimentos";
            string fechaEntrada = "2024-04-02";
            double cantidadMinimaAlerta = 5.0;

            // Act
            var insumo = new Insumo(id, nombre, unidadMedida, cantidadInventario, fechaCaducidad, proveedor, costoUnitario, categoria, fechaEntrada, cantidadMinimaAlerta);

            // Assert
            Assert.AreEqual(id, insumo.IdInsumo);
            Assert.AreEqual(nombre, insumo.Nombre);
            Assert.AreEqual(unidadMedida, insumo.UnidadMedida);
            Assert.AreEqual(cantidadInventario, insumo.CantidadInventario);
            Assert.AreEqual(fechaCaducidad, insumo.FechaCaducidad);
            Assert.AreEqual(proveedor, insumo.Proveedor);
            Assert.AreEqual(costoUnitario, insumo.CostoUnitario);
            Assert.AreEqual(categoria, insumo.Categoria);
            Assert.AreEqual(fechaEntrada, insumo.FechaEntrada);
            Assert.AreEqual(cantidadMinimaAlerta, insumo.CantidadMinimaAlerta);
        }

        [Test]
        public void CrearInsumo_ConNombreVacio_DeberiaLanzarExcepcion()
        {
            Assert.Throws<ArgumentException>(() =>
                new Insumo(1, "", "kg", -10, "2025-12-31", "ProveedorA", 10.5, "Alimentos", "2024-04-02", 5));
        }

        [Test]
        public void CrearInsumo_ConCantidadNegativa_DeberiaLanzarExcepcion()
        {
            Assert.Throws<ArgumentException>(() =>
                new Insumo(1, "Harina", "kg", -10, "2025-12-31", "ProveedorX", 10.5, "Alimentos", "2024-04-02", 5));
        }

        [Test]
        public void CrearInsumo_ConCostoNegativo_DeberiaLanzarExcepcion()
        {
            Assert.Throws<ArgumentException>(() =>
                new Insumo(1, "Harina", "kg", 10, "2025-12-31", "ProveedorX", -10.5, "Alimentos", "2024-04-02", 5));
        }

    }

    namespace InsumosApp.Tests
    {
        [TestFixture]
        public class InsumoServiceTests
        {
            private InsumoService _service;

            [SetUp]
            public void SetUp()
            {
                _service = new InsumoService();
            }

            [Test]
            public void AgregarInsumo_DeberiaAgregarUnNuevoInsumo()
            {
                var insumo = new Insumo(1, "Harina", "kg", 50, "2025-12-31", "ProveedorX", 10.5, "Alimentos", "2024-04-02", 5);
                _service.AgregarInsumo(insumo);

                var resultado = _service.ObtenerInsumos();
                Assert.AreEqual(1, resultado.Count);
                Assert.AreEqual(insumo, resultado[0]);
            }

            [Test]
            public void ObtenerInsumoPorId_Existente_DeberiaRetornarElInsumo()
            {
                var insumo = new Insumo(1, "Harina", "kg", 50, "2025-12-31", "ProveedorX", 10.5, "Alimentos", "2024-04-02", 5);
                _service.AgregarInsumo(insumo);

                var resultado = _service.ObtenerInsumoPorId(1);
                Assert.IsNotNull(resultado);
                Assert.AreEqual(insumo, resultado);
            }

            [Test]
            public void ObtenerInsumoPorId_NoExistente_DeberiaRetornarNull()
            {
                var resultado = _service.ObtenerInsumoPorId(999);
                Assert.IsNull(resultado);
            }

            [Test]
            public void ActualizarInsumo_Existente_DeberiaActualizarCorrectamente()
            {
                var insumo = new Insumo(1, "Harina", "kg", 50, "2025-12-31", "ProveedorX", 10.5, "Alimentos", "2024-04-02", 5);
                _service.AgregarInsumo(insumo);

                var nuevoInsumo = new Insumo(1, "Azúcar", "kg", 100, "2026-01-01", "ProveedorY", 15.0, "Alimentos", "2024-04-02", 10);
                var resultado = _service.ActualizarInsumo(1, nuevoInsumo);

                var insumoActualizado = _service.ObtenerInsumoPorId(1);

                Assert.IsTrue(resultado);
                Assert.AreEqual("Azúcar", insumoActualizado.Nombre);
                Assert.AreEqual(100, insumoActualizado.CantidadInventario);
            }

            [Test]
            public void EliminarInsumo_Existente_DeberiaEliminarlo()
            {
                var insumo = new Insumo(1, "Harina", "kg", 50, "2025-12-31", "ProveedorX", 10.5, "Alimentos", "2024-04-02", 5);
                _service.AgregarInsumo(insumo);

                var resultado = _service.EliminarInsumo(1);
                var insumoEliminado = _service.ObtenerInsumoPorId(1);

                Assert.IsTrue(resultado);
                Assert.IsNull(insumoEliminado);
            }

            [Test]
            public void EliminarInsumo_NoExistente_DeberiaRetornarFalso()
            {
                var resultado = _service.EliminarInsumo(999);
                Assert.IsFalse(resultado);
            }
        }
    }
}

