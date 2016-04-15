using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace AutoVentas.Models
{
    public class Pedido
    {
        [Key]
        public int idLibro { get; set; }
        [Display(Name="Fecha"), Required(ErrorMessage="La Fecha es obligatoria!")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString="(0:yyyy-MM-dd)",ApplyFormatInEditMode=true)]
        public DateTime fecha { get; set; }
        public virtual List<Automovil> autos { get; set; }
        public virtual Usuario usuario { get; set; }

    }
}