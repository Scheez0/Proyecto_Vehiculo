using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Proyecto_Vehiculo.Controllers;
using Proyecto_Vehiculo.Services;
using Proyecto_Vehiculo.VehiculoDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proeycto_Vehiculo.Test.UnitTest
{
    [TestClass]
    public class VehiculoControllerTest : BaseTest
    {
        [TestMethod]
        public async Task Post_Return_PatenteExists()
        {
            // Preparacion
            var vehiculoService = new Mock<IVehiculoService>();
            vehiculoService.Setup(x => x.PatenteExist(It.IsAny<string>())).ReturnsAsync(true);
            var mapper = BuildMapper();
            var controller = new VehiculoController(vehiculoService.Object, mapper);
            var vehiculo = new VehiculoCreateDTO
            {
                Patente = "ABC123",
                MarcaId = 1,
                ModeloId = 1,
                Color = "Rojo",
                CarroceriaId = 1
            };

           // Ejecucion
           var result = await controller.Post(vehiculo);


           // Verificacion
           Assert.IsTrue(result is BadRequestObjectResult);
           Assert.AreEqual("Patente ya existe", ((BadRequestObjectResult)result).Value);    
        }
        [TestMethod]
        public async Task Post_Return_ColorMayuscula()
        {
            // Preparacion
            var vehiculoService = new Mock<IVehiculoService>();
            vehiculoService.Setup(x => x.PatenteExist(It.IsAny<string>())).ReturnsAsync(false);
            vehiculoService.Setup(x => x.IsColorValid(It.IsAny<string>())).Returns(false);
            var mapper = BuildMapper();
            var controller = new VehiculoController(vehiculoService.Object, mapper);
            var vehiculo = new VehiculoCreateDTO
            {
                Patente = "ABC123",
                MarcaId = 1,
                ModeloId = 1,
                Color = "rojo",
                CarroceriaId = 1
            };

            // Ejecucion
            var result = await controller.Post(vehiculo);
        }
        [TestMethod]    
        public async Task Post_Return_ValidPatente()
        {
            // Preparacion
            var vehiculoService = new Mock<IVehiculoService>();
            vehiculoService.Setup(x => x.PatenteExist(It.IsAny<string>())).ReturnsAsync(false);
            vehiculoService.Setup(x => x.IsColorValid(It.IsAny<string>())).Returns(true);
            vehiculoService.Setup(x => x.IsPatenteValid(It.IsAny<string>())).Returns(false);
            var mapper = BuildMapper();
            var controller = new VehiculoController(vehiculoService.Object, mapper);
            var vehiculo = new VehiculoCreateDTO
            {
                Patente = "ABC123",
                MarcaId = 1,
                ModeloId = 1,
                Color = "Rojo",
                CarroceriaId = 1
            };

            // Ejecucion
            var result = await controller.Post(vehiculo);
        }
        [TestMethod]
        public async Task Post_Return_Ok()
        {
            // Preparacion
            var vehiculoService = new Mock<IVehiculoService>();
            vehiculoService.Setup(x => x.PatenteExist(It.IsAny<string>())).ReturnsAsync(false);
            vehiculoService.Setup(x => x.IsColorValid(It.IsAny<string>())).Returns(true);
            vehiculoService.Setup(x => x.IsPatenteValid(It.IsAny<string>())).Returns(true);
            var mapper = BuildMapper();
            var controller = new VehiculoController(vehiculoService.Object, mapper);
            var vehiculo = new VehiculoCreateDTO
            {
                Patente = "ABC123",
                MarcaId = 1,
                ModeloId = 1,
                Color = "Rojo",
                CarroceriaId = 1
            };

            // Ejecucion
            var result = await controller.Post(vehiculo);

            // Verificacion
            Assert.IsTrue(result is OkObjectResult);
            Assert.AreEqual("Vehiculo Ingresado", ((OkObjectResult)result).Value);
        }
    }
}
