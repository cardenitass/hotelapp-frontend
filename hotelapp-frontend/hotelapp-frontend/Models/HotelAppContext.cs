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

        //public DbSet<Tarea> Tarea { get; set; }
    }
}
