using System;
using System.Collections.Generic;

namespace CVWEB.Models
{
    public partial class TblBlog
    {
        public int Id { get; set; }
        public string? Ad { get; set; }
        public string? Aciklama { get; set; }
        public DateTime? OlusturmaTarihi { get; set; }
        public string? Gorsel { get; set; }
        public string? Yazar { get; set; }
    }
}
