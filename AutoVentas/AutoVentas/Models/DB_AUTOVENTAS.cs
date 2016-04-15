using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace AutoVentas.Models
{
    public partial class DB_AUTOVENTAS:DbContext
    {
        public DB_AUTOVENTAS():base("name=DB_Autoventas"){}
        public virtual DbSet<Rol> rol { get; set; }
        public virtual DbSet<Archivo> archivo { get; set; }
        public virtual DbSet<Usuario> usuario { get; set; }
        public virtual DbSet<Automovil> autoMovil { get; set; }
        public virtual DbSet<Pedido> pedido { get; set; }
        public virtual DbSet<Marca> marca { get; set; }
        public virtual DbSet<Estado> estado { get; set; }
    }
}