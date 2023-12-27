using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Server.Extensions;
using Server.Models;

namespace Server.Services
{
    public class DatSoService : IDatSoService
    {
        private readonly VNVCTestContext _context;
        private readonly IVNVCTestContextProcedures _sp;
        private readonly ILogger<DatSoService> _logger;

        public DatSoService(VNVCTestContext context, IVNVCTestContextProcedures sp, ILogger<DatSoService> logger)
        {
            _context = context;
            _sp = sp;
            _logger = logger;
        }

        public async Task<DatSo?> AddOrUpdateDatSo(DatSo? item)
        {
            if (item == null)
            {
                return null;
            }
            if (item.Id == 0)
            {
                var rs = _context.DatSo.Add(item);
                await _context.SaveChangesAsync();
                return rs.Entity;
            }
            else
            {
                var itemDb = await GetDatSoById(item.Id);
                if (itemDb == null)
                {
                    return null;
                }
                else
                {
                    item.NgayTao = itemDb.NgayTao;
                    _context.Entry(itemDb).State = EntityState.Detached;
                    _context.Entry(item).State = EntityState.Modified;
                }

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException e)
                {
                    _logger.LogError(e.StackTrace);
                    return null;
                }

                return item;
            }
        }

        public List<string> CheckErrorsDatSo(DatSo? item)
        {
            var lstError = new List<string>();
            var now = DateTime.Now;
            if (item == null)
            {
                lstError.Add("Dữ liệu null");
            }
            else
            {
                if (item.IDNguoiChoi == null)
                {
                    lstError.Add("Giá trị người chơi bị rỗng");
                }
                if (item.Ngay == null)
                {
                    lstError.Add("Ngày đặt bị rỗng");
                }
                if (item.Gio == null || item.Gio < 0 || item.Gio > 23)
                {
                    lstError.Add("Giờ đặt rỗng hoặc không hợp lệ");
                }
                if (item.Ngay != now.Date || item.Gio != now.Hour + 1)
                {
                    lstError.Add("Thời gian không hợp lệ");
                }
            }
            return lstError;
        }

        public async Task<DatSo?> GetDatSoById(int pID)
        {
            var rs = await _context.DatSo.FirstOrDefaultAsync(m => m.Id == pID);
            return rs;
        }

        public async Task<List<SP_GetDanhSachDatSoResult>> GetDanhSachDatSo(int? pIDNguoiChoi, DateTime? pNgay, int? pGio)
        {
            await CreateKetQuaRandomToNow();
            var rs = await _sp.SP_GetDanhSachDatSoAsync(pIDNguoiChoi, pNgay, pGio);
            return rs;
        }

        public DateTime GetDateTimeServer()
        {
            var rs = DateTime.Now;
            return rs;
        }

        public async Task<List<SP_TaoKetQuaResult>> CreateKetQuaRandomToNow()
        {
            var now = DateTime.Now;
            var lstResultKetQua = await _sp.SP_TaoKetQuaAsync(now, now);
            return lstResultKetQua;
        }
    }
}
