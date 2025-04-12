using Microsoft.EntityFrameworkCore;
using EnviromentalAgency.Models;
using EnviromentalAgency.Data;

namespace EnviromentalAgency.Data;
public class NotesDbContext : DbContext
{

    public NotesDbContext()
    { }
    public NotesDbContext(DbContextOptions options) : base(options)
    { }

    public DbSet<Note> Notes { get; set; }

}
