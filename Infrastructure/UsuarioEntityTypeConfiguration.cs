using Domain.Entidades_POCO;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    internal class UsuarioEntityTypeConfiguration : EntityTypeConfiguration<Usuarios>
    {
        public UsuarioEntityTypeConfiguration()
        {
            HasKey(t => t.UsuarioId);
            ToTable("Usuarios", "Training");
            Property(t => t.UsuarioId).HasColumnName("UsuarioId").IsRequired().IsUnicode(false).HasMaxLength(50);
            Property(t => t.Nombre).HasColumnName("Nombre").IsRequired().IsUnicode(false).HasMaxLength(50);
            Property(t => t.Area).HasColumnName("Area").IsRequired().IsUnicode(false).HasMaxLength(50);
        }
    }
}
