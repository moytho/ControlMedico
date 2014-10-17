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
    public class GeneroController : ApiController
    {
        private ControlMedicoEntities db = new ControlMedicoEntities();

        // GET api/Genero
        public IQueryable<Genero> GetGeneroes()
        {
            return db.Generoes;
        }

        // GET api/Genero/5
        [ResponseType(typeof(Genero))]
        public IHttpActionResult GetGenero(int id)
        {
            Genero genero = db.Generoes.Find(id);
            if (genero == null)
            {
                return NotFound();
            }

            return Ok(genero);
        }

        // PUT api/Genero/5
        public IHttpActionResult PutGenero(int id, Genero genero)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != genero.CodigoGenero)
            {
                return BadRequest();
            }

            db.Entry(genero).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GeneroExists(id))
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

        // POST api/Genero
        [ResponseType(typeof(Genero))]
        public IHttpActionResult PostGenero(Genero genero)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Generoes.Add(genero);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = genero.CodigoGenero }, genero);
        }

        // DELETE api/Genero/5
        [ResponseType(typeof(Genero))]
        public IHttpActionResult DeleteGenero(int id)
        {
            Genero genero = db.Generoes.Find(id);
            if (genero == null)
            {
                return NotFound();
            }

            db.Generoes.Remove(genero);
            db.SaveChanges();

            return Ok(genero);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GeneroExists(int id)
        {
            return db.Generoes.Count(e => e.CodigoGenero == id) > 0;
        }
    }
}