using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlMedico.Models
{
    public class ConsultaDTO
    {
        public int CodigoConsulta { get; set; }
        public System.DateTime FechaConsulta { get; set; }
        public System.TimeSpan HoraConsulta { get; set; }
        public int CodigoPaciente { get; set; }
        public int CodigoMedico { get; set; }
        public int CodigoUsuario { get; set; }      
        public bool Estado { get; set; }
        public string Observaciones { get; set; }
    }
}