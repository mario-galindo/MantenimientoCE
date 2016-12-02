using Domain.Entidades_POCO;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    internal class TemaEntityTypeConfiguration : EntityTypeConfiguration<Tema>
    {
        public TemaEntityTypeConfiguration()
        {
            HasKey(t => t.TemaId);
            ToTable("Tema", "Training");
            Property(t => t.TemaId).HasColumnName("TemaId").IsRequired().IsUnicode(false).HasMaxLength(20);
            Property(t => t.Nombre).HasColumnName("Nombre").IsRequired().IsUnicode(false).HasMaxLength(50);
            Property(t => t.CategoriaId).HasColumnName("CategoriaId").IsRequired().IsUnicode(false).HasMaxLength(20);
            Property(t => t.Estado).HasColumnName("Estado").IsRequired().IsUnicode(false).HasMaxLength(20);
            Property(t => t.Orden).HasColumnName("Orden").IsRequired();
            HasMany(c => c.Subtemas).WithRequired(t => t.Tema).HasForeignKey(t => t.TemaId);
        }
    }
}
