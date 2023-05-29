using System;
using System.Collections.Generic;

namespace CVWEB.Models
{
    public partial class TblHizmet
    {
        public int Id { get; set; }
        public string? HizmetAdi { get; set; }
        public string? Aciklama { get; set; }
        public string? Gorsel { get; set; }
    }
}
