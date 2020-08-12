using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProvaEAuditoria.Models;

namespace ProvaEAuditoria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmesController : ControllerBase
    {
        public FilmesController()
        {
        }

        // GET: api/Filmes
        [HttpGet]
        public async Task<ActionResult<List<Filmes>>> GetFilmes()
        {
            using (var model = new FilmesModel())
            {
                List<Filmes> lista = model.Read();
                return lista;
            }
        }

        // GET: api/Filmes/5
        [HttpGet("{id}")]
        public Filmes GetFilmes(int id)
        {
            using (var model = new FilmesModel())
            {
                List<Filmes> lista = model.Read();
                foreach (var filme in lista)
                {
                    if (filme.Id == id)
                        return filme;
                }
                return null;
            }
        }

        // PUT: api/Filmes/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFilmes(int id, Filmes filmes)
        {
            if (id != filmes.Id)
            {
                return BadRequest();
            }

            var filme = new Filmes();
            filme.Id = filmes.Id;
            filme.Titulo = filmes.Titulo;
            filme.Lancamento = filmes.Lancamento;
            filme.ClassificacaoIndicativa = filmes.ClassificacaoIndicativa;
            using (var model = new FilmesModel())
            {
                model.Update(filme);
                return NoContent();
            }
        }

        // POST: api/Filmes
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Filmes>> PostFilmes(Filmes filmes)
        {
            var filme = new Filmes();
            filme.Titulo = filmes.Titulo;
            filme.Lancamento = filmes.Lancamento;
            filme.ClassificacaoIndicativa = filmes.ClassificacaoIndicativa;
            using (var model = new FilmesModel())
            {
                model.Create(filme);
                return NoContent();
            }
        }

        // DELETE: api/Filmes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Filmes>>> DeleteFilmes(int id)
        {
            var filme = new Filmes();
            filme.Id = id;
            using (var model = new FilmesModel())
            {
                model.Delete(filme);
                return NoContent();
            }
        }
    }
}
