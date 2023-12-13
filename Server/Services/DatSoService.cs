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
        private readonly IMapper _mapper;
        private readonly ILogger<DatSoService> _logger;
        private readonly Random _random;

        public DatSoService(VNVCTestContext context, IVNVCTestContextProcedures sp, IMapper mapper, ILogger<DatSoService> logger, Random random)
        {
            _context = context;
            _sp = sp;
            _mapper = mapper;
            _logger = logger;
            _random = random;
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

        public List<string> CheckErrorsDatSo(DatSo? datSo)
        {
            var lstError = new List<string>();
            var now = DateTime.Now;
            if (datSo == null)
            {
                lstError.Add("Dữ liệu null");
            }
            else
            {
                if (datSo.IDNguoiChoi == null)
                {
                    lstError.Add("Giá trị người chơi bị rỗng");
                }
                if (datSo.Ngay == null)
                {
                    lstError.Add("Ngày đặt bị rỗng");
                }
                if (datSo.Gio == null || datSo.Gio < 0 || datSo.Gio > 23)
                {
                    lstError.Add("Giờ đặt rỗng hoặc không hợp lệ");
                }
                if (datSo.Ngay != now.Date || datSo.Gio != now.Hour + 1)
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

        public async Task<List<KetQua>> CreateKetQuaRandomToNow()
        {
            var now = DateTime.Now;
            var lst = new List<KetQua>();
            var lstResultKetQua = await _sp.SP_TaoKetQuaAsync(now, now);
            if (lstResultKetQua.Any())
            {
                foreach (var rsKq in lstResultKetQua)
                {
                    var kq = await _context.KetQua.FirstOrDefaultAsync(m => m.Ngay == rsKq.Ngay && m.Gio == rsKq.Gio);
                    if (kq != null)
                    {
                        kq.KetQua1 = _random.Next(0, 9);
                        var rs = await _context.SaveChangesAsync();
                        if (rs > 0)
                        {
                            lst.Add(kq);
                        }
                    }
                }
            }
            return lst;
        }
    }
}
