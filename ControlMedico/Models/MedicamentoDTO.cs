using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlMedico.Models
{
    public class MedicamentoDTO
    {
        public int CodigoMedicamento { get; set; }
        public String Nombre { get; set; }
        public String Descripcion { get; set; }
        public String Especificaciones { get; set; }
        public String TipoMedicamento { get; set; }
        public int? Existencia { get; set; }
        public Nullable<decimal> PrecioVenta { get; set; }
        public decimal Costo { get; set; }
        public decimal MargenGanancia { get; set; }


    }

}