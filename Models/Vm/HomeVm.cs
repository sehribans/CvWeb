using CVWEB.Models.Views;

namespace CVWEB.Models.Vm
{
    public class HomeVm
    {

        public List<TblBlog> blog { get; set; }
        public TblHakkimda hakkimda { get; set; }
        public List<TblCalisma> calisma { get; set; }
        public List<TblHizmet> hizmet { get; set; }
        public List<TblMusteri> müsteri { get; set; }
        public List<TblKategori> kategori { get; set; }
        public List<ViewCalismalar> ViewCalismalar { get; set; }


    }
}
