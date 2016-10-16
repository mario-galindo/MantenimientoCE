using Domain.Entidades_POCO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    internal class SubtemaEntityTypeConfiguration: EntityTypeConfiguration<Subtema>
    {
        public SubtemaEntityTypeConfiguration()
        {
            HasKey(t => t.SubtemaId);
            ToTable("Subtemas", "dbo");

            Property(t => t.SubtemaId).HasColumnName("SubtemaId").IsRequired().IsUnicode(false).HasMaxLength(20);
            Property(t => t.Descripcion).HasColumnName("Descripcion").IsRequired().IsUnicode(false).HasMaxLength(50);
            Property(t => t.TemaId).HasColumnName("TemaId").IsRequired().IsUnicode(false).HasMaxLength(20);
            Property(t => t.Orden).HasColumnName("Orden").IsRequired();
            Property(t => t.Estado).HasColumnName("Estado").IsRequired().IsUnicode(false).HasMaxLength(20);

        }
    }
}
