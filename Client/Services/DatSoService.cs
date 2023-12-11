using Client.Models;
using System.Net.Http;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using RestSharp;
using Newtonsoft.Json;
using Client.Helpers;
using Server.Models;
using System.Web;
using Client.Extensions;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Client.Config;

namespace Server.Services
{
    public class DatSoService : IDatSoService
    {
        private readonly IMapper _mapper;
        private readonly IConfigAppSetting _configAppSetting;

        public DatSoService(IMapper mapper, IConfigAppSetting configAppSetting)
        {
            _mapper = mapper;
            _configAppSetting = configAppSetting;
        }

        public ApiRequestResult DatSo(DatSoModel datSo)
        {
            ApiRequestResult rs = null;

            // Số đã đặt
            if (datSo.Id == 0)
            {
                var rsSoDaDat = ApiRequestHelper.Get<List<DatSoResultModel>>(_configAppSetting.ApiUrl, $"/api/DatSo/danh-sach?pIDNguoiChoi={datSo.IDNguoiChoi}&pNgay={HttpUtility.UrlEncode(datSo.Ngay.GetValueEx().ToString("yyyy-MM-ddTHH:mm:ss"))}&pGio={datSo.Gio}");
                if (rsSoDaDat.IsOk)
                {
                    var soDatDat = rsSoDaDat.Result.FirstOrDefault();
                    if (soDatDat != null)
                    {
                        datSo.Id = soDatDat.Id;
                    }
                }
            }

            // Cập nhật
            if (datSo.Id > 0)
            {
                var rsDatSo = ApiRequestHelper.Put(_configAppSetting.ApiUrl, "/api/DatSo/" + datSo.Id, datSo);
                rs = rsDatSo;
            }
            else
            {
                var rsDatSo = ApiRequestHelper.Post<DatSoModel>(_configAppSetting.ApiUrl, "/api/DatSo", datSo);
                rs = _mapper.Map<ApiRequestResult>(rsDatSo);
            }

            return rs;
        }

        public ApiRequestResult<List<DatSoResultModel>> GetDatSo(int pIDNguoiChoi, DateTime? pNgayDat, int? pGioDat)
        {
            var resource = "/api/DatSo/danh-sach?pIDNguoiChoi=" + pIDNguoiChoi;
            if (pNgayDat.HasValue)
            {
                resource += "&pNgay=" + HttpUtility.UrlEncode(pNgayDat.GetValueEx().ToString("yyyy-MM-ddTHH:mm:ss"));
            }
            if (pGioDat.HasValue)
            {
                resource += "&pGio=" + pGioDat;
            }
            var rs = ApiRequestHelper.Get<List<DatSoResultModel>>(_configAppSetting.ApiUrl, resource);
            return rs;
        }

        public ApiRequestResult<DateTime> GetThoiGianServer()
        {
            var rs = ApiRequestHelper.Get<DateTime>(_configAppSetting.ApiUrl, "/api/DatSo/thoi-gian-server");
            return rs;
        }
    }
}
