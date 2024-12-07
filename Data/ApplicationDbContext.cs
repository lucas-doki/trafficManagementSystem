using Microsoft.EntityFrameworkCore;
using TrafficManagementSystem.Models;

namespace TrafficManagementSystem.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Semaforo> Semaforos { get; set; }
        public DbSet<Trafego> Trafegos { get; set; }
        public DbSet<Acidente> Acidentes { get; set; }
