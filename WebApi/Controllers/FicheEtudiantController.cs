using Core.Domain.Entities;
using Core.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FicheEtudiantController : ControllerBase
    {
        private readonly IFicheEtudiantRepository _repository;

        public FicheEtudiantController(IFicheEtudiantRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{etudiantId}")]
        public async Task<IActionResult> GetByEtudiantId(Guid etudiantId)
        {
            var fiche = await _repository.GetByEtudiantIdAsync(etudiantId);
            return fiche == null ? NotFound() : Ok(fiche);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] FicheEtudiant fiche)
        {
            await _repository.AddAsync(fiche);
            return CreatedAtAction(nameof(GetByEtudiantId), new { etudiantId = fiche.EtudiantId }, fiche);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] FicheEtudiant fiche)
        {
            if (id != fiche.Id) return BadRequest();
            await _repository.UpdateAsync(fiche);
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

