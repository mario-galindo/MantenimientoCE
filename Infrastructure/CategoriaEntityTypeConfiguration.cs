using Domain.Entidades_POCO;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Infrastructure
{
    internal class CategoriaEntityTypeConfiguration : EntityTypeConfiguration<Categoria>
    {
        public CategoriaEntityTypeConfiguration()
        {
            HasKey(t => t.CategoriaId);
            ToTable("Categoria", "dbo");
            Property(t => t.CategoriaId).HasColumnName("CategoriaId").IsRequired().IsUnicode(false).HasMaxLength(20);
            Property(t => t.Nombre).HasColumnName("Nombre").IsRequired().IsUnicode(false).HasMaxLength(20);
            Property(t => t.Estado).HasColumnName("Estado").IsRequired().IsUnicode(false).HasMaxLength(20);
            HasMany(c => c.Temas).WithRequired(t => t.Categoria).HasForeignKey(t => t.CategoriaId);
        }
    }
}
