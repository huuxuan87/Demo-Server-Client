using System;

namespace Server.Models
{
    public class DatSoResultModel
    {
        public int Id { get; set; }
        public int? IDNguoiChoi { get; set; }
        public DateTime? Ngay { get; set; }
        public int? Gio { get; set; }
        public int? GiaTri { get; set; }
        public DateTime? NgayTao { get; set; }
        public DateTime? NgaySua { get; set; }
        public string HoTen { get; set; }
        public int? KetQua { get; set; }
        public bool? IsTrung { get; set; }
        public string NgayGioDatStr { get; set; }
    }
}
