using Client.Helpers;
using Client.Models;
using Server.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Server.Services
{
    public interface IDatSoService
    {
        ApiRequestResult<DateTime> GetThoiGianServer();
        ApiRequestResult DatSo(DatSoModel datSo);
        ApiRequestResult<List<DatSoResultModel>> GetDatSo(int pIDNguoiChoi, DateTime? pNgayDat, int? pGioDat);
    }
}
