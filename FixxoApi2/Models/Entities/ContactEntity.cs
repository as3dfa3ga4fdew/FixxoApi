﻿using System.ComponentModel.DataAnnotations;

namespace FixxoApi2.Models.Entities
{
    public class ContactEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public string Email { get; set; } = null!;

        [Required]
        public string Message { get; set; } = null!;
    }
}
