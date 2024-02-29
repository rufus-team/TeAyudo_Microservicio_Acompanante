using Application.Interfaces;
using Application.Model.DTOs;
using Application.Model.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace TeAyudo_Microservicio_Acompanante.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcompananteController : ControllerBase
    {
        private readonly IAcompananteService AcompananteService;
        private readonly IHorariosService HorariosService;

        public AcompananteController(IAcompananteService AcompananteService, IHorariosService HorariosService)
        {
            this.AcompananteService = AcompananteService;
            this.HorariosService = HorariosService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllAcompanante()
        {
            List<AcompananteResponse> ListaResponse = await AcompananteService.GetAllAcompanante();
            return Ok(ListaResponse);
        }



        [HttpGet("UserAcompanante/{UsuarioId}")]
        public async Task<IActionResult> GetAcompananteByUsuarioId(int UsuarioId)
        {
            AcompananteResponse? AcompananteResponse = await AcompananteService.GetAcompananteByUsuarioId(UsuarioId);
            if (AcompananteResponse == null) 
            {
                var ObjetoAnonimo = new
                {
                    Mensaje = "No se ha encontrado el usuario correspondiente."
                };
                return NotFound(ObjetoAnonimo);
            }
            return Ok(AcompananteResponse);
        }




        [HttpGet("Acompanante/{AcompananteId}")]
        public async Task<IActionResult> GetAcompananteById(int AcompananteId)
        {
            AcompananteResponse? AcompananteResponse = await AcompananteService.GetAcompananteById(AcompananteId);
            if (AcompananteResponse == null)
            {
                var ObjetoAnonimo = new
                {
                    Mensaje = "No se ha encontrado el usuario correspondiente."
                };
                return NotFound(ObjetoAnonimo);
            }
            return Ok(AcompananteResponse);
        }




        [HttpGet("{AcompananteId}")]
        public async Task<IActionResult> GetHorariosByAcompananteId(int AcompananteId)
        {
            HorariosResponse? HorariosResponse = await  HorariosService.GetHorariosByAcompananteId(AcompananteId);
            if (HorariosResponse == null) 
            {
                var ObjetoAnonimo = new
                {
                    Mensaje = "No se ha encontrado los horarios del usuario correspondiente."
                };
                return NotFound(ObjetoAnonimo);
            }
            return Ok(HorariosResponse);
        }





        [HttpPost("{UsuarioId}")]
        public async Task<IActionResult> CreateAcompanante(int UsuarioId, HorariosDTO HorariosDTO)
        {
            try
            {
                AcompananteResponse AcompananteResponse = await AcompananteService.CreateAcompanante(UsuarioId);
                HorariosResponse HorariosResponse = await HorariosService.CreateHorario(AcompananteResponse.AcompananteID, HorariosDTO);
                object[] arrayDeObjetos = new object[] { AcompananteResponse, HorariosResponse };
                return Ok(arrayDeObjetos);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

















    }
}
