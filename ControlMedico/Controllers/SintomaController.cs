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
    public class SintomaController : ApiController
    {
        private ControlMedicoEntities db = new ControlMedicoEntities();

        // GET api/Sintoma
        //public IQueryable<Sintoma> GetSintomas()
        //{
        //    return db.Sintomas;
        //}

        public IEnumerable<Sintoma> GetSintomas(string q = null, string sort = null, bool desc = false,
                                                        int? limit = null, int offset = 0)
        {
            var list = ((IObjectContextAdapter)db).ObjectContext.CreateObjectSet<Sintoma>();

            IQueryable<Sintoma> items = string.IsNullOrEmpty(sort) ? list.OrderBy(o => o.CodigoSintoma)
                : list.OrderBy(String.Format("it.{0} {1}", sort, desc ? "DESC" : "ASC"));

            if (!string.IsNullOrEmpty(q) && q != "undefined") items = items.Where(t => t.Nombre.Contains(q));

            if (offset > 0) items = items.Skip(offset);
            if (limit.HasValue) items = items.Take(limit.Value);
            return items;
        }

        // GET api/Sintoma/5
        [ResponseType(typeof(Sintoma))]
        public IHttpActionResult GetSintoma(int id)
        {
            Sintoma sintoma = db.Sintomas.Find(id);
            if (sintoma == null)
            {
                return NotFound();
            }

            return Ok(sintoma);
        }

        // PUT api/Sintoma/5
        public IHttpActionResult PutSintoma(int id, Sintoma sintoma)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sintoma.CodigoSintoma)
            {
                return BadRequest();
            }

            db.Entry(sintoma).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SintomaExists(id))
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

        // POST api/Sintoma
        [ResponseType(typeof(Sintoma))]
        public IHttpActionResult PostSintoma(Sintoma sintoma)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Sintomas.Add(sintoma);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = sintoma.CodigoSintoma }, sintoma);
        }

        // DELETE api/Sintoma/5
        [ResponseType(typeof(Sintoma))]
        public IHttpActionResult DeleteSintoma(int id)
        {
            Sintoma sintoma = db.Sintomas.Find(id);
            if (sintoma == null)
            {
                return NotFound();
            }

            db.Sintomas.Remove(sintoma);
            db.SaveChanges();

            return Ok(sintoma);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SintomaExists(int id)
        {
            return db.Sintomas.Count(e => e.CodigoSintoma == id) > 0;
        }
    }
}