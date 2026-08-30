using Microsoft.EntityFrameworkCore;

namespace ScientificCalculatorApi.Infraestructure.Scaffold;

public partial class CalcdbContext : DbContext
{
    public CalcdbContext()
    {
    }

    public CalcdbContext(DbContextOptions<CalcdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CalculationHistory> CalculationHistories { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Server=localhost;Port=5490;Database=CALCDB;Username=calculator;Password=admin");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CalculationHistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("CalculationHistory_pkey");

            entity.ToTable("CalculationHistory");

            entity.Property(e => e.CreatedAt).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Operation).HasMaxLength(50);
            entity.Property(e => e.Parameters).HasMaxLength(100);
            entity.Property(e => e.Result).HasPrecision(18, 8);

            entity.HasOne(d => d.User).WithMany(p => p.CalculationHistories)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("CalculationHistory_UserId_fkey");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Users_pkey");

            entity.HasIndex(e => e.Email, "Users_Email_key").IsUnique();

            entity.Property(e => e.CreatedAt).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Email).HasMaxLength(300);
            entity.Property(e => e.Name).HasMaxLength(200);
            entity.Property(e => e.PasswordHash).HasMaxLength(60);
            entity.Property(e => e.UpdatedAt).HasColumnType("timestamp without time zone");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
