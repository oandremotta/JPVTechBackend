using backend.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backend.Data.Mappings
{
    public class PessoaFisicaMapping : IEntityTypeConfiguration<PessoaFisica>
    {
        public void Configure(EntityTypeBuilder<PessoaFisica> builder)
        {
            builder.ToTable(nameof(PessoaFisica));
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.Property(x => x.NomeCompleto)
                .IsRequired()                
                .HasColumnType("NVARCHAR(160)");

            builder.Property(x => x.DataDeNascimento)
                .IsRequired()
                .HasColumnType("DATE");

            builder.Property(x => x.ValorDaRenda)
                .IsRequired()
                .HasColumnType("DECIMAL(18,2)");

            builder.Property(x => x.Cpf)
                .HasColumnName("CPF")
                .IsRequired()
                .HasColumnType("VARCHAR(11)");
        }
    }
}
