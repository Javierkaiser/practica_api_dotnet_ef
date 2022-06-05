namespace SSC.DB;

public class SCCContext : DbContext
{
    public DbSet<Curso>? Cursos { get; set; }
    public DbSet<Capitulo>? Capitulos { get; set; }
    public DbSet<Evaluacion>? Evaluaciones { get; set; }

    public SCCContext(DbContextOptions<SCCContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Curso>().ToTable("Curso"):
        modelBuilder.Entity<Capitulo>()
        .HasOne<Curso>()
        .WithMany()
        .HasForeignKey(p => p.CursoId)
        .ToTable("Capitulo");
        modelBuilder.Entity<Evaluacion>().ToTable("Evaluacion");
    }
}
