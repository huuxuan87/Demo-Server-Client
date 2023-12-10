using Client.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Models
{
    public class NguoiChoiModel
    {
        public int Id { get; set; }
        public string DienThoai { get; set; }
        public string HoDem { get; set; }
        public string Ten { get; set; }
        public string HoTen => string.Concat(HoDem.TrimEx(), " ", Ten.TrimEx()).TrimEx();
        public DateTime? NgaySinh { get; set; } = DateTime.Now;
    }
}
