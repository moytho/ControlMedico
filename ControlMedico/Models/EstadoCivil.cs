//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ControlMedico.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class EstadoCivil
    {
        public EstadoCivil()
        {
            this.Pacientes = new HashSet<Paciente>();
        }
    
        public int CodigoEstadoCivil { get; set; }
        public string Descripcion { get; set; }
    
        public virtual ICollection<Paciente> Pacientes { get; set; }
    }
}
