using Application.Interfaces.Service;
using Application.Model.DTOs;
using Application.Model.Responses;
using Microsoft.AspNetCore.Mvc;

namespace TeAyudo_Microservicio_Acompanante.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HorariosController : ControllerBase
    {
        private readonly IHorariosService HorariosService;

        public HorariosController(IHorariosService HorariosService)
        {
            this.HorariosService = HorariosService;
        }


        [HttpGet("{AcompananteID}")] //-------------------------------------------------LISTO
        public async Task<IActionResult> GetHorariosByAcompananteId(int AcompananteID)
        {
            HorariosResponse? HorariosResponse = await HorariosService.GetHorariosByAcompananteID(AcompananteID);
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




        [HttpPost] //-------------------------------------------------LISTO
        public async Task<IActionResult> GetHorariosIdByFiltro(HorariosDtoFiltro HorariosDtoFiltro)
        {
            List<HorariosIdResponse> ListaHorariosResponse = await HorariosService.GetHorariosIdByFiltro(HorariosDtoFiltro);
            return Ok(ListaHorariosResponse);
        }






        [HttpPost("Add")] //-------------------------------------------------LISTO
        public async Task<IActionResult> AddHorarios(HorariosDTO HorariosDTO)
        {
            try
            {
                HorariosResponse HorariosResponse = await HorariosService.AddHorarios(HorariosDTO);
                return new JsonResult(HorariosResponse) { StatusCode = 201 };
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
















    }
}
