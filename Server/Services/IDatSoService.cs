using Server.Models;

namespace Server.Services
{
    public interface IDatSoService
    {
        Task<DatSo?> GetDatSoById(int pID);
        Task<List<SP_GetDanhSachDatSoResult>> GetDanhSachDatSo(int? pIDNguoiChoi, DateTime? pNgay, int? pGio);
        Task<DatSo?> AddOrUpdateDatSo(DatSo? item);
        List<string> CheckErrorsDatSo(DatSo? item);
        DateTime GetDateTimeServer();
        Task<List<SP_TaoKetQuaResult>> CreateKetQuaRandomToNow();
    }
}
