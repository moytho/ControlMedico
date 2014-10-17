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
    public class MedicamentoController : ApiController
    {
        private ControlMedicoEntities db = new ControlMedicoEntities();

        // GET api/Medicamento
        //public IQueryable<Medicamento> GetMedicamentoes()
        //{
        //    return db.Medicamentoes;
        //}

        public IQueryable<MedicamentoDTO> GetMedicamentoes()
        {
            var medicamentos = from b in db.Medicamentoes
                        select new MedicamentoDTO()
                        {
                            CodigoMedicamento = b.CodigoMedicamento,
                            Nombre = b.Nombre,
                            Descripcion = b.Descripcion,
                            Existencia= b.Existencia,
                            TipoMedicamento = b.MedicamentoPresentacion.Nombre,
                            PrecioVenta= b.PrecioVenta
                        };

            return medicamentos;
        }

        //// GET api/Books/5
        //[ResponseType(typeof(BookDetailDTO))]
        //public async Task<IHttpActionResult> GetBook(int id)
        //{
        //    var book = await db.Books.Include(b => b.Author).Select(b =>
        //        new BookDetailDTO()
        //        {
        //            Id = b.Id,
        //            Title = b.Title,
        //            Year = b.Year,
        //            Price = b.Price,
        //            AuthorName = b.Author.Name,
        //            Genre = b.Genre
        //        }).SingleOrDefaultAsync(b => b.Id == id);
        //    if (book == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(book);
        //} 

        //public IEnumerable<Medicamento> GetMedicamentoPresentacions(string q = null, string sort = null, bool desc = false,
        //                                                int? limit = null, int offset = 0)
        //{
        //    var list = ((IObjectContextAdapter)db).ObjectContext.CreateObjectSet<Medicamento>();

        //    IQueryable<Medicamento> items = string.IsNullOrEmpty(sort) ? list.OrderBy(o => o.CodigoMedicamento)
        //        : list.OrderBy(String.Format("it.{0} {1}", sort, desc ? "DESC" : "ASC"));

        //    if (!string.IsNullOrEmpty(q) && q != "undefined") items = items.Where(t => t.Nombre.Contains(q));

        //    if (offset > 0) items = items.Skip(offset);
        //    if (limit.HasValue) items = items.Take(limit.Value);
        //    return items;
        //}

        // GET api/Medicamento/5
        [ResponseType(typeof(Medicamento))]
        public IHttpActionResult GetMedicamento(int id)
        {
            Medicamento medicamento = db.Medicamentoes.Find(id);
            if (medicamento == null)
            {
                return NotFound();
            }

            return Ok(medicamento);
        }

        // PUT api/Medicamento/5
        public IHttpActionResult PutMedicamento(int id, Medicamento medicamento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != medicamento.CodigoMedicamento)
            {
                return BadRequest();
            }

            medicamento.MedicamentoPresentacion = null;
            db.Entry(medicamento).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedicamentoExists(id))
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

        // POST api/Medicamento
        [ResponseType(typeof(Medicamento))]
        public IHttpActionResult PostMedicamento(Medicamento medicamento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Medicamentoes.Add(medicamento);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = medicamento.CodigoMedicamento }, medicamento);
        }

        // DELETE api/Medicamento/5
        [ResponseType(typeof(Medicamento))]
        public IHttpActionResult DeleteMedicamento(int id)
        {
            Medicamento medicamento = db.Medicamentoes.Find(id);
            if (medicamento == null)
            {
                return NotFound();
            }

            db.Medicamentoes.Remove(medicamento);
            db.SaveChanges();

            return Ok(medicamento);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MedicamentoExists(int id)
        {
            return db.Medicamentoes.Count(e => e.CodigoMedicamento == id) > 0;
        }
    }
}