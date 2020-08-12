using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProvaEAuditoria.Models;

namespace ProvaEAuditoria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocacaosController : ControllerBase
    {

        public LocacaosController()
        {
        }

        // GET: api/Locacaos
        [HttpGet]
        public async Task<ActionResult<List<Locacao>>> GetLocacao()
        {
            using (var model = new LocacaoModel())
            {
                List<Locacao> lista = model.Read();
                return lista;
            }
        }

        // GET: api/Locacaos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Locacao>> GetLocacao(int id)
        {
            using (var model = new LocacaoModel())
            {
                List<Locacao> lista = model.Read();
                foreach (var locacao in lista)
                {
                    if (locacao.Id == id)
                        return locacao;
                }
                return null;
            }
        }

        // PUT: api/Locacaos/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLocacao(int id, Locacao locacoes)
        {
            if (id != locacoes.Id)
            {
                return BadRequest();
            }

            var locacao = new Locacao();
            locacao.Id = id;
            locacao.IdFilme = locacoes.IdFilme;
            locacao.IdCliente = locacoes.IdCliente;
            locacao.DataLocacao = locacoes.DataLocacao;
            locacao.DataDevolucao = locacoes.DataDevolucao;
            using (var model = new LocacaoModel())
            {
                model.Update(locacao);
                return NoContent();
            }
        }

        // POST: api/Locacaos
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Locacao>> PostLocacao(Locacao locacoes)
        {
            var locacao = new Locacao();
            locacao.IdFilme = locacoes.IdFilme;
            locacao.IdCliente = locacoes.IdCliente;
            locacao.DataLocacao = locacoes.DataLocacao;
            var filme = new FilmesController().GetFilmes(locacao.IdFilme);
            locacao.DataDevolucao = filme.Lancamento == true ? locacoes.DataLocacao.AddDays(2) : locacoes.DataLocacao.AddDays(3);
            using (var model = new LocacaoModel())
            {
                model.Create(locacao);
                return NoContent();
            }
        }

        // DELETE: api/Locacaos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Locacao>> DeleteLocacao(int id)
        {
            var locacao = new Locacao();
            locacao.Id = id;
            using (var model = new LocacaoModel())
            {
                model.Delete(locacao);
                return NoContent();
            }
        }

    }
}
