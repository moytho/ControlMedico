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
    public class EstadoCivilController : ApiController
    {
        private ControlMedicoEntities db = new ControlMedicoEntities();

        // GET api/EstadoCivil
        public IQueryable<EstadoCivil> GetEstadoCivils()
        {
            return db.EstadoCivils;
        }

        // GET api/EstadoCivil/5
        [ResponseType(typeof(EstadoCivil))]
        public IHttpActionResult GetEstadoCivil(int id)
        {
            EstadoCivil estadocivil = db.EstadoCivils.Find(id);
            if (estadocivil == null)
            {
                return NotFound();
            }

            return Ok(estadocivil);
        }

        // PUT api/EstadoCivil/5
        public IHttpActionResult PutEstadoCivil(int id, EstadoCivil estadocivil)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != estadocivil.CodigoEstadoCivil)
            {
                return BadRequest();
            }

            db.Entry(estadocivil).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstadoCivilExists(id))
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

        // POST api/EstadoCivil
        [ResponseType(typeof(EstadoCivil))]
        public IHttpActionResult PostEstadoCivil(EstadoCivil estadocivil)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EstadoCivils.Add(estadocivil);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = estadocivil.CodigoEstadoCivil }, estadocivil);
        }

        // DELETE api/EstadoCivil/5
        [ResponseType(typeof(EstadoCivil))]
        public IHttpActionResult DeleteEstadoCivil(int id)
        {
            EstadoCivil estadocivil = db.EstadoCivils.Find(id);
            if (estadocivil == null)
            {
                return NotFound();
            }

            db.EstadoCivils.Remove(estadocivil);
            db.SaveChanges();

            return Ok(estadocivil);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EstadoCivilExists(int id)
        {
            return db.EstadoCivils.Count(e => e.CodigoEstadoCivil == id) > 0;
        }
    }
}