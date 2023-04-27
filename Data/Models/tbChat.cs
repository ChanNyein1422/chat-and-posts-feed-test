using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    [Table("tbChat")]
    public class tbChat
    {
        [Key]
        public int Id { get; set; }
        public int fromUserId { get; set; }
        public int toUserId { get; set; }
        public string? message { get; set; }
        public DateTime accesstime { get; set; }
    }
}
