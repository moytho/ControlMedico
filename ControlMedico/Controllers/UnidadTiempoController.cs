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
    public class UnidadTiempoController : ApiController
    {
        private ControlMedicoEntities db = new ControlMedicoEntities();

        // GET api/UnidadTiempo
        //public IQueryable<UnidadTiempo> GetUnidadTiempoes()
        //{
        //    return db.UnidadTiempoes;
        //}

        public IEnumerable<UnidadTiempo> GetUnidadTiempoes(string q = null, string sort = null, bool desc = false,
                                                int? limit = null, int offset = 0)
        {
            var list = ((IObjectContextAdapter)db).ObjectContext.CreateObjectSet<UnidadTiempo>();

            IQueryable<UnidadTiempo> items = string.IsNullOrEmpty(sort) ? list.OrderBy(o => o.CodigoUnidadTiempo)
                : list.OrderBy(String.Format("it.{0} {1}", sort, desc ? "DESC" : "ASC"));

            if (!string.IsNullOrEmpty(q) && q != "undefined") items = items.Where(t => t.Descripcion.Contains(q));

            if (offset > 0) items = items.Skip(offset);
            if (limit.HasValue) items = items.Take(limit.Value);
            return items;
        }

        // GET api/UnidadTiempo/5
        [ResponseType(typeof(UnidadTiempo))]
        public IHttpActionResult GetUnidadTiempo(int id)
        {
            UnidadTiempo unidadtiempo = db.UnidadTiempoes.Find(id);
            if (unidadtiempo == null)
            {
                return NotFound();
            }

            return Ok(unidadtiempo);
        }

        // PUT api/UnidadTiempo/5
        public IHttpActionResult PutUnidadTiempo(int id, UnidadTiempo unidadtiempo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != unidadtiempo.CodigoUnidadTiempo)
            {
                return BadRequest();
            }

            db.Entry(unidadtiempo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UnidadTiempoExists(id))
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

        // POST api/UnidadTiempo
        [ResponseType(typeof(UnidadTiempo))]
        public IHttpActionResult PostUnidadTiempo(UnidadTiempo unidadtiempo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.UnidadTiempoes.Add(unidadtiempo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = unidadtiempo.CodigoUnidadTiempo }, unidadtiempo);
        }

        // DELETE api/UnidadTiempo/5
        [ResponseType(typeof(UnidadTiempo))]
        public IHttpActionResult DeleteUnidadTiempo(int id)
        {
            UnidadTiempo unidadtiempo = db.UnidadTiempoes.Find(id);
            if (unidadtiempo == null)
            {
                return NotFound();
            }

            db.UnidadTiempoes.Remove(unidadtiempo);
            db.SaveChanges();

            return Ok(unidadtiempo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UnidadTiempoExists(int id)
        {
            return db.UnidadTiempoes.Count(e => e.CodigoUnidadTiempo == id) > 0;
        }
    }
}