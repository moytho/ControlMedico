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
    public class ProveedorController : ApiController
    {
        private ControlMedicoEntities db = new ControlMedicoEntities();

        //// GET api/Proveedor
        //public IQueryable<Proveedor> GetProveedors()
        //{
        //    return db.Proveedors;
        //}

        public IEnumerable<Proveedor> GetMedicos(string q = null, string sort = null, bool desc = false,
                                                int? limit = null, int offset = 0)
        {
            var list = ((IObjectContextAdapter)db).ObjectContext.CreateObjectSet<Proveedor>();

            IQueryable<Proveedor> items = string.IsNullOrEmpty(sort) ? list.OrderBy(o => o.CodigoProveedor)
                : list.OrderBy(String.Format("it.{0} {1}", sort, desc ? "DESC" : "ASC"));

            if (!string.IsNullOrEmpty(q) && q != "undefined") items = items.Where(t => t.Nombre.Contains(q));

            if (offset > 0) items = items.Skip(offset);
            if (limit.HasValue) items = items.Take(limit.Value);
            return items;
        }

        // GET api/Proveedor/5
        [ResponseType(typeof(Proveedor))]
        public IHttpActionResult GetProveedor(int id)
        {
            Proveedor proveedor = db.Proveedors.Find(id);
            if (proveedor == null)
            {
                return NotFound();
            }

            return Ok(proveedor);
        }

        // PUT api/Proveedor/5
        public IHttpActionResult PutProveedor(int id, Proveedor proveedor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != proveedor.CodigoProveedor)
            {
                return BadRequest();
            }

            db.Entry(proveedor).State = EntityState.Modified;
            proveedor.ProveedorMedicamentoes = null;
            proveedor.Ingresoes = null;
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProveedorExists(id))
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

        // POST api/Proveedor
        [ResponseType(typeof(Proveedor))]
        public IHttpActionResult PostProveedor(Proveedor proveedor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            proveedor.ProveedorMedicamentoes = null;
            proveedor.Ingresoes = null;
            db.Proveedors.Add(proveedor);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = proveedor.CodigoProveedor }, proveedor);
        }

        // DELETE api/Proveedor/5
        [ResponseType(typeof(Proveedor))]
        public IHttpActionResult DeleteProveedor(int id)
        {
            Proveedor proveedor = db.Proveedors.Find(id);
            if (proveedor == null)
            {
                return NotFound();
            }

            db.Proveedors.Remove(proveedor);
            db.SaveChanges();

            return Ok(proveedor);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProveedorExists(int id)
        {
            return db.Proveedors.Count(e => e.CodigoProveedor == id) > 0;
        }
    }
}