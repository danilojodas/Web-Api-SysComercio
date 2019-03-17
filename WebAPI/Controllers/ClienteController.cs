using CamadaClasses;
using CamadaNegocio;
using System.Collections.Generic;
using System.Data;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class ClienteController : ApiController
    {
        NCliente clienteDao;

        public ClienteController()
        {
            clienteDao = new NCliente();
        }

        // GET: api/Cliente
        public List<Cliente> Get()
        {
            return DataTable2List(clienteDao.Mostrar());
        }

        // GET: api/Cliente/nome
        [Route("api/Cliente/{nome}")]
        public List<Cliente> Get(string nome)
        {
            Cliente cli = new Cliente()
            {
                TextoBuscar = nome
            };

            return DataTable2List(clienteDao.BuscarNome(cli));
        }

        // POST: api/Cliente
        public IHttpActionResult Post([FromBody]Cliente cliente)
        {
            try
            {
                return Ok(clienteDao.Inserir(cliente));
            }
            catch
            {
                throw;
            }
        }

        // PUT: api/Cliente/5
        public IHttpActionResult Put(int id, [FromBody]Cliente cliente)
        {
            try
            {
                cliente.IdCliente = id;

                return Ok(clienteDao.Editar(cliente));
            }
            catch
            {
                throw;
            }
        }

        // DELETE: api/Cliente/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                Cliente cli = new Cliente()
                {
                    IdCliente = id
                };

                return Ok(clienteDao.Excluir(cli));
            }
            catch
            {
                throw;
            }
        }

        // Converte um objeto DataTable para List<Cliente>
        private List<Cliente> DataTable2List(DataTable dt)
        {
            Cliente cli;
            List<Cliente> lista = new List<Cliente>();

            if(dt == null)
            {
                return lista;
            }

            foreach (DataRow item in dt.Rows)
            {
                cli = new Cliente()
                {
                    IdCliente = int.Parse(item["idcliente"].ToString()),
                    Nome = item["nome"].ToString(),
                    Sobrenome = item["sobrenome"].ToString(),
                    Sexo = item["sexo"].ToString(),
                    TipoDocumento = item["tipo_documento"].ToString(),
                    NumDocumento = item["num_documento"].ToString(),
                    Endereco = item["endereco"].ToString(),
                    Telefone = item["telefone"].ToString(),
                    Email = item["email"].ToString()
                };

                lista.Add(cli);
            }

            return lista;
        }
    }
}
