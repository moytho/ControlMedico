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
    public class MedicamentoPresentacionController : ApiController
    {
        private ControlMedicoEntities db = new ControlMedicoEntities();

        // GET api/MedicamentoPresentacion
        //public IQueryable<MedicamentoPresentacion> GetMedicamentoPresentacions()
        //{
        //    return db.MedicamentoPresentacions;
        //}

        public IEnumerable<MedicamentoPresentacion> GetMedicamentoPresentacions(string q = null, string sort = null, bool desc = false,
                                                        int? limit = null, int offset = 0)
        {
            var list = ((IObjectContextAdapter)db).ObjectContext.CreateObjectSet<MedicamentoPresentacion>();

            IQueryable<MedicamentoPresentacion> items = string.IsNullOrEmpty(sort) ? list.OrderBy(o => o.CodigoMedicoPresentacion)
                : list.OrderBy(String.Format("it.{0} {1}", sort, desc ? "DESC" : "ASC"));

            if (!string.IsNullOrEmpty(q) && q != "undefined") items = items.Where(t => t.Nombre.Contains(q));

            if (offset > 0) items = items.Skip(offset);
            if (limit.HasValue) items = items.Take(limit.Value);
            return items;
        }

        // GET api/MedicamentoPresentacion/5
        [ResponseType(typeof(MedicamentoPresentacion))]
        public IHttpActionResult GetMedicamentoPresentacion(int id)
        {
            MedicamentoPresentacion medicamentopresentacion = db.MedicamentoPresentacions.Find(id);
            if (medicamentopresentacion == null)
            {
                return NotFound();
            }

            return Ok(medicamentopresentacion);
        }

        // PUT api/MedicamentoPresentacion/5
        public IHttpActionResult PutMedicamentoPresentacion(int id, MedicamentoPresentacion medicamentopresentacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != medicamentopresentacion.CodigoMedicoPresentacion)
            {
                return BadRequest();
            }

            db.Entry(medicamentopresentacion).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedicamentoPresentacionExists(id))
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

        // POST api/MedicamentoPresentacion
        [ResponseType(typeof(MedicamentoPresentacion))]
        public IHttpActionResult PostMedicamentoPresentacion(MedicamentoPresentacion medicamentopresentacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MedicamentoPresentacions.Add(medicamentopresentacion);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = medicamentopresentacion.CodigoMedicoPresentacion }, medicamentopresentacion);
        }

        // DELETE api/MedicamentoPresentacion/5
        [ResponseType(typeof(MedicamentoPresentacion))]
        public IHttpActionResult DeleteMedicamentoPresentacion(int id)
        {
            MedicamentoPresentacion medicamentopresentacion = db.MedicamentoPresentacions.Find(id);
            if (medicamentopresentacion == null)
            {
                return NotFound();
            }

            db.MedicamentoPresentacions.Remove(medicamentopresentacion);
            db.SaveChanges();

            return Ok(medicamentopresentacion);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MedicamentoPresentacionExists(int id)
        {
            return db.MedicamentoPresentacions.Count(e => e.CodigoMedicoPresentacion == id) > 0;
        }
    }
}