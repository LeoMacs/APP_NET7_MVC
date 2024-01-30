using System.ComponentModel.DataAnnotations;

namespace DinetAppPrueba.Models
{
    public class tarjetaCredito
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string titulo { get; set; }
        [Required]
        public string numeroTarjeta { get; set; }
        [Required]
        public string fechaExpiracion { get; set; }
        [Required]
        public string cvv { get; set; }
    }
}
