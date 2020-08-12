using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProvaEAuditoria.Models;

namespace ProvaEAuditoria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {

        public ClientesController()
        {
        }

        // GET: api/Clientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
        {
            using (var model = new ClientesModel())
            {
                List<Cliente> lista = model.Read();
                return lista;
            }
        }

        //GET: api/Clientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetCliente(int id)
        {

            using (var model = new ClientesModel())
            {
                List<Cliente> lista = model.Read();
                foreach (var cliente in lista)
                {
                    if (cliente.Id == id)
                        return cliente;
                }
                return null;
            }
        }

        // PUT: api/Clientes/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente(int id, Cliente clientes)
        {
            if (id != clientes.Id)
            {
                return BadRequest();
            }

            var cliente = new Cliente();
            cliente.Id = id;
            cliente.Nome = clientes.Nome;
            cliente.CPF = clientes.CPF;
            cliente.DataNascimento = clientes.DataNascimento;
            using (var model = new ClientesModel())
            {
                model.Update(cliente);
                return NoContent();
            }
        }

        // POST: api/Clientes
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Cliente>> PostCliente(Cliente clientes)
        {
            var cliente = new Cliente();
            cliente.Nome = clientes.Nome;
            cliente.CPF = clientes.CPF;
            cliente.DataNascimento = clientes.DataNascimento;
            using (var model = new ClientesModel())
            {
                model.Create(cliente);
                return NoContent();
            }
        }

        // DELETE: api/Clientes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Cliente>> DeleteCliente(int id)
        {
            var cliente = new Cliente();
            cliente.Id = id;
            using (var model = new ClientesModel())
            {
                model.Delete(cliente);
                return NoContent();
            }
        }


    }
}
