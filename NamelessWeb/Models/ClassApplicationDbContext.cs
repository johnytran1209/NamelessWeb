using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace NamelessWeb.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Guitar.Guitars> Guitars { get; set; }
        public DbSet<Guitar.GuitarSpecs> GuitarSpecs { get; set; }
        public DbSet<Guitar.Wood.GoBack> GoBack { get; set; }
        public DbSet<Guitar.Wood.GoTop> GoTop { get; set; }
        public DbSet<Guitar.Wood.GoSide> GoSide { get; set; }
        public DbSet<Guitar.Wood.GoNeck> GoNeck { get; set; }
        public DbSet<Guitar.Wood.GoFing> GoFing { get; set; }
        public DbSet<Company.Brand> Brand { get; set; }
        public DbSet<Company.Supplier> Supplier { get; set; }
        public DbSet<Bills.Exports.ExportBill> ExportBill { get; set; }
        public DbSet<Bills.Exports.ExpBillDetail> ExpBillDetail { get; set; }
        public DbSet<Bills.Orders.OrderBill> OrderBill { get; set; }
        public DbSet<Bills.Orders.OrdBillDetail> OrdBillDetail { get; set; }
        public DbSet<Bills.Imports.ImportBill> ImportBill { get; set; }
        public DbSet<Bills.Imports.ImpBillDetail> ImpBillDetail { get; set; }
        public DbSet<WebSystem.GuitarRating> GuitarRating { get; set; }
        public DbSet<WebSystem.Note> Note { get; set; }
        public DbSet<Guitar.GuitarTypes> GuitarType { get; set; }
        public DbSet<Guitar.Warranties> Warranty { get; set; } 
        public DbSet<Reservations> Reservation { get; set; }

        // Bảng đăng ký lich làm việc 
        public DbSet<LichLamViecModel> DangKyLichLamViec { get; set; }
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}