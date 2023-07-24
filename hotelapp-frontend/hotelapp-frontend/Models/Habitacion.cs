using System.ComponentModel.DataAnnotations;


namespace hotelapp_frontend.Models
{
    public class Habitacion
    {
        [Key]
        public int IDHabitacion { get; set; }
        public int IDTipoHabitacion { get; set; }
        public int NumeroPiso { get; set; }
        public bool Disponible { get; set; }


    }
}
