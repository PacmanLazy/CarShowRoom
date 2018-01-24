using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CarShowRoom.ViewModels
{
    public class EmpoyeePosition
    {
        public string Id { get; set; }
        public string PosName { get; set; }
    }
}
