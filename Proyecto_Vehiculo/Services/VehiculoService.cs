using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Identity.Client;
using Proyecto_Vehiculo.Entities;
using System.Diagnostics.Eventing.Reader;

namespace Proyecto_Vehiculo.Services
{
    public class VehiculoService : IVehiculoService
    {
        private readonly ApplicationDbContext _context;
        private readonly IBusinessService _businessService;
   
        public VehiculoService(ApplicationDbContext context, IBusinessService businessService)
        {
            _context = context;
            _businessService = businessService;
        }
        public async Task<bool> PatenteExist(string patente)
        {
            var patenteExists = await _context.Vehiculos.AnyAsync(x => x.Patente == patente);
            if (patenteExists)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsPatenteValid(string patente)
        {
            var result = _businessService.IsPatenteValid(patente);
            return result;
        }
        public async Task Insert(Vehiculo entity)
        {
            _context.Vehiculos.Add(entity);
            _context.SaveChanges();
        }

        public bool IsColorValid(string MayuscColor)
        {
            var result = _businessService.IsColorValid(MayuscColor);
            return result;
        }
    }
}
