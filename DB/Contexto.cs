namespace SSC.DB;

public class SCCContext : DbContext
{
    public DbSet<Curso>? Cursos { get; set; }
    public DbSet<Capitulo>? Capitulos { get; set; }
    public DbSet<Evaluacion>? Evaluaciones { get; set; }

    public SCCContext(DbContextOptions<SCCContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Curso>()
        .HasMany<Capitulo>(c => c.Capitulos).WithOne().HasForeignKey(c => c.CursoID);
        modelBuilder.Entity<Curso>()
        .HasMany<Evaluacion>(e => e.Evaluaciones).WithOne().HasForeignKey(e => e.CursoID);
        modelBuilder.Entity<Capitulo>();
        modelBuilder.Entity<Evaluacion>();
    }
}
