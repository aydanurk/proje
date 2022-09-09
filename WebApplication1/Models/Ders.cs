using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Ders
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Ders Adı")]
        public string DersName { get; set; }
        [DisplayName("Ders Kodu")]
        public string DersKodu { get; set; }



    }
}
