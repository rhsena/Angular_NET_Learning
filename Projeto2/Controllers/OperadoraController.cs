using Projeto2.Models;
using Projeto2.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Projeto2.Controllers
{
    public class OperadoraController : ApiController
    {
        // GET: api/Operadora
        public IEnumerable<Operadora> Get()
        {
            OperadoraDAO operadoras = new OperadoraDAO();
            return operadoras.Get();
        }

        // GET: api/Operadora/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Operadora
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Operadora/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Operadora/5
        public void Delete(int id)
        {
        }
    }
}
