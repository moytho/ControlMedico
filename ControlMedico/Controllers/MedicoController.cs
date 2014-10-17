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
    public class MedicoController : ApiController
    {
        private ControlMedicoEntities db = new ControlMedicoEntities();

        // GET api/Medico
        //public IQueryable<Medico> GetMedicos()
        //{
        //    return db.Medicos;
        //}

        public IEnumerable<Medico> GetMedicos(string q = null, string sort = null, bool desc = false,
                                                int? limit = null, int offset = 0)
        {
            var list = ((IObjectContextAdapter)db).ObjectContext.CreateObjectSet<Medico>();

            IQueryable<Medico> items = string.IsNullOrEmpty(sort) ? list.OrderBy(o => o.CodigoMedico)
                : list.OrderBy(String.Format("it.{0} {1}", sort, desc ? "DESC" : "ASC"));

            if (!string.IsNullOrEmpty(q) && q != "undefined") items = items.Where(t => t.Nombres.Contains(q));

            if (offset > 0) items = items.Skip(offset);
            if (limit.HasValue) items = items.Take(limit.Value);
            return items;
        }

        // GET api/Medico/5
        [ResponseType(typeof(Medico))]
        public IHttpActionResult GetMedico(int id)
        {
            Medico medico = db.Medicos.Find(id);
            if (medico == null)
            {
                return NotFound();
            }

            return Ok(medico);
        }

        // PUT api/Medico/5
        public IHttpActionResult PutMedico(int id, Medico medico)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != medico.CodigoMedico)
            {
                return BadRequest();
            }

            db.Entry(medico).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedicoExists(id))
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

        // POST api/Medico
        [ResponseType(typeof(Medico))]
        public IHttpActionResult PostMedico(Medico medico)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Medicos.Add(medico);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = medico.CodigoMedico }, medico);
        }

        // DELETE api/Medico/5
        [ResponseType(typeof(Medico))]
        public IHttpActionResult DeleteMedico(int id)
        {
            Medico medico = db.Medicos.Find(id);
            if (medico == null)
            {
                return NotFound();
            }

            db.Medicos.Remove(medico);
            db.SaveChanges();

            return Ok(medico);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MedicoExists(int id)
        {
            return db.Medicos.Count(e => e.CodigoMedico == id) > 0;
        }
    }
}