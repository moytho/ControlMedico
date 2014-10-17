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
using ControlMedico.Models;

namespace ControlMedico.Controllers
{
    public class UnidadMedidaController : ApiController
    {
        private ControlMedicoEntities db = new ControlMedicoEntities();

        // GET api/UnidadMedida
        //public IQueryable<UnidadMedida> GetUnidadMedidas()
        //{
        //    return db.UnidadMedidas;
        //}

        public IEnumerable<UnidadMedida> GetUnidadMedidas(string q = null, string sort = null, bool desc = false,
                                                int? limit = null, int offset = 0)
        {
            var list = ((IObjectContextAdapter)db).ObjectContext.CreateObjectSet<UnidadMedida>();

            IQueryable<UnidadMedida> items = string.IsNullOrEmpty(sort) ? list.OrderBy(o => o.CodigoUnidadMedida)
                : list.OrderBy(String.Format("it.{0} {1}", sort, desc ? "DESC" : "ASC"));

            if (!string.IsNullOrEmpty(q) && q != "undefined") items = items.Where(t => t.Descripcion.Contains(q));

            if (offset > 0) items = items.Skip(offset);
            if (limit.HasValue) items = items.Take(limit.Value);
            return items;
        }

        // GET api/UnidadMedida/5
        [ResponseType(typeof(UnidadMedida))]
        public IHttpActionResult GetUnidadMedida(int id)
        {
            UnidadMedida unidadmedida = db.UnidadMedidas.Find(id);
            if (unidadmedida == null)
            {
                return NotFound();
            }

            return Ok(unidadmedida);
        }

        // PUT api/UnidadMedida/5
        public IHttpActionResult PutUnidadMedida(int id, UnidadMedida unidadmedida)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != unidadmedida.CodigoUnidadMedida)
            {
                return BadRequest();
            }

            db.Entry(unidadmedida).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UnidadMedidaExists(id))
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

        // POST api/UnidadMedida
        [ResponseType(typeof(UnidadMedida))]
        public IHttpActionResult PostUnidadMedida(UnidadMedida unidadmedida)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.UnidadMedidas.Add(unidadmedida);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = unidadmedida.CodigoUnidadMedida }, unidadmedida);
        }

        // DELETE api/UnidadMedida/5
        [ResponseType(typeof(UnidadMedida))]
        public IHttpActionResult DeleteUnidadMedida(int id)
        {
            UnidadMedida unidadmedida = db.UnidadMedidas.Find(id);
            if (unidadmedida == null)
            {
                return NotFound();
            }

            db.UnidadMedidas.Remove(unidadmedida);
            db.SaveChanges();

            return Ok(unidadmedida);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UnidadMedidaExists(int id)
        {
            return db.UnidadMedidas.Count(e => e.CodigoUnidadMedida == id) > 0;
        }
    }
}