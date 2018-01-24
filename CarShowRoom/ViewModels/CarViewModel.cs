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
    public class CarViewModel
    {
        public string Id { get; set; }
        public string Model { get; set; }
        public string Modification { get; set; }
        public string StarterPrice { get; set; }
        public string EngineVolume { get; set; }
        public string Status { get; set; }
        public string FuelCons { get; set; }
        public string DefaultImage { get; set; }
    }
}
