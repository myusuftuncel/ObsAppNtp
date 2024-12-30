
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciBilgilendirmeApp.Model
{
    internal class Dersler
    {
        [Key]
        public int DersId { get; set; }
        public string? DersAdi { get; set; }
        public string? DersKodu { get; set; }
        public ICollection<OgrenciDersler> derslers { get; set; }
    }
}
