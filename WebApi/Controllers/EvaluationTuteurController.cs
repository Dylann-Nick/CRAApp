using Core.Domain.Entities;
using Core.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EvaluationTuteurController : ControllerBase
    {
        private readonly IEvaluationTuteurRepository _repository;

        public EvaluationTuteurController(IEvaluationTuteurRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _repository.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var evaluation = await _repository.GetByIdAsync(id);
            return evaluation == null ? NotFound() : Ok(evaluation);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EvaluationTuteur evaluation)
        {
            await _repository.AddAsync(evaluation);
            return CreatedAtAction(nameof(GetById), new { id = evaluation.Id }, evaluation);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] EvaluationTuteur evaluation)
        {
            if (id != evaluation.Id) return BadRequest();
            await _repository.UpdateAsync(evaluation);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }
}

