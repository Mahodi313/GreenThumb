using EntityFrameworkCore.EncryptColumn.Attribute;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GreenThumb.Models
{
    public class UserModel
    {
        [Key]
        [Column("user_id")]
        public int UserId { get; set; }
        [Column("username")]
        public string Username { get; set; } = null!;
        [Column("password")]
        [EncryptColumn]
        public string password { get; set; } = null!;
        [Column("is_admin")]
        public bool IsAdmin { get; set; }
        public GardenModel? Garden { get; set; }

    }
}
