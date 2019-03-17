using CamadaClasses;
using CamadaNegocio;
using System.Collections.Generic;
using System.Data;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class CategoriaController : ApiController
    {
        // GET: api/Categoria
        public List<Categoria> Get()
        {
            List<Categoria> listaCategorias = DataTable2List(new NCategoria().Mostrar());
            return listaCategorias;
        }

        // GET: api/Categoria/5
        public string Get(int id)
        {
            return "value";
        }

        //GET: api/Categoria/nome
        [Route("api/Categoria/{nome}")]
        public List<Categoria> Get(string nome)
        {
            Categoria cat = new Categoria()
            {
                TextoBuscar = nome
            };

            List<Categoria> listaCategorias = DataTable2List(new NCategoria().BuscarNome(cat));
            return listaCategorias;
        }

        // POST: api/Categoria
        public IHttpActionResult Post([FromBody]Categoria value)
        {
            try
            {
                return Ok(new NCategoria().Inserir(value));
            }
            catch
            {
                throw;
            }
        }

        // PUT: api/Categoria/5
        public IHttpActionResult Put(int id, [FromBody]Categoria value)
        {
            value.Idcategoria = id;

            try
            {
                return Ok(new NCategoria().Editar(value));
            }
            catch
            {
                throw;
            }
        }

        // DELETE: api/Categoria/5
        public IHttpActionResult Delete(int id)
        {
            Categoria cat = new Categoria(id);

            try
            {
                return Ok(new NCategoria().Excluir(cat));
            }
            catch
            {
                throw;
            }
        }

        // Converte um objeto DataTable para List
        private List<Categoria> DataTable2List(DataTable dt)
        {
            Categoria cat;
            List<Categoria> lista = new List<Categoria>();

            foreach(DataRow item in dt.Rows)
            {
                cat = new Categoria()
                {
                    Idcategoria = int.Parse(item["idcategoria"].ToString()),
                    Nome = item["nome"].ToString(),
                    Descricao = item["descricao"].ToString()
                };

                lista.Add(cat);
            }

            return lista;
        }
    }
}
