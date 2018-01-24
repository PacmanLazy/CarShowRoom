using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;


namespace CarShowRoom.ViewModels
{
    public class CarStatus
    {
        public string Id { get; set; }
        public string StatusName { get; set; }
    }
}
