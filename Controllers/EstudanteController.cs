using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadastroEstudanteApi.Data;
using CadastroEstudanteApi.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CadastroEstudanteApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstudanteController : ControllerBase
    {
        private readonly AppDbContext _context;
        public EstudanteController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetEstudantes()
        {
            var estudantes = await _context.Estudantes.ToListAsync();
            return Ok(estudantes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEstudante(int id)
        {
            var estudante = await _context.Estudantes.FindAsync(id);
            if(estudante == null)
            {
                return NotFound();
            }

            return Ok(estudante);
        }

        [HttpPost]
        public async Task<IActionResult> PostEstudantes([FromBody] Estudante estudante)
        {
            _context.Estudantes.Add(estudante);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetEstudantes), new {id = estudante.Id }, estudante);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstudantes(int id, [FromBody] Estudante estudante)
        {
            if(id != estudante.Id)
            {
                return BadRequest();
            }

            _context.Entry(estudante).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

     

    }
}