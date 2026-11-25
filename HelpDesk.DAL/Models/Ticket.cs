using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HelpDesk.DAL.Models;

public class Ticket
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    public Guid ActorId { get; set; }

    [DeleteBehavior(DeleteBehavior.NoAction)]
    public User Actor { get; set; } = null!;

    public string Subject { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public ICollection<HistoryEntry> HistorySummary { get; } = [];

    public ICollection<OwnershipEntry> OwnershipSummary { get; } = [];

    public TicketCategory Category { get; set; }

    public TicketPriority Priority { get; set; }

    public DateTime DateCreated { get; set; }

    public DateTime? DateClosed { get; set; }
}