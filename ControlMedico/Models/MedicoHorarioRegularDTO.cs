using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlMedico.Models
{
    public class MedicoHorarioRegularDTO
    {
        public int CodigoMedicoHorarioRegular { get; set; }
        public int Medico { get; set; }
        public int Dia { get; set; }
        public System.TimeSpan HoraInicio { get; set; }
        public System.TimeSpan HorarioFin { get; set; }
    }
}