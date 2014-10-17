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
    public class DiaController : ApiController
    {
        private ControlMedicoEntities db = new ControlMedicoEntities();

        // GET api/Dia
        public IQueryable<Dia> GetDias()
        {
            return db.Dias;
        }

        // GET api/Dia/5
        [ResponseType(typeof(Dia))]
        public IHttpActionResult GetDia(int id)
        {
            Dia dia = db.Dias.Find(id);
            if (dia == null)
            {
                return NotFound();
            }

            return Ok(dia);
        }

        // PUT api/Dia/5
        public IHttpActionResult PutDia(int id, Dia dia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dia.CodigoDia)
            {
                return BadRequest();
            }

            db.Entry(dia).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DiaExists(id))
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

        // POST api/Dia
        [ResponseType(typeof(Dia))]
        public IHttpActionResult PostDia(Dia dia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Dias.Add(dia);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = dia.CodigoDia }, dia);
        }

        // DELETE api/Dia/5
        [ResponseType(typeof(Dia))]
        public IHttpActionResult DeleteDia(int id)
        {
            Dia dia = db.Dias.Find(id);
            if (dia == null)
            {
                return NotFound();
            }

            db.Dias.Remove(dia);
            db.SaveChanges();

            return Ok(dia);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DiaExists(int id)
        {
            return db.Dias.Count(e => e.CodigoDia == id) > 0;
        }
    }
}