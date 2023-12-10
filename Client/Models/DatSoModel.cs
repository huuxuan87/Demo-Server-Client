using System;

namespace Client.Models
{
    public class DatSoModel
    {
        public int Id { get; set; }
        public int? IDNguoiChoi { get; set; }
        public DateTime? Ngay { get; set; }
        public int? Gio { get; set; }
        public int? GiaTri { get; set; }
        public DateTime? NgayTao { get; set; }
        public DateTime? NgaySua { get; set; }
    }
}