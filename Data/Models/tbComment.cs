using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    [Table("tbComment")]
    public class tbComment
    {
        [Key]
        public int Id { get; set; }
        public int PostId { get; set; }
        public int CommenterId { get; set; }
        public string? Comment { get; set; }
        public DateTime? AccessTime { get; set; }
        public bool? IsDeleted { get; set; }
        [NotMapped]
        public string? ReturnMessage { get; set; }
    }
}
