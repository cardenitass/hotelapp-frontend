namespace hotelapp_frontend.Models
{
    public class TipoHabitacion
    {
        public int IDTipoHabitacion { get; set; }
        public string NombreTipoHabitacion { get; set; }
        public int CantPersonas { get; set; }

        public int CantCamas { get; set; }
        public bool Cocina { get; set; }
        public decimal CostoNoche { get; set; }
    }
}
