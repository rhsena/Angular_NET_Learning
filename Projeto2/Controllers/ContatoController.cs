using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Projeto2.Models;
using Projeto2.Models.DAO;


namespace Projeto2.Controllers
{
    public class ContatoController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Contato
        public IEnumerable<Contato> GetContatos()
        {
            ContatoDAO contatoDao = new ContatoDAO();
            return contatoDao.Get();
        }

        // GET: api/Contato/5
        [ResponseType(typeof(Contato))]
        public IHttpActionResult GetContato(int id)
        {
            ContatoDAO contato = new ContatoDAO();
            Contato contato2 = contato.GetById(id);
            if (contato == null)
            {
                return NotFound();
            }

            return Ok(contato2);
        }

        // PUT: api/Contato/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutContato(long id, Contato contato)
        {
           
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != contato.ContatoID)
            {
                return BadRequest();
            }

            ContatoDAO contatoDAO = new ContatoDAO();
            contatoDAO.Update(contato);
           

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContatoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Contato
        [ResponseType(typeof(Contato))]
        public IHttpActionResult PostContato(Contato contato)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

           
            //contato2.OperadoraDoContato = op2.OperadoraID;

            ContatoDAO contatoDAO = new ContatoDAO();
            contatoDAO.Insert(contato);

            return CreatedAtRoute("DefaultApi", new { id = contato.ContatoID }, contato);
        }

        // DELETE: api/Contato/5
        [ResponseType(typeof(Contato))]
        public IHttpActionResult DeleteContato(long id)
        {
            Contato contato = db.Contatos.Find(id);
            if (contato == null)
            {
                return NotFound();
            }

            db.Contatos.Remove(contato);
            db.SaveChanges();

            return Ok(contato);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ContatoExists(long id)
        {
            return db.Contatos.Count(e => e.ContatoID == id) > 0;
        }
    }
}