using Microsoft.EntityFrameworkCore;

namespace CVWEB.Models.Views
{
    [Keyless]
    public class ViewCalismalar
    {
        public string? KATEGORI_AD { get; set; }

        public int CALISMA_ID { get; set; }

        public string? CALISMA_ADI { get; set; }

        public string? ACIKLAMA { get; set; }

        public string? GORSEL { get; set; }

        public int? KATEGORI { get; set; }

    }
}
