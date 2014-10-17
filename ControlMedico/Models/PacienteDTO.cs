using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlMedico.Models
{
    public class PacienteDTO
    {
        public int CodigoPaciente { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string ApellidoCasada { get; set; }
        public string NombreCompleto { get; set; }
        public string EstadoCivil { get; set; }
        public string Genero { get; set; }
        public System.DateTime FechaNacimiento { get; set; }
        public string Direccion { get; set; }
        public string TelefonoCasa { get; set; }
        public string TelefonoMovil { get; set; }
        public string TipoSangre { get; set; }
    }
}