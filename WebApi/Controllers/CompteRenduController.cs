using Core.Domain.Entities;
using Core.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompteRenduController : ControllerBase
    {
        private readonly ICompteRenduRepository _repository;

        public CompteRenduController(ICompteRenduRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _repository.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var compteRendu = await _repository.GetByIdAsync(id);
            return compteRendu == null ? NotFound() : Ok(compteRendu);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CompteRendu compteRendu)
        {
            await _repository.AddAsync(compteRendu);
            return CreatedAtAction(nameof(GetById), new { id = compteRendu.Id }, compteRendu);
        }
    }

}
