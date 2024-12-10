using Microsoft.EntityFrameworkCore;
using SGE.HexagonalArchiPattern.Core.Entities;


namespace SGE.HexagonalArchiPattern.Persistence.Database
{
    public class SgeHexagonaleDbContext : DbContext
    {
        //1- Propriétes Navigation
        public DbSet<Author> Authors { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Student> Students { get; set; }

        //2- Constructeur
        public SgeHexagonaleDbContext(DbContextOptions options) 
            : base(options) {}

        //3-Ovveride Methods
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("sge");

            #region  Configurer Article
            modelBuilder.Entity<Article>()
                .HasOne(a =>a.Author)
                .WithMany()
                .HasForeignKey(a => a.AuthorId)
                .OnDelete(DeleteBehavior.NoAction);
            #endregion

           
        }

    }
}
