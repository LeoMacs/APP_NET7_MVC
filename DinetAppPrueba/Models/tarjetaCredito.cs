using System.ComponentModel.DataAnnotations;

namespace DinetAppPrueba.Models
{
    public class TarjetaCredito
    {
        [Key]
        public int idTarjeta { get; set; }
        [Required]
        public string titular { get; set; }
        [Required]
        public string numeroTarjeta { get; set; }
        [Required]
        public string fechaExpiracion { get; set; }
        [Required]
        public string cvv { get; set; }
    }
}
