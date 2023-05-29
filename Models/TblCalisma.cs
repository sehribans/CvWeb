using System;
using System.Collections.Generic;

namespace CVWEB.Models
{
    public partial class TblCalisma
    {
        public int? Id { get; set; }
        public string? CalismaAdi { get; set; }
        public string? Aciklama { get; set; }
        public string? Gorsel { get; set; }
        public int? Kategori { get; set; }
    }
}
