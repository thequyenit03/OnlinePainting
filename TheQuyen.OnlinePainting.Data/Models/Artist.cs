using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheQuyen.OnlinePainting.Data.Models
{
    public class Artist
    {
        [Key]
        public int ArtistId { get; set; }

        [Required]
        [MaxLength(100)]        
        public string Name { get; set; }
        [Required, MaxLength(100)]
        public string Bio { get; set; }
        [Required, MaxLength(100)]
        public string Website { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        [Required]
        public string Nationality { get; set; }

        public virtual ICollection<Painting>? Paintings { get; set; }
    }
}
