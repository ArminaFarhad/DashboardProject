using DashboardProject.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace DashboardProject.Repository.Context
{
    public class DashboardDbContext : DbContext
    {
        public DashboardDbContext(DbContextOptions<DashboardDbContext> options) : base(options)
        {
            
        }

        public DbSet<Dashboard> Dashboard { get; set; }
        public DbSet<Widget> Widget { get; set; }
        public DbSet<DashboardWidget> DashboardWidgets { get; set; }
    }
}
