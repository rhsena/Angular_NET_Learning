using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using Projeto2.Models;
using Projeto2.Models.DAO;

namespace Projeto2.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using Projeto2.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<Operadora>("Operadora");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class OperadoraController : ODataController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: odata/Operadora
        [EnableQuery]
        public IQueryable<Operadora> GetOperadora()

        {
            OperadoraDAO operadoras = new OperadoraDAO();
            
            return operadoras.Get();
        }

        // GET: odata/Operadora(5)
        [EnableQuery]
        public SingleResult<Operadora> GetOperadora([FromODataUri] int key)
        {
            return SingleResult.Create(db.Operadoras.Where(operadora => operadora.OperadoraID == key));
        }

        // PUT: odata/Operadora(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<Operadora> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Operadora operadora = db.Operadoras.Find(key);
            if (operadora == null)
            {
                return NotFound();
            }

            patch.Put(operadora);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OperadoraExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(operadora);
        }

        // POST: odata/Operadora
        public IHttpActionResult Post(Operadora operadora)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Operadoras.Add(operadora);
            db.SaveChanges();

            return Created(operadora);
        }

        // PATCH: odata/Operadora(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<Operadora> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Operadora operadora = db.Operadoras.Find(key);
            if (operadora == null)
            {
                return NotFound();
            }

            patch.Patch(operadora);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OperadoraExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(operadora);
        }

        // DELETE: odata/Operadora(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            Operadora operadora = db.Operadoras.Find(key);
            if (operadora == null)
            {
                return NotFound();
            }

            db.Operadoras.Remove(operadora);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OperadoraExists(int key)
        {
            return db.Operadoras.Count(e => e.OperadoraID == key) > 0;
        }
    }
}
