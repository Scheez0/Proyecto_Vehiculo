using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Proyecto_Vehiculo.DTO.VehiculoDTO;
using Proyecto_Vehiculo.Entities;
using Proyecto_Vehiculo.Services;

namespace Proyecto_Vehiculo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class VehiculoController : ControllerBase
    {
        private readonly IVehiculoService _vehiculoService;
        private readonly IMapper _mapper;

        public VehiculoController(IVehiculoService vehiculoService, IMapper mapper)
        {

            _vehiculoService = vehiculoService;
            _mapper = mapper;
        }


        [HttpGet]
        
        public ActionResult Get()
       
        {

            return Ok("HTTP Get");
        }


        [HttpPost]
        public async Task<ActionResult> Post(VehiculoCreateDTO model)
        {
            
            var patenteExists = await _vehiculoService.PatenteExist(model.Patente);
            if (patenteExists)
            {
                return BadRequest("Patente ya existe");
            }
            
            var colorMayuscula = _vehiculoService.IsColorValid(model.Color);
            if (!colorMayuscula)
            {
                return BadRequest("el color debe comenzar con una mayúscula");
            }
            var validPatente = _vehiculoService.IsPatenteValid(model.Patente);

            if (!validPatente)
            {
                return BadRequest("el largo de la patente no es valida");
            }

            var entity = _mapper.Map<Vehiculo>(model);
            await _vehiculoService.Insert(entity);

            return Ok("Vehiculo Ingresado");
        }

        [HttpPut]
        public ActionResult Put()
        {
            return Ok("Hola desde VehiculoController");
        }

        [HttpPatch]
        public ActionResult Patch()
        {
            return Ok("Hola desde VehiculoController");
        }


        [HttpDelete]
        public ActionResult Delete()
        {
            return Ok("Hola desde VehiculoController");
        }

    }
}
