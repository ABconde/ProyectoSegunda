using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace AutoVentas.Models
{
    public class Usuario
    {
        [Key]
        public int idUsuario { get; set; }
        [Display(Name="Nombre"),Required(ErrorMessage="El Nombre es obligatorio!")]
        public String nombre { get; set; }
        [Display(Name = "Correo"), Required(ErrorMessage = "El Correo es obligatorio!"), DataType(DataType.EmailAddress)]
        public String correo { get; set; }
        [Display(Name = "Nick"), Required(ErrorMessage = "El Nick es obligatorio!")]
        public String nick { get; set; }
        [Display(Name = "Contraseña"), Required(ErrorMessage = "La Contraseña es obligatoria!"), DataType(DataType.Password)]
        public String contrasenia { get; set; }
        [Display(Name = "Confirmar Contraseña"), Compare("contrasenia", ErrorMessage = "Las Contraseñas no coinciden"), Required(ErrorMessage = "Este Campo es Obligatorio es obligatorio!"), DataType(DataType.Password)]
        public String confirmarC { get; set; }

        public int idRol { get; set; } 
        public virtual Rol rol { get; set; }

        public virtual List<Pedido> pedido { get; set; }
    }
}