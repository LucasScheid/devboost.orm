using DevBoost.ORM.Data.Data;
using DevBoost.ORM.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DevBoost.ORM.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FutController : ControllerBase
    {
        private readonly FutDbContext _context;

        public FutController(FutDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Jogador> Get()
        {
            return _context.Jogadores.ToList();
        }

        [HttpPost]
        public IActionResult GetById(int id)
        {
            var jogador = _context.Jogadores.Include(x => x.Posicao).Include(x => x.Clube).FirstOrDefault(x => x.Id == id);
            if (jogador == null)
                return NotFound();

            return Ok(new { id = jogador.Id, nome = jogador.Nome, clube = jogador.Clube.Nome, posicao = jogador.Posicao.Nome });
        }


        [HttpPost]
        [Route("clube")]
        public IActionResult Create(Clube clube)
        {
            //deveria ser um viewmodel para validar a entrada de dados
            if (clube == null)
                return BadRequest("Por favor, informe o clube");

            _context.Add(clube);
            _context.SaveChanges();

            return Ok(clube);
        }

        //esilean
        [HttpPut("{id}")]
        [Route("clube")]
        public IActionResult Update(int id, Clube novoClube)
        {
            //deveria ser um viewmodel para validar a entrada de dados
            if (novoClube == null)
                return BadRequest("Por favor, informe o clube");

            var clube = _context.Clubes.FirstOrDefault(x => x.Id == id);
            if (clube == null)
                return NotFound();


            clube.Nome = novoClube.Nome;
            clube.Cidade = novoClube.Cidade;
            clube.UF = novoClube.UF;

            _context.SaveChanges();

            return Ok(clube);
        }

        [HttpDelete("{id}")]
        [Route("clube")]
        public IActionResult Delete(int id)
        {
            var clube = _context.Clubes.FirstOrDefault(x => x.Id == id);
            if (clube == null)
                return NotFound();

            _context.Remove(clube);
            _context.SaveChanges();

            return NoContent();
        }


    }
}
