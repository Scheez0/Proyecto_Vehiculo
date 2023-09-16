using Proyecto_Vehiculo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proeycto_Vehiculo.Test.UnitTest
{
    [TestClass]
    public class BusinessServiceTest
    {
        [TestMethod]
         public void IsColorValid_ReturnFalse()
            {
            //1. Preparacion de la prueba        
            var service = new BusinessService();
            var color = "rojo";
            //2. Ejecucion de la prueba
            var result = service.IsColorValid(color);
            //3. Verificacion
            Assert.IsFalse(result);
            }
        [TestMethod]
        public void IsColorValid_ReturnTrue()
        {
            //1. Preparacion de la prueba        
            var service = new BusinessService();
            var color = "Rojo";
            //2. Ejecucion de la prueba
            var result = service.IsColorValid(color);
            //3. Verificacion
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void IsPatenteValid_ReturnFalse()
        {
            //1. Preparacion de la prueba        
            var service = new BusinessService();
            var patente = "12345";
            //2. Ejecucion de la prueba
            var result = service.IsPatenteValid(patente);
            //3. Verificacion
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void IsPatenteValid_ReturnTrue()
        {
            //1. Preparacion de la prueba        
            var service = new BusinessService();
            var patente = "123456";
            //2. Ejecucion de la prueba
            var result = service.IsPatenteValid(patente);
            //3. Verificacion
            Assert.IsTrue(result);
        }
    }
}
