using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;


namespace CarShowRoom.Models
{
    public class Provider
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [ForeignKey("ProviderContactKey")]
        public int ContactInfoId { get; set; }

        public ContactInfo ContactInfo { get; set; }

        public List<Car> Cars { get; set; }
    }
}
