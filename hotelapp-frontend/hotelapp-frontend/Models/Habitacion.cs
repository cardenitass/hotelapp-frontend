namespace hotelapp_frontend.Models
{
    public class Habitacion
    {
        public int IDHabitacion { get; set; }
        public int IDTipoHabitacion { get; set; }
        public int NumeroPiso { get; set; }
        public bool Disponible { get; set; }
        public string Path_Img { get; set; }

    }
}
