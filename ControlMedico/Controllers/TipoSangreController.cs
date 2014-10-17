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
    public class TipoSangreController : ApiController
    {
        private ControlMedicoEntities db = new ControlMedicoEntities();

        // GET api/TipoSangre
        //public IQueryable<TipoSangre> GetTipoSangres()
        //{
        //    return db.TipoSangres;
        //}

        public IEnumerable<TipoSangre> GetTipoSangres(string q = null, string sort = null, bool desc = false,
                                                        int? limit = null, int offset = 0)
        {
            var list = ((IObjectContextAdapter)db).ObjectContext.CreateObjectSet<TipoSangre>();

            IQueryable<TipoSangre> items = string.IsNullOrEmpty(sort) ? list.OrderBy(o => o.CodigoTipoSangre)
                : list.OrderBy(String.Format("it.{0} {1}", sort, desc ? "DESC" : "ASC"));

            if (!string.IsNullOrEmpty(q) && q != "undefined") items = items.Where(t => t.Descripcion.Contains(q));

            if (offset > 0) items = items.Skip(offset);
            if (limit.HasValue) items = items.Take(limit.Value);
            return items;
        }

        // GET api/TipoSangre/5
        [ResponseType(typeof(TipoSangre))]
        public IHttpActionResult GetTipoSangre(int id)
        {
            TipoSangre tiposangre = db.TipoSangres.Find(id);
            if (tiposangre == null)
            {
                return NotFound();
            }

            return Ok(tiposangre);
        }

        // PUT api/TipoSangre/5
        public IHttpActionResult PutTipoSangre(int id, TipoSangre tiposangre)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tiposangre.CodigoTipoSangre)
            {
                return BadRequest();
            }

            db.Entry(tiposangre).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoSangreExists(id))
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

        // POST api/TipoSangre
        [ResponseType(typeof(TipoSangre))]
        public IHttpActionResult PostTipoSangre(TipoSangre tiposangre)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TipoSangres.Add(tiposangre);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tiposangre.CodigoTipoSangre }, tiposangre);
        }

        // DELETE api/TipoSangre/5
        [ResponseType(typeof(TipoSangre))]
        public IHttpActionResult DeleteTipoSangre(int id)
        {
            TipoSangre tiposangre = db.TipoSangres.Find(id);
            if (tiposangre == null)
            {
                return NotFound();
            }

            db.TipoSangres.Remove(tiposangre);
            db.SaveChanges();

            return Ok(tiposangre);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TipoSangreExists(int id)
        {
            return db.TipoSangres.Count(e => e.CodigoTipoSangre == id) > 0;
        }
    }
}