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
    public class PacienteController : ApiController
    {
        private ControlMedicoEntities db = new ControlMedicoEntities();

        // GET api/Paciente
        public IQueryable<PacienteDTO> GetPacientes()
        {
            var pacientes = from b in db.Pacientes
                               select new PacienteDTO()
                               {
                                   CodigoPaciente = b.CodigoPaciente,
                                   PrimerNombre = b.PrimerNombre,
                                   SegundoNombre = b.SegundoNombre,
                                   PrimerApellido=b.PrimerApellido,
                                   SegundoApellido=b.SegundoApellido,
                                   ApellidoCasada=b.ApellidoCasada,
                                   Direccion = b.Direccion,
                                   FechaNacimiento = b.FechaNacimiento
                               };

            return pacientes;
        }

        // GET api/Paciente/5
        [ResponseType(typeof(Paciente))]
        public IHttpActionResult GetPaciente(int id)
        {
            Paciente paciente = db.Pacientes.Find(id);
            if (paciente == null)
            {
                return NotFound();
            }

            return Ok(paciente);
        }

        // PUT api/Paciente/5
        public IHttpActionResult PutPaciente(int id, Paciente paciente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != paciente.CodigoPaciente)
            {
                return BadRequest();
            }
            paciente.TipoSangre = null;
            paciente.Genero = null;
            paciente.EstadoCivil = null;
            db.Entry(paciente).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PacienteExists(id))
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

        // POST api/Paciente
        [ResponseType(typeof(Paciente))]
        public IHttpActionResult PostPaciente(Paciente paciente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Pacientes.Add(paciente);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = paciente.CodigoPaciente }, paciente);
        }

        // DELETE api/Paciente/5
        [ResponseType(typeof(Paciente))]
        public IHttpActionResult DeletePaciente(int id)
        {
            Paciente paciente = db.Pacientes.Find(id);
            if (paciente == null)
            {
                return NotFound();
            }

            db.Pacientes.Remove(paciente);
            db.SaveChanges();

            return Ok(paciente);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PacienteExists(int id)
        {
            return db.Pacientes.Count(e => e.CodigoPaciente == id) > 0;
        }
    }
}