using System;
using System.Collections.Generic;

namespace CVWEB.Models
{
    public partial class TblHakkimda
    {
        public int Id { get; set; }
        public string? AdSoyad { get; set; }
        public string? Adres { get; set; }
        public string? Telefon { get; set; }
        public string? Eposta { get; set; }
        public string? Gorsel { get; set; }
       public string ? Aciklama { get; set; }
    }
}
