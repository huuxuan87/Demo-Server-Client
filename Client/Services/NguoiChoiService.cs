using Client.Models;
using System.Net.Http;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using RestSharp;
using Newtonsoft.Json;
using Client.Helpers;
using Client.Config;

namespace Server.Services
{
    public class NguoiChoiService : INguoiChoiService
    {
        private readonly IConfigAppSetting _configAppSetting;

        public NguoiChoiService(IConfigAppSetting configAppSetting)
        {
            _configAppSetting = configAppSetting;
        }

        public ApiRequestResult<NguoiChoiModel> AddNguoiChoi(NguoiChoiModel item)
        {
            var rs = ApiRequestHelper.Post<NguoiChoiModel>(_configAppSetting.ApiUrl, "/api/NguoiChoi", item);
            return rs;
        }

        public ApiRequestResult<NguoiChoiModel> GetNguoiChoiByDienThoai(string pDienThoai)
        {
            var rs = ApiRequestHelper.Get<NguoiChoiModel>(_configAppSetting.ApiUrl, "/api/NguoiChoi/" + pDienThoai);
            return rs;
        }
    }
}
