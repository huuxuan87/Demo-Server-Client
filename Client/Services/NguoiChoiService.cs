using Client.Models;
using System.Net.Http;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using RestSharp;
using Newtonsoft.Json;
using Client.Helpers;

namespace Server.Services
{
    public class NguoiChoiService : INguoiChoiService
    {
        public ApiRequestResult<NguoiChoiModel> AddNguoiChoi(NguoiChoiModel item)
        {
            var rs = ApiRequestHelper.Post<NguoiChoiModel>("/api/NguoiChoi", item);
            return rs;
        }

        public ApiRequestResult<NguoiChoiModel> GetNguoiChoiByDienThoai(string pDienThoai)
        {
            var rs = ApiRequestHelper.Get<NguoiChoiModel>("/api/NguoiChoi/" + pDienThoai);
            return rs;
        }
    }
}
