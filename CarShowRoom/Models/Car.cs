using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace CarShowRoom.Models
{
    public class Car
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(40)]
        public string Model { get; set; }

        [Required]
        [MaxLength(50)]
        public string Modifcn { get; set; }

        [Required]
        [ForeignKey("CarProviderKey")]
        public int ProviderId { get; set; }
        public Provider Provider { get; set; }

        [MaxLength(100)]
        public string Color { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ReceiptDate { get; set; }

        [Column(TypeName = "decimal(15,2)")]
        public decimal StarterPrice { get; set; }

        [Required]
        [ForeignKey("CarStatusKey")]
        public int StatusId { get; set; }
        public Status Status{ get; set; }

        [Required]
        [ForeignKey("CarSpecsKey")]
        public int SpecsId { get; set; }
        public TechSpecs Specs { get; set; }

        public List<CarImage> CarImages { get; set; }

        [NotMapped]
        [DataType(DataType.Upload)]
        public List<IFormFile> Files { get; set; }
    }
}
