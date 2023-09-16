using Microsoft.EntityFrameworkCore;
using Proeycto_Vehiculo.Test.Moq;
using Proyecto_Vehiculo.Entities;
using Proyecto_Vehiculo.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proeycto_Vehiculo.Test.UnitTest
{
    [TestClass]
    public class VehiculoServiceTest : BaseTest
    {
        [TestMethod]
        public async Task PatenteExist_ReturnFalse()
        {
            //Preparacion
            var dbName = Guid.NewGuid().ToString();
            var context1 = BuildDataBaseContext(dbName);
            var businessMoq = new BusinessServiceMoq();
            var service = new VehiculoService(context1, businessMoq);
            var entity = new Vehiculo 
            { 
                Patente = "ABC123", 
                MarcaId = 1, 
                ModeloId = 1, 
                Color = "Rojo", 
                CarroceriaId = 1 
            };

            //Ejecucion
            var result = await service.PatenteExist(entity.Patente);  

            //Validacion
            Assert.IsFalse(result);
        }
        [TestMethod]
        public async Task PatenteExist_ReturnTrue()
        {
            //Preparacion
            var dbName = Guid.NewGuid().ToString();
            var context1 = BuildDataBaseContext(dbName);
            var businessMoq = new BusinessServiceMoq();
            var service = new VehiculoService(context1, businessMoq);
            var entity = new Vehiculo
            {
                Patente = "ABC123",
                MarcaId = 1,
                ModeloId = 1,
                Color = "Rojo",
                CarroceriaId = 1
            };
            context1.Vehiculos.Add(new Vehiculo {
                Patente = "ABC123",
                MarcaId = 1,
                ModeloId = 1,
                Color = "Azul",
                CarroceriaId = 1
            });
            context1.SaveChanges();

            //Ejecucion
            var result = await service.PatenteExist(entity.Patente);

            //Validacion
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsPatenteValid_ReturnTrue()
        {
            //Preparacion
            var dbName = Guid.NewGuid().ToString();
            var context1 = BuildDataBaseContext(dbName);
            var businessMoq = new BusinessServiceMoq_PatenteValid_True();
            var service = new VehiculoService(context1, businessMoq);
            var patente = "ABC123";

            //Ejecucion
            var result = service.IsPatenteValid(patente);

            //Validacion
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void IsPatenteValid_ReturnFalse()
        {
            //Preparacion
            var dbName = Guid.NewGuid().ToString();
            var context1 = BuildDataBaseContext(dbName);
            var businessMoq = new BusinessServiceMoq_PatenteValid_False();
            var service = new VehiculoService(context1, businessMoq);
            var patente = "ABC1234";

            //Ejecucion
            var result = service.IsPatenteValid(patente);

            //Validacion
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void IsColorValid_ReturnTrue()
        {
            //Preparacion
            var dbName = Guid.NewGuid().ToString();
            var context1 = BuildDataBaseContext(dbName);
            var businessMoq = new BusinessServiceMoq_ValidColor_True();
            var service = new VehiculoService(context1, businessMoq);
            var color = "ROJO";

            //Ejecucion
            var result = service.IsColorValid(color);

            //Validacion
            Assert.IsTrue(result);
        }
        [TestMethod]    
        public void IsColorValid_ReturnFalse()
        {
            //Preparacion
            var dbName = Guid.NewGuid().ToString();
            var context1 = BuildDataBaseContext(dbName);
            var businessMoq = new BusinessServiceMoq_ValidColor_False();
            var service = new VehiculoService(context1, businessMoq);
            var color = "rojo";

            //Ejecucion
            var result = service.IsColorValid(color);

            //Validacion
            Assert.IsFalse(result);
        }

        [TestMethod]
        public async Task Insert()
        {
            //Preparacion
            var dbName = Guid.NewGuid().ToString();
            var context1 = BuildDataBaseContext(dbName);    
            var vehiculoToInsert = new Vehiculo {
                Patente = "ABC123",
                MarcaId = 1,
                ModeloId = 1,
                Color = "Azul",
                CarroceriaId = 1
            };
            var businessMoq = new BusinessServiceMoq();
            var service = new VehiculoService(context1,businessMoq);

            //Ejecucion
            await service.Insert(vehiculoToInsert);
            var result = await context1.Vehiculos.CountAsync();

            //Validacion
            Assert.AreEqual(1, result);
        }
    }
}
