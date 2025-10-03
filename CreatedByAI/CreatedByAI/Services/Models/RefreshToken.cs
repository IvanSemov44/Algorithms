using System.ComponentModel.DataAnnotations;

namespace AICreatedProjectBackend.Models
{
    public class RefreshToken
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Token { get; set; } = string.Empty;

        public DateTime Expires { get; set; }
        public bool IsExpired => DateTime.UtcNow >= Expires;
        public DateTime? Revoked { get; set; }
        public bool IsActive => !IsExpired && Revoked == null;

        [Required]
        public int UserId { get; set; }
        public virtual User User { get; set; } = null!;
    }
}
