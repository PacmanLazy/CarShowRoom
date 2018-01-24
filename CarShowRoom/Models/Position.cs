using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CarShowRoom.Models
{
    public class Position
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(70)]
        public string Name { get; set; }

        public Employee Employee { get; set; }
    }
}
