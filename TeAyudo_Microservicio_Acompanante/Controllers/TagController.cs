using Application.Interfaces.Service;
using Application.Model.Responses;
using Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TeAyudo_Microservicio_Acompanante.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private readonly ITagService TagService;

        public TagController(ITagService TagService)
        {
            this.TagService = TagService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTag()
        {
            List<TagResponse> ListTagResponse = await TagService.GetAllTag();
            return Ok(ListTagResponse);
        }







    }
}
