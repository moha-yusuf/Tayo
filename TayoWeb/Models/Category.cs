﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace TayoWeb.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1, 100, ErrorMessage ="Display Order Must be between 1 - 100")]
        public int DisplayOrder { get; set; }
    }
}
