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
    public class CarProvider
    {
        public string Id { get; set; }
        public string ProvName { get; set; }
        public List<CarProvider> Providers { get; set; }
        
        //public IEnumerable<CarShowRoom.Models.Provider> GetProviders(CarShowRoomContext db)
        //{

        //    foreach (var item in db.Provider)
        //    {

        //    }
        //}
    }
}
