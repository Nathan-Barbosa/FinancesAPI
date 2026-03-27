namespace FinancesAPI.Infrastructure.Data

{
    using Microsoft.EntityFrameworkCore;
    using FinancesAPI.Domain.Entities;

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Regra de deletar transações ao excluir pessoa do banco de dados
            modelBuilder.Entity<Person>()
                .HasMany(person => person.Transactions)
                .WithOne(transaction => transaction.Person)
                .HasForeignKey(transaction => transaction.PersonId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
