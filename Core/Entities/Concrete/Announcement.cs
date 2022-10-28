using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities.Concrete
{
    [Table("announcement")]
    public class Announcement : IEntity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("title")]
        public string Title { get; set; }
        [Column("text")]
        public string Text { get; set; }
        [Column("user_id")]
        public int UserId { get; set; }
        [Column("city_id")]
        public int CityId { get; set; }
    }
}