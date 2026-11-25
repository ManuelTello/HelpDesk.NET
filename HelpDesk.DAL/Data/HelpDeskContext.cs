using HelpDesk.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace HelpDesk.DAL.Data;

public class HelpDeskContext : DbContext
{
    public DbSet<Ticket> Tickets { get; set; }

    public DbSet<HistoryEntry> HistorySummary { get; set; }

    public DbSet<OwnershipEntry> OwnershipSummary { get; set; }

    public DbSet<Token> Auditory { get; set; }

    public DbSet<User> Users { get; set; }

    public HelpDeskContext(DbContextOptions<HelpDeskContext> options)
        : base(options) { }
}
