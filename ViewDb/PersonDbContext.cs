using Microsoft.EntityFrameworkCore;

namespace ViewDb
{
    public class PersonDbContext : DbContext
    {
        public PersonDbContext(DbContextOptions<PersonDbContext> options) : base(options)
        {
        }

        public DbSet<Person> Persons { get; set; }

        ////na ez megoldja?
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Person>().ToTable("Persons");
        //}
    }

}
