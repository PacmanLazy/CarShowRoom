using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CarShowRoom.Models
{
    public class ContactInfo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(80)]
        public string Country { get; set; }

        [Required]
        [MaxLength(80)]
        public string City { get; set; }

        [MaxLength(100)]
        public string Address { get; set; }

        [Required]
        [MaxLength(20)]
        public string Phone { get; set; }

        [Required]
        [MaxLength(50)]
        public string Email { get; set; }

        public Person Person { get; set; }

        public Provider Provider { get; set; }
    }
}
