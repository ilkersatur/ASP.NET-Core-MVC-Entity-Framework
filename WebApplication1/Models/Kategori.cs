using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Kategori
    {
        
        //[Key] //Istenilen ozelligi PK yapar...
        public int KategoriID { get; set; }

        [Column(TypeName ="varchar")]
        [StringLength(50)]
        public string  KategoriAdi { get; set; }

        public ICollection<Kitap> Kitaplar { get; set; }  
    }
}
