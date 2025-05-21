using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Target.Models;

namespace Target.Config
{
    public class DiaValorConfig : IEntityTypeConfiguration<DiaValorModel>
    {
        public void Configure(EntityTypeBuilder<DiaValorModel> builder)
        {
            builder.ToTable("DiaValor");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd().HasColumnType("int");
            builder.Property(e => e.Dia).IsRequired().HasColumnType("int");
            builder.Property(e => e.Valor).IsRequired().HasColumnType("decimal(10,4)");
        } 
    }  
}
