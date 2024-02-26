using Application.Interfaces;
using Application.Model.DTOs;
using Application.Model.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
            if (ListaResponse.Count == 0)
            {
                var ObjetoAnonimo = new
                {
                    Mensaje = "No hay usuarios registrados actualmente."
                };
                return Ok(ObjetoAnonimo);
            }
            return Ok(ListaResponse);
        }



        [HttpGet("userAcompanante/{UsuarioId}")]
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




        [HttpGet("AcompananteHorarios/{AcompananteID}")]
        public async Task<IActionResult> GetHorariosByAcompananteId(int AcompananteID)
        {
            HorariosResponse? HorariosResponse = await  HorariosService.GetHorariosByAcompananteId(AcompananteID);
            if (HorariosResponse == null) 
            {
                var ObjetoAnonimo = new
                {
                    Mensaje = "No se ha encontrado el usuario correspondiente."
                };
                return NotFound(ObjetoAnonimo);
            }
            return Ok(HorariosResponse);
        }






        [HttpPost("{UsuarioId}")]
        public async Task<IActionResult> CreateAcompanante(int UsuarioID, HorariosDTO HorariosDTO)
        {
            try
            {
                int AcompananteID = await AcompananteService.CreateAcompanante(UsuarioID);
                string Result = await HorariosService.CreateHorario(AcompananteID, HorariosDTO);
                return Ok(Result);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }












    }
}
