using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheQuyen.OnlinePainting.Data.Models
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }

        [Required]
        public string Content { get; set; }
        [DataType(DataType.Date)]
        public DateTime CommentDate { get; set; }
        [Required]
        [Range(1,5)]
        public int Rating { get; set; }
        [Required]
        public int LikeCount { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public virtual Customer? Customer { get; set; }

        [ForeignKey("Painting")]
        public int PaintingId { get; set; }
        public virtual Painting? Painting { get; set; }

        [ForeignKey("ParentComment")]
        public int? ParentCommentId { get; set; }
        public virtual Comment? ParentComment { get; set; }
        public virtual ICollection<Comment>? Replies { get; set; }
    }
}
