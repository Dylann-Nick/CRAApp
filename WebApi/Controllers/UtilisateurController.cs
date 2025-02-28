using Core.Domain.Entities;
using Core.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtilisateurController : ControllerBase
    {
        private readonly IUtilisateurRepository _repository;

        public UtilisateurController(IUtilisateurRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var utilisateur = await _repository.GetByIdAsync(id);
            return utilisateur == null ? NotFound() : Ok(utilisateur);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Utilisateur utilisateur)
        {
            await _repository.AddAsync(utilisateur);
            return CreatedAtAction(nameof(GetById), new { id = utilisateur.Id }, utilisateur);
        }
    }
}

