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
    public class TipoUsuarioController : ApiController
    {
        private ControlMedicoEntities db = new ControlMedicoEntities();

        // GET api/TipoUsuario
        //public IQueryable<TipoUsuario> GetTipoUsuarios()
        //{
        //    return db.TipoUsuarios;
        //}

        public IEnumerable<TipoUsuario> GetMedicos(string q = null, string sort = null, bool desc = false,
                                        int? limit = null, int offset = 0)
        {
            var list = ((IObjectContextAdapter)db).ObjectContext.CreateObjectSet<TipoUsuario>();

            IQueryable<TipoUsuario> items = string.IsNullOrEmpty(sort) ? list.OrderBy(o => o.CodigoTipoUsuario)
                : list.OrderBy(String.Format("it.{0} {1}", sort, desc ? "DESC" : "ASC"));

            if (!string.IsNullOrEmpty(q) && q != "undefined") items = items.Where(t => t.Descripcion.Contains(q));

            if (offset > 0) items = items.Skip(offset);
            if (limit.HasValue) items = items.Take(limit.Value);
            return items;
        }

        // GET api/TipoUsuario/5
        [ResponseType(typeof(TipoUsuario))]
        public IHttpActionResult GetTipoUsuario(int id)
        {
            TipoUsuario tipousuario = db.TipoUsuarios.Find(id);
            if (tipousuario == null)
            {
                return NotFound();
            }

            return Ok(tipousuario);
        }

        // PUT api/TipoUsuario/5
        public IHttpActionResult PutTipoUsuario(int id, TipoUsuario tipousuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tipousuario.CodigoTipoUsuario)
            {
                return BadRequest();
            }

            db.Entry(tipousuario).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoUsuarioExists(id))
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

        // POST api/TipoUsuario
        [ResponseType(typeof(TipoUsuario))]
        public IHttpActionResult PostTipoUsuario(TipoUsuario tipousuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TipoUsuarios.Add(tipousuario);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tipousuario.CodigoTipoUsuario }, tipousuario);
        }

        // DELETE api/TipoUsuario/5
        [ResponseType(typeof(TipoUsuario))]
        public IHttpActionResult DeleteTipoUsuario(int id)
        {
            TipoUsuario tipousuario = db.TipoUsuarios.Find(id);
            if (tipousuario == null)
            {
                return NotFound();
            }

            db.TipoUsuarios.Remove(tipousuario);
            db.SaveChanges();

            return Ok(tipousuario);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TipoUsuarioExists(int id)
        {
            return db.TipoUsuarios.Count(e => e.CodigoTipoUsuario == id) > 0;
        }
    }
}