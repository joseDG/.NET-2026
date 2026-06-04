using Microsoft.AspNetCore.Mvc;
using MusicStore.Dto.Resquest;
using MusicStore.Services.Abstractions;

namespace MusicStore.Api.Controllers
{
    [ApiController]
    [Route("api/concerts")]
    public class ConcertsController : ControllerBase
    {
        private readonly IConcertService service;


        public ConcertsController(IConcertService service)
        {
            this.service = service;
        }


        //[HttpGet]
        //public async Task<IActionResult> Get()
        //{
        //    var concertsDb = await repository.GetAsync();
        //    return Ok(concertsDb);
        //}

        [HttpGet("title")]
        public async Task<IActionResult> Get(string? title)
        {
            var response = await service.GetAsync(title);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await service.GetAsync(id);
            return response.Success ? Ok(response) : NotFound(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(ConcertRequestDto request)
        {
            var response = await service.AddAsync(request);
            return response.Success ? Ok(response) : BadRequest(response);

        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, ConcertRequestDto request)
        {
            var response = await service.UpdateAsync(id, request);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await service.DeleteAsync(id);
            return Ok(response);
        }

        [HttpPatch("{id:int}")]
        public async Task<IActionResult> Patch(int id)
        {
            return Ok(await service.FinalizeAsync(id));
        }

    }
}
