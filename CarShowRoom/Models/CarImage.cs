using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CarShowRoom.Models
{
    public class CarImage
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("CarCarImageKey")]
        public int CarId { get; set; }
        public Car Car { get; set; }

        [Required]
        [MaxLength(200)]
        public string ImageName { get; set; }
    }
}
