using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace AutoVentas.Models
{
    public class Estado
    {
        [Key]
        public int idEstado { get; set; }
        [Required(ErrorMessage="Campo vacio!"), Display(Name="Estado del Auto")]
        public String nombre { get; set; }

        public virtual List<Automovil> autos { get; set; }
    }
}