using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    [Table("tbUser")]
    public class tbUser
    {
        [Key]
        public int id { get; set; }
        public string? username { get; set; }
        public string? password { get; set; }
        public bool isDeleted { get; set; }
        public DateTime accesstime { get; set; }
    }
}
