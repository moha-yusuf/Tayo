using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Bulky.Models
{
    public class Collection
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string? Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1, 100, ErrorMessage = "Display Order Must be between 1 - 100")]
        public int DisplayOrder { get; set; }
    }
}
