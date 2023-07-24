using Microsoft.EntityFrameworkCore;

namespace hotelapp_frontend.Models
{
    public class HotelAppContext : DbContext
    {
        public HotelAppContext(DbContextOptions<HotelAppContext> opciones)
           : base(opciones)
        {


        }

        // Tablas 
        public DbSet<Habitacion> Habitacion { get; set; }
        public DbSet<TipoHabitacion> TipoHabitacion { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }

    }
}
