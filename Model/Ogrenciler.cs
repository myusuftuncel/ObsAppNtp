
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciBilgilendirmeApp.Model
{
    internal class Ogrenciler
    {
        [Key]
        public int OgrenciId { get; set; }
        public string? OgrenciAd { get; set; }
        public string? OgrenciSoyad { get; set; }
        public string? OgrenciNumara { get; set; }
        public int SinifId { get; set; }
        public Siniflar Siniflar { get; set; }

        public ICollection<OgrenciDersler> ogrenciDerslers { get; set; }
    }
}
