using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CarShowRoom.Models;
using CarShowRoom.ViewModels;
using CarShowRoom.Utility;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarShowRoom.Controllers
{
    public class CarsController : Controller
    {
        const string OrderIdKey = "_OrderId";
        const string OrderDTimeKey = "_OrderDTime";

        CarShowRoomContext _db;

        public CarsController(CarShowRoomContext context)
        {
            _db = context;
        }
        // GET: /<controller>/
        public IActionResult All()
        {
            ViewBag.Title = "All Cars";
            //var cars = _db.Car.Include(s => s.Specs).Include(c => c.CarImages.First()).ToList();
            var cars = _db.Car.Include(s => s.Specs).Select
                (
                    p => new CarViewModel()
                    {
                        Id = p.Id.ToString(),
                        Model = p.Model,
                        Modification = p.Modifcn,
                        StarterPrice = p.StarterPrice.ToString(),
                        EngineVolume = p.Specs.EngineVolume.ToString(),
                        FuelCons = p.Specs.FuelConsumption.ToString(),
                        Status = p.Status.Name,
                        DefaultImage = p.CarImages.Take(1).Select(n => n.ImageName).First()
                    }
                ).ToList();
            return View(cars);
        }

        public IActionResult Details(int id)
        {
            var carViewModel = new CarDetails();
            var car = _db.Car
                .Include(s => s.Specs)
                .Include(p => p.Provider)
                .Include(i => i.CarImages)
                .Include(st => st.Status)
                .Where(u => u.Id == id).First();
            carViewModel.Car = car;
            return View(carViewModel);
        }

        public IActionResult Order(Order order)
        {
            if (ModelState.IsValid)
            {
                var carDb = _db.Car.Find(order.CarId);
                carDb.StatusId = 2;
                _db.Order.Add(order);
                _db.Car.Update(carDb);
                _db.SaveChanges();
                HttpContext.Session.SetInt32(OrderIdKey, order.Id);
                HttpContext.Session.Set<DateTime>(OrderDTimeKey, DateTime.Now);
                return RedirectToAction("OrderResult");
            }
            return View();
        }

        public IActionResult OrderResult()
        {
            int? orderId = 0;
            DateTime orderDt = DateTime.Now;
            Order order = null;
            if (HttpContext.Session.Keys.Contains(OrderIdKey) && HttpContext.Session.Keys.Contains(OrderIdKey))
            {
                orderId = HttpContext.Session.GetInt32(OrderIdKey);
                orderDt = HttpContext.Session.Get<DateTime>(OrderDTimeKey);
                ViewBag.OrderDt = orderDt;

                order = _db.Order
                    .Include(c => c.Customer).ThenInclude(p => p.Person).ThenInclude(c => c.ContactInfo)
                    .Include(o => o.Car)
                    .Where(i => i.Id == orderId).First();
            }
            else
            {
                return NotFound();
            }

            return View(order);
        }
    }
}
