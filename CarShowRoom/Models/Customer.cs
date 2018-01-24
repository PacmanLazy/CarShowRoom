using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CarShowRoom.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("CustomerPersonKey")]
        public int PersonId { get; set; }
        public Person Person { get; set; }

        public List<Order> Orders { get; set; }
    }
}
