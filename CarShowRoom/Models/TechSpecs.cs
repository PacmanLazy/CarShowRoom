using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CarShowRoom.Models
{
    public class TechSpecs
    {
        [Key]
        public int Id { get; set; }

        [Range(0, Int16.MaxValue, ErrorMessage = "enter valid integer value")]
        public Int16 Length { get; set; }

        [Range(0, Int16.MaxValue, ErrorMessage = "enter valid integer value")]
        public Int16 Width { get; set; }

        [Range(0, Int16.MaxValue, ErrorMessage = "enter valid integer value")]
        public Int16 Height { get; set; }

        [Required]
        public byte NumOfSeats { get; set; }

        [Range(0, Int16.MaxValue, ErrorMessage = "enter valid integer value")]
        public Int16 Weight { get; set; }

        [Required]
        [Range(0, Int16.MaxValue, ErrorMessage = "enter valid integer value")]
        public Int16 MaxSpeed { get; set; }

        [Required]
        [MaxLength(50)]
        public string EngineType { get; set; }

        [Required]
        [Column(TypeName = "decimal(5,2)")]
        public decimal EngineVolume { get; set; }

        [MaxLength(100)]
        public string SupplySystem { get; set; }

        [Column(TypeName = "decimal(8,2)")]
        public decimal FuelConsumption { get; set; }

        public Car Car { get; set; }
    }
}
