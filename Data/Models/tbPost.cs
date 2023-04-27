using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    [Table("tbPost")]
    public class tbPost
    {
        [Key]
        public int Id { get; set; }
        public int? userId { get; set; }
        public string? postContent { get; set; }
        public string? postPhoto { get; set; }
        [NotMapped]
        public string? postPhotoUrl
        {
            get
            {
                if (this.postPhoto != null)
                {
                    return string.Format("../ImageUpload/{0}", postPhoto);
                }
                else
                {
                    return "../ImageUpload/SignalR.jpg";
                }
            }
        }
        public bool isDeleted { get; set; }
        public DateTime accessTime { get; set; }


    }
}
