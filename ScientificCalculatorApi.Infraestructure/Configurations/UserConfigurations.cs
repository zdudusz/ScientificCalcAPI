using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScientificCalcAPI.Core.Entities;

namespace ScientificCalculatorApi.Infraestructure.Configurations
{
    public class UserConfigurations : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> entity)
        {
            entity.HasKey(e => e.Id).HasName("Users_pkey"); //Configura a chave primária da tabela Users

            entity.HasIndex(e => e.Email, "Users_Email_key").IsUnique(); //Configura um índice único na coluna Email da tabela Users

            // Configura as propriedades da entidade User
            entity.Property(e => e.CreatedAt).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Email).HasMaxLength(300);
            entity.Property(e => e.Name).HasMaxLength(200);
            entity.Property(e => e.PasswordHash).HasMaxLength(60);
            entity.Property(e => e.UpdatedAt).HasColumnType("timestamp without time zone");
        }
    }
}
