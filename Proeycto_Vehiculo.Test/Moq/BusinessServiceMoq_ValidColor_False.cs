using Proyecto_Vehiculo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proeycto_Vehiculo.Test.Moq
{
    internal class BusinessServiceMoq_ValidColor_False : IBusinessService
    {
        public bool IsColorValid(string MayuscColor)
        {
            return false;
        }

        public bool IsPatenteValid(string patente)
        {
            return true;
        }
    }
}
