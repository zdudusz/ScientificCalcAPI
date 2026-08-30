using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScientificCalcAPI.Core.Entities;

namespace ScientificCalculatorApi.Infraestructure.Configurations
{
    public class CalculationHistoryConfiguration : IEntityTypeConfiguration<CalculationHistory>
    {
        public void Configure(EntityTypeBuilder<CalculationHistory> entity)
        {
            entity.HasKey(e => e.Id).HasName("CalculationHistory_pkey");

            entity.ToTable("CalculationHistory");

            entity.Property(e => e.CreatedAt).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Operation).HasMaxLength(50);
            entity.Property(e => e.Parameters).HasMaxLength(100);
            entity.Property(e => e.Result).HasPrecision(18, 8);
        }
    }
}
