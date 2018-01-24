using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CarShowRoom.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime Birthday { get; set; }

        [Required]
        public DateTime HireDate { get; set; }

        [Required]
        [ForeignKey("EmployeePersonKey")]
        public int PersonId { get; set; }
        public Person Person { get; set; }

        [Required]
        [ForeignKey("EmployeePositionKey")]
        public int PositionId { get; set; }
        public Position Position { get; set; }
    }
}
