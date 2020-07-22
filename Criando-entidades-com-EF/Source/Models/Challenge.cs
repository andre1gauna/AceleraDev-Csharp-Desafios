﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Codenation.Challenge.Models
{
    [Table("challenge")]
    public class Challenge
    {
        [Key, Column("id")]
        public int Id { get; set; }

        [Column("name"), MaxLength(100), Required]
        public string Name { get; set; }

        [Column("slug"), MaxLength(50), Required]
        public string Slug { get; set; }

        [Column("created_at"), Required]
        public DateTime CreatedAt { get; set; }


        public ICollection<Acceleration> Accelerations { get; set; }
        public ICollection<Submission> Submissions { get; set; }
    }
}
