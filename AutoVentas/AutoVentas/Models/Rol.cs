using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace AutoVentas.Models
{
    public class Rol
    {
        [Key]
        public int idRol { get; set; }
        [Display(Name="Nombre"),Required(ErrorMessage="El Nombre es obligatorio!")]
        public String nombre { get; set; }
        [Display(Name = "Descripcion"), Required(ErrorMessage = "La Descripcion es obligatoria!")]
        public String descripcion { get; set; }
        public virtual List<Usuario> usuarios { get; set; }
    }
}