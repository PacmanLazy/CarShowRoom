using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using CarShowRoom.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarShowRoom.ViewModels
{
    public class CarDetails
    {
        public Car Car { get; set; }
        public Order Order { get; set; }
    }
}
