using Client.Helpers;
using Client.Models;
using System.Threading.Tasks;

namespace Server.Services
{
    public interface INguoiChoiService
    {
        ApiRequestResult<NguoiChoiModel> GetNguoiChoiByDienThoai(string pDienThoai);
        ApiRequestResult<NguoiChoiModel> AddNguoiChoi(NguoiChoiModel item);
    }
}
