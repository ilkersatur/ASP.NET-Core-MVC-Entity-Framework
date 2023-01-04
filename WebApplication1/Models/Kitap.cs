using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Kitap
    {
        //ID, KitapID, 
        public int KitapID { get; set; }
        [StringLength(100), Column(TypeName = "varchar")]
        [Display(Name = "Kitap Adı")]
        [Required(ErrorMessage = "Boş geçemezsiniz...")]
        public string KitapAdi { get; set; }

        [Display(Name = "Kategori")]
        public int KategoriID { get; set; }
        [Column(TypeName = "money")]
        [Required(ErrorMessage = "Boş geçemezsiniz...")]
        [Range(10,100,ErrorMessage ="Fiyat aralığı 10-100 arasında olmalı...")]
        public decimal Fiyat { get; set; }

        public string? KapakResmi { get; set; }
        
        [NotMapped]
        public IFormFile? Dosya { get; set; }

        public Kategori? Kategori { get; set; }
    }
}
