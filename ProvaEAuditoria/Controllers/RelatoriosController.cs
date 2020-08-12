using Microsoft.AspNetCore.Mvc;
using ProvaEAuditoria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProvaEAuditoria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RelatoriosController
    {

        [HttpGet("ClientesComAtraso")]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientesAtraso()
        {
            var modelCliente = new ClientesModel();
            var modelLocacao = new LocacaoModel();

            List<Cliente> listaCliente = modelCliente.Read();
            List<Locacao> listaLocacao = modelLocacao.Read();
            var listaDeAtrasados = new List<Cliente>();
            foreach (var locacao in listaLocacao)
            {
                if (locacao.DataDevolucao <= DateTime.Now)
                {
                    foreach (var cliente in listaCliente)
                    {
                        if (cliente.Id == locacao.IdCliente && !listaDeAtrasados.Contains(cliente))
                            listaDeAtrasados.Add(cliente);
                    }
                }
            }
            return listaDeAtrasados;
        }



        [HttpGet("NuncaAlugado")]
        public async Task<ActionResult<IEnumerable<Filmes>>> GetNuncaAlugado()
        {
            var modelFilme = new FilmesModel();
            var modelLocacao = new LocacaoModel();

            List<Filmes> listaFilme = modelFilme.Read();
            List<Locacao> listaLocacao = modelLocacao.Read();
            var listaNuncaAlugados = new List<Filmes>();
            var listaIdsFilmesAlugados = new List<int>();
            foreach (var locacao in listaLocacao)
            {
                if (!listaIdsFilmesAlugados.Contains(locacao.IdFilme))
                    listaIdsFilmesAlugados.Add(locacao.IdFilme);
            }
            foreach (var filme in listaFilme)
            {
                if (!listaIdsFilmesAlugados.Contains(filme.Id) && !listaNuncaAlugados.Contains(filme))
                    listaNuncaAlugados.Add(filme);

            }
            return listaNuncaAlugados;
        }

        [HttpGet("Top5Ano")]
        public async Task<ActionResult<IEnumerable<FilmeAlugado>>> GetTop5NoAno()
        {
            var modelFilme = new FilmesModel();
            var modelLocacao = new LocacaoModel();

            List<Filmes> listaFilme = modelFilme.Read();
            List<Locacao> listaLocacao = modelLocacao.Read();
            var lista5MaisAlugados = new List<FilmeAlugado>();
            var listaIdsFilmesAlugados = new List<int>();
            foreach (var locacao in listaLocacao)
            {
                if ((DateTime.Now - locacao.DataLocacao).Days <= 365)
                    listaIdsFilmesAlugados.Add(locacao.IdFilme);
            }
            foreach (var filme in listaFilme)
            {
                if (listaIdsFilmesAlugados.Contains(filme.Id) && lista5MaisAlugados.Count <= 5)
                {
                    var filmeAlugado = new FilmeAlugado();
                    filmeAlugado.Filme = filme;
                    filmeAlugado.QuantidadeDeAlugueis = 0;
                    lista5MaisAlugados.Add(filmeAlugado);
                }
            }

            foreach (var filme in listaFilme)
            {
                if (listaIdsFilmesAlugados.Contains(filme.Id))
                {
                    foreach (var idFilmeAlugado in listaIdsFilmesAlugados)
                    {
                        if (idFilmeAlugado == filme.Id)
                        {
                            foreach (var filmeAlugado in lista5MaisAlugados)
                            {
                                if (filmeAlugado.Filme.Id == filme.Id)
                                {
                                    filmeAlugado.QuantidadeDeAlugueis++;
                                }
                            }
                        }
                    }

                }
            }
            var listTop5Ano = lista5MaisAlugados.OrderByDescending(filme => filme.QuantidadeDeAlugueis).Take(5);

            return listTop5Ano.ToList();
        }

        [HttpGet("3MenosSemana")]
        public async Task<ActionResult<IEnumerable<FilmeAlugado>>> Get3MenosSemana()
        {
            var modelFilme = new FilmesModel();
            var modelLocacao = new LocacaoModel();

            List<Filmes> listaFilme = modelFilme.Read();
            List<Locacao> listaLocacao = modelLocacao.Read();
            var lista5MaisAlugados = new List<FilmeAlugado>();
            var listaIdsFilmesAlugados = new List<int>();
            foreach (var locacao in listaLocacao)
            {
                if ((DateTime.Now - locacao.DataLocacao).Days <= 7)
                    listaIdsFilmesAlugados.Add(locacao.IdFilme);
            }
            foreach (var filme in listaFilme)
            {



                if (listaIdsFilmesAlugados.Contains(filme.Id))
                {
                    var filmeAlugado = new FilmeAlugado();
                    filmeAlugado.Filme = filme;
                    filmeAlugado.QuantidadeDeAlugueis = 0;
                    lista5MaisAlugados.Add(filmeAlugado);
                }

            }

            foreach (var filme in listaFilme)
            {
                if (listaIdsFilmesAlugados.Contains(filme.Id))
                {
                    foreach (var idFilmeAlugado in listaIdsFilmesAlugados)
                    {
                        if (idFilmeAlugado == filme.Id)
                        {
                            foreach (var filmeAlugado in lista5MaisAlugados)
                            {
                                if (filmeAlugado.Filme.Id == filme.Id)
                                {
                                    filmeAlugado.QuantidadeDeAlugueis++;
                                }
                            }
                        }
                    }

                }
            }
            var list3MenosSemana = lista5MaisAlugados.OrderBy(filme => filme.QuantidadeDeAlugueis).Take(3);
            return list3MenosSemana.ToList();
        }

        [HttpGet("SegundoMelhorCliente")]
        public async Task<ActionResult<ClienteAluga>> GetSecondBestClient()
        {
            var modelCliente = new ClientesModel();
            var modelLocacao = new LocacaoModel();

            List<Cliente> listaCliente = modelCliente.Read();
            List<Locacao> listaLocacao = modelLocacao.Read();
            var lista5MaisAluga = new List<ClienteAluga>();
            var listaIdsClienteAlugaram = new List<int>();
            foreach (var locacao in listaLocacao)
            {
                listaIdsClienteAlugaram.Add(locacao.IdCliente);
            }
            foreach (var cliente in listaCliente)
            {



                if (listaIdsClienteAlugaram.Contains(cliente.Id))
                {
                    var clienteAluga = new ClienteAluga();
                    clienteAluga.Cliente = cliente;
                    clienteAluga.QuantidadeDeAlugueis = 0;
                    lista5MaisAluga.Add(clienteAluga);
                }

            }

            foreach (var cliente in listaCliente)
            {
                if (listaIdsClienteAlugaram.Contains(cliente.Id))
                {
                    foreach (var idFilmeAlugado in listaIdsClienteAlugaram)
                    {
                        if (idFilmeAlugado == cliente.Id)
                        {
                            foreach (var filmeAlugado in lista5MaisAluga)
                            {
                                if (filmeAlugado.Cliente.Id == cliente.Id)
                                {
                                    filmeAlugado.QuantidadeDeAlugueis++;
                                }
                            }
                        }
                    }

                }
            }
            var secondBestClient = lista5MaisAluga.OrderByDescending(cliente => cliente.QuantidadeDeAlugueis).Take(2);
            return secondBestClient.Last();
        }

        public class FilmeAlugado
        {
            public Filmes Filme { get; set; }
            public int QuantidadeDeAlugueis { get; set; }
        }

        public class ClienteAluga
        {
            public Cliente Cliente { get; set; }
            public int QuantidadeDeAlugueis { get; set; }
        }
    }
}
