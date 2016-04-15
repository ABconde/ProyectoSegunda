using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace AutoVentas.Models
{
    public class Automovil
    {
        [Key]
        public int idAutomovil { get; set; }
        [Display(Name = "Marca del Auto"), Required(ErrorMessage = "La Marca es obligatoria!")]
        public int idMarca { get; set; }
        public virtual Marca marca { get; set; }
        [Display(Name = "Modelo del Auto"), Required(ErrorMessage = "El Modelo es obligatoria!")]
        public String Modelo { get; set; }
        [Display(Name = "Estado del Auto"), Required(ErrorMessage = "El estado es obligatorio!")]
        public int idEstado { get; set; }
        public virtual Estado estado { get; set; }
        [Display(Name = "Datos Extras *opcional*") ]
        public String Comentario { get; set; }
        [Display(Name = "Usuario")]
        public int idUsuario { get; set; }
        public virtual List<Archivo> archivos { get; set; }
        
    }
}