using System;
using System.Collections.Generic;

namespace CVWEB.Models
{
    public partial class TblMusteri
    {
        public int Id { get; set; }
        public string? AdSoyad { get; set; }
        public string? Telefon { get; set; }
        public string? Eposta { get; set; }
        public DateTime? KayitTarİhİ { get; set; }
    }
}
