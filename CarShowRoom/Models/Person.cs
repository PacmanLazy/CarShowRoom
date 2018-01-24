using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CarShowRoom.Models
{
    public class Person
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string LName { get; set; }

        [Required]
        [MaxLength(50)]
        public string FName { get; set; }

        [Required]
        [MaxLength(60)]
        public string MName { get; set; }

        [Required]
        [ForeignKey("PersonContactKey")]
        public int ContactInfoId { get; set; }
        public ContactInfo ContactInfo { get; set; }

        public Customer Customer { get; set; }

        public Employee Employee { get; set; }
    }
}
