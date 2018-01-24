using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CarShowRoom.Models;
using CarShowRoom.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarShowRoom.Controllers
{
    public class AdminController : Controller
    {
        private CarShowRoomContext _db;
        IHostingEnvironment _appHostEnv;

        public AdminController(CarShowRoomContext context, IHostingEnvironment hostingEnvironment)
        {
            _db = context;
            _appHostEnv = hostingEnvironment;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateStatus()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateStatus(Status status)
        {
            if (ModelState.IsValid)
            {
                _db.Add(status);
                _db.SaveChanges();
            }

            return View();
        }

        public IActionResult CreateProvider()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateProvider(Provider provider)
        {
            if (ModelState.IsValid)
            {
                _db.Add(provider);
                _db.SaveChanges();
            }

            return View();
        }

        public IActionResult CreatePosition()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreatePosition(Position position)
        {
            if (ModelState.IsValid)
            {
                _db.Add(position);
                _db.SaveChanges();
            }

            return View();
        }

        public IActionResult CreatePayMethod()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreatePayMethod(PayMethod payMethod)
        {
            if (ModelState.IsValid)
            {
                _db.Add(payMethod);
                _db.SaveChanges();
            }

            return View();
        }

        public IActionResult CreateEmployee()
        {
            List<EmpoyeePosition> pos = new List<EmpoyeePosition>();

            var posDb = _db.Position;
            foreach (var item in posDb)
            {
                pos.Add(new EmpoyeePosition { Id = item.Id.ToString(), PosName = item.Name });
            }
            ViewData["Positions"] = new SelectList(pos.AsEnumerable(), "Id", "PosName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateEmployee(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _db.Add(employee);
                _db.SaveChanges();
            }

            return View();
        }

        public IActionResult CreateCustomer()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateCustomer(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _db.Add(customer);
                _db.SaveChanges();
            }

            return View();
        }

        public IActionResult CreateCar()
        {
            List<CarStatus> stat = new List<CarStatus>();
            List<CarProvider> prov = new List<CarProvider>();

            var statDb = _db.Status;
            var provDb = _db.Provider;
            foreach (var item in statDb)
            {
                stat.Add(new CarStatus { Id = item.Id.ToString(), StatusName = item.Name });
            }
            foreach (var item in provDb)
            {
                prov.Add(new CarProvider { Id = item.Id.ToString(), ProvName = item.Name });
            }
            ViewBag.Stats = new SelectList(stat.AsEnumerable(), "Id", "StatusName");
            ViewBag.Provs = new SelectList(prov.AsEnumerable(), "Id", "ProvName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCar(Car car)
        {
            if (ModelState.IsValid)
            {
                //int lasId = 0;
                //if (_db.Car != null)
                //    lasId = _db.Car.Select(p => p.Id).Last() + 1;
                
                _db.Add(car);
                _db.SaveChanges();
                if (car.Files != null)
                {
                    await AddFiles(car);
                    if (car.CarImages == null)
                        car.CarImages = new List<CarImage>();
                    foreach (var file in car.Files)
                    {
                        car.CarImages.Add(new CarImage { CarId = car.Id, ImageName = file.FileName });
                    }
                }
                _db.Update(car);
                _db.SaveChanges();
                return RedirectToAction("viewcars");
            }

            return View();
        }

        public IActionResult ViewCars()
        {
            var cars = _db.Car;
            return View(cars.ToList());
        }

        public IActionResult ViewProviders()
        {
            var providers = _db.Provider.Include(p => p.ContactInfo);
            return View(providers.ToList());
        }

        public IActionResult EditCar(int id)
        {
            var car = _db.Car.Include(c => c.Specs).Where(s => s.Id == id).First();
            //List<CarProvider> provs = new List<CarProvider>(
            //        _db.Provider.Select(a => new CarProvider { Id = a.Id.ToString(), ProvName = a.Name}).ToList()
            //    );
            //var provList = new SelectList(provs, "Id", "ProvName", selectedValue:car.ProviderId);
            var provList = new SelectList(_db.Provider.ToList(), "Id", "Name");
            var statList = new SelectList(_db.Status.ToList(), "Id", "Name");
            ViewBag.Provs = provList;
            ViewBag.Stats = statList;
            
            return View(car);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditCar(Car car)
        {
            if (ModelState.IsValid)
            {
                var carDb = _db.Car.AsNoTracking().Include(l => l.CarImages).Where(c => c.Id == car.Id).First();
                int specsId = carDb.SpecsId;
                car.Specs.Id = specsId;
                car.SpecsId = specsId;
                car.CarImages = carDb.CarImages;
                carDb = car;

                if (carDb.Files != null)
                {
                    await AddFiles(carDb);
                    if (carDb.CarImages == null)
                        carDb.CarImages = new List<CarImage>();
                    foreach (var file in carDb.Files)
                    {
                        carDb.CarImages.Add(new CarImage { CarId = carDb.Id, ImageName = file.FileName });
                    }
                }
                //carDb.SpecsId = specsId;
                //carDb.Specs.Id = specsId;

                //carDb.Model = car.Model;
                //carDb.Modifcn = car.Modifcn;
                //carDb.ReceiptDate = car.ReceiptDate;
                //carDb.StarterPrice = car.StarterPrice;
                //carDb.Color = car.Color;

                //carDb.Specs.Length = car.Specs.Length;
                //carDb.Specs.Width = car.Specs.Width;
                //carDb.Specs.Height = car.Specs.Height;
                //carDb.Specs.NumOfSeats = car.Specs.NumOfSeats;
                //carDb.Specs.Weight = car.Specs.Weight;
                //carDb.Specs.MaxSpeed = car.Specs.MaxSpeed;
                //carDb.Specs.EngineType = car.Specs.EngineType;
                //carDb.Specs.EngineVolume = car.Specs.EngineVolume;
                //carDb.Specs.SupplySystem = car.Specs.SupplySystem;
                //carDb.Specs.FuelConsumption = car.Specs.FuelConsumption;

                _db.Update(carDb);
                _db.SaveChanges();
                return RedirectToAction("ViewCars");
            }

            return View();
        }

        public IActionResult File()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> File(List<IFormFile> files)
        {
            
            if (ModelState.IsValid)
            {
                //await AddFiles(files);
            }

            return View();
        }

        // Utility method for CAR FILES
        private Task AddFiles(Car car)
        {
            Task task = Task.Run(async () =>
            {
                var dataDir = "/Data/";
                var filePath = _appHostEnv.WebRootPath + dataDir + car.Id.ToString() + "/";
                
                var files = car.Files;
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }
                foreach (var formFile in files)
                {
                    if (formFile.Length > 0)
                    {
                        using (var stream = new FileStream(filePath + formFile.FileName, FileMode.Create))
                        {
                            await formFile.CopyToAsync(stream);
                        }
                    }
                }
            }
            );
            return task;
            
        }
    }
}
