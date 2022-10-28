using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities.Concrete
{
    [Table("user")]
    public class User : IEntity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("first_name")]
        public string FirstName { get; set; }
        [Column("last_name")]
        public string LastName { get; set; }
        [Column("email")]
        public string Email { get; set; }
        [Column("iban")]
        public string Iban { get; set; }
        [Column("password_salt")]
        public byte[] PasswordSalt { get; set; }
        [Column("password_hash")]
        public byte[] PasswordHash { get; set; }

        public EnmUserType Type { get; set; }
    }
}
