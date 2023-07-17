namespace hotelapp_frontend.Models
{
    public class Error
    {
        public int IDerror { get; set; }
        public string Descripcion { get; set; }

        public DateTime Fecha { get; set; }
        public string Origen { get; set; }
        public int IDUsuario { get; set; }
  
    }
}
