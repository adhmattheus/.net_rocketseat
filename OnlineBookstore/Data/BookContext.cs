using Microsoft.EntityFrameworkCore;
using OnlineBookstore.Models;

namespace OnlineBookstore.Data;

public class BookContext : DbContext
{
    public BookContext(DbContextOptions<BookContext> options) : base(options) { }

    public DbSet<Book> Books => Set<Book>();

    // Aqui você configura o modelo
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configura a chave primária da entidade Book
        modelBuilder.Entity<Book>()
            .HasKey(b => b.Id);

        // Se quiser outras configurações, coloca aqui.

        // Não use HasDefaultValueSql("NEWID()") no SQLite!
    }
}
