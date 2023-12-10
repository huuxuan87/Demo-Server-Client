using Server.Models;

namespace Server.Services
{
    public interface INguoiChoiService
    {
        Task<NguoiChoi?> GetNguoiChoiById(int pId);
        Task<NguoiChoi?> GetNguoiChoiByDienThoai(string pDienThoai);
        Task<NguoiChoi?> AddUpdateNguoiChoi(NguoiChoi? item);
        Task<bool> IsExist(string? pDienThoai);
    }
}
