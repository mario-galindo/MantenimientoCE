using Domain.Entidades_POCO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class UnitOfWork:DbContext
    {
        public UnitOfWork()
            : base("MiCadenaConexion")
        {
            Database.SetInitializer<UnitOfWork>(null);
        }

        public IDbSet<Referencia> Referencia { get; set; }
        public IDbSet<Subtema> Subtema { get; set; }
        public IDbSet<Categoria> Categoria { get; set; }
        public IDbSet<Tema> Tema { get; set; }
        public IDbSet<Usuarios> Usuarios { get; set; }
      

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ReferenciaEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new SubtemaEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new TemaEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new CategoriaEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new UsuarioEntityTypeConfiguration());
            base.OnModelCreating(modelBuilder); 
        }
    }
}
