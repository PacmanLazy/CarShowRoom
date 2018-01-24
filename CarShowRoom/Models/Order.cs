using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CarShowRoom.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("OrderCarKey")]
        public int CarId { get; set; }
        public Car Car { get; set; }

        [Required]
        [ForeignKey("OrderCustomerKey")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
