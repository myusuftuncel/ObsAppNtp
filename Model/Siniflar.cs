using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciBilgilendirmeApp.Model
{
    internal class Siniflar
    {
        [Key]
        public int SinifId { get; set; }
        public string? SinifAdi { get; set; }
        public int Kontenjan { get; set; }
        public ICollection<Ogrenciler> ogrencilers { get; set; }
    }
}
