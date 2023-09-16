using AutoMapper;
using Proyecto_Vehiculo.DTO.VehiculoDTO;
using Proyecto_Vehiculo.Entities;

namespace Proyecto_Vehiculo.Helpers
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            CreateMap<VehiculoCreateDTO, Vehiculo>();
        }
    }
}
