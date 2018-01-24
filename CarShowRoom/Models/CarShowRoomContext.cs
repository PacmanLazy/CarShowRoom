using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace CarShowRoom.Models
{
    public class CarShowRoomContext: DbContext
    {
        //1 Car
        public virtual DbSet<Car> Car { get; set; }
        //2 CarImage
        public virtual DbSet<CarImage> CarImage { get; set; }
        //3 ContactInfo
        public virtual DbSet<ContactInfo> ContactInfo { get; set; }
        //4 Customer
        public virtual DbSet<Customer> Customer { get; set; }
        //5 Employee
        public virtual DbSet<Employee> Employee { get; set; }
        //6 Order
        public virtual DbSet<Order> Order { get; set; }
        //7 PayMethod
        public virtual DbSet<PayMethod> PayMethod { get; set; }
        //8 Person
        public virtual DbSet<Person> Person { get; set; }
        //9 Position
        public virtual DbSet<Position> Position { get; set; }
        //10 Provider
        public virtual DbSet<Provider> Provider { get; set; }
        //11 Status
        public virtual DbSet<Status> Status { get; set; }
        //12 TechSpecs
        public virtual DbSet<TechSpecs> TechSpecs { get; set; }
        
        public CarShowRoomContext(DbContextOptions<CarShowRoomContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Car constraints
            builder.Entity<Car>()
                .HasOne(s => s.Specs)
                .WithOne(c => c.Car);
            builder.Entity<Car>()
                .HasMany(i => i.CarImages);

            //Customer constraints
            builder.Entity<Customer>()
                .HasOne(p => p.Person)
                .WithOne(c => c.Customer);

            //Employee constraints
            builder.Entity<Employee>()
                .HasOne(p => p.Person)
                .WithOne(e => e.Employee);
            builder.Entity<Employee>()
                .HasOne(p => p.Position)
                .WithOne(e => e.Employee);
        }
    }
}
