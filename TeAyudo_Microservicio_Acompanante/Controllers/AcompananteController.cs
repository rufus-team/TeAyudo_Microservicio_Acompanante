using Application.Interfaces.Service;
using Application.Model.DTOs;
using Application.Model.Responses;
using Microsoft.AspNetCore.Mvc;

namespace TeAyudo_Microservicio_Acompanante.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcompananteController : ControllerBase
    {
        private readonly IAcompananteService AcompananteService;

        public AcompananteController(IAcompananteService AcompananteService)
        {
            this.AcompananteService = AcompananteService;
        }


        [HttpGet] // ---------------------------------------  LISTOOOOOOOOOO
        public async Task<IActionResult> GetAllAcompanante()
        {
            List<AcompananteResponse> ListaResponse = await AcompananteService.GetAllAcompanante();
            return Ok(ListaResponse);
        }



        [HttpGet("UserAcompanante/{UsuarioID}")] //Comenzaremos con la comunicacion
        public async Task<IActionResult> GetAcompananteByUsuarioID(int UsuarioID)
        {
            AcompananteResponse? AcompananteResponse = await AcompananteService.GetAcompananteByUsuarioID(UsuarioID);
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




        [HttpGet("{AcompananteID}")] // -----------------------------------------LISTO
        public async Task<IActionResult> GetAcompananteByID(int AcompananteID)
        {
            AcompananteResponse? AcompananteResponse = await AcompananteService.GetAcompananteByID(AcompananteID);
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


        [HttpGet("Tag/{AcompananteID}")]
        public async Task<IActionResult> GetTagByAcompananteID(int AcompananteID)
        {
            try
            {
                List<TagResponse> ListaTagResponse = await AcompananteService.GetTagByAcompananteID(AcompananteID);
                return Ok(ListaTagResponse);
            }
            catch (Exception Exc)
            {
                return BadRequest(Exc.Message);
            }

        }







        [HttpPost] // -----------------------------------------LISTO
        public async Task<IActionResult> CreateAcompanante(AcompananteDTO AcompananteDTO)
        {
            try
            {
                AcompananteResponse AcompananteResponse = await AcompananteService.CreateAcompanante(AcompananteDTO);
                return Ok(AcompananteResponse);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpPost("Tag/{AcompananteID}")]
        public async Task<IActionResult> AddTagsAcompanante(int AcompananteID, List<TagDTO> ListTag)
        {
            List<TagResponse> ListTagResponse = await AcompananteService.AddCaracteristicas(AcompananteID, ListTag);
            return Ok(ListTagResponse);
        }









    }
}
