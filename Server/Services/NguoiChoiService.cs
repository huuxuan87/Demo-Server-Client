using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Server.Models;

namespace Server.Services
{
    public class NguoiChoiService : INguoiChoiService
    {
        private readonly VNVCTestContext _context;
        private readonly ILogger<NguoiChoiService> _logger;

        public NguoiChoiService(VNVCTestContext context, ILogger<NguoiChoiService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<NguoiChoi?> AddUpdateNguoiChoi(NguoiChoi? item)
        {
            if (item == null)
            {
                return null;
            }
            if (item.Id == 0)
            {
                var rs = _context.NguoiChoi.Add(item);
                await _context.SaveChangesAsync();
                return rs.Entity;
            }
            else
            {
                _context.Entry(item).State = EntityState.Modified;

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

        public async Task<NguoiChoi?> GetNguoiChoiByDienThoai(string pDienThoai)
        {
            var rs = await _context.NguoiChoi.FirstOrDefaultAsync(m => m.DienThoai == pDienThoai);
            return rs;
        }

        public async Task<NguoiChoi?> GetNguoiChoiById(int pId)
        {
            var rs = await _context.NguoiChoi.FirstOrDefaultAsync(m => m.Id == pId);
            return rs;
        }

        public async Task<bool> IsExist(string? pDienThoai)
        {
            var isExist = await _context.NguoiChoi.AnyAsync(m => m.DienThoai == pDienThoai);
            return isExist;
        }
    }
}
