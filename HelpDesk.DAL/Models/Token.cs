using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HelpDesk.DAL.Models;

public class Token
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public Guid TokenId { get; set; }

    public DateTime DateExpiration { get; set; }

    public DateTime DateCreated { get; set; }

    public DateTime? DateRevoked { get; set; }

    public User User { get; set; } = null!;

    public Guid UserId { get; set; }
}
