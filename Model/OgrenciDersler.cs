
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciBilgilendirmeApp.Model
{
    internal class OgrenciDersler
    {
        public int? OgrenciId { get; set; }
        public Ogrenciler Ogrenciler { get; set; }
        public int? DersId { get; set; }
        public Dersler Dersler { get; set; }
    }
}
