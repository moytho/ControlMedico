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
    
    public partial class MedicoHorarioRegular
    {
        public int CodigoMedicoHorarioRegular { get; set; }
        public int CodigoMedico { get; set; }
        public int CodigoDia { get; set; }
        public System.TimeSpan HoraInicio { get; set; }
        public System.TimeSpan HorarioFin { get; set; }
    
        public virtual Dia Dia { get; set; }
        public virtual Medico Medico { get; set; }
    }
}