using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RentCar.Models;

namespace RentCar.Data
{
    public class RentCarContext : DbContext
    {
        public RentCarContext (DbContextOptions<RentCarContext> options)
            : base(options)
        {
        }

        public DbSet<RentCar.Models.TipoCombustible>? TipoCombustible { get; set; }

        public DbSet<RentCar.Models.InspeccionCarro>? InspeccionCarro { get; set; }

        public DbSet<RentCar.Models.RentaCarro>? RentaCarro { get; set; }

        public DbSet<RentCar.Models.Cliente>? Cliente { get; set; }

        public DbSet<RentCar.Models.Empleados>? Empleados { get; set; }

        public DbSet<RentCar.Models.Vehiculo>? Vehiculo { get; set; }

        public DbSet<RentCar.Models.MarcaVehiculo>? MarcaVehiculo { get; set; }

        public DbSet<RentCar.Models.TipoVehiculo>? TipoVehiculo { get; set; }
    }
}
