using AutoMapper;
using Client.Config;
using Client.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Server.Services;
using System;

namespace Client.Test
{
    [TestClass]
    public class NguoiChoiServiceTest
    {
        private INguoiChoiService _nguoiChoiService;

        [TestInitialize]
        public void Init()
        {
            IConfigAppSetting appConfig = new ConfigAppSetting();
            _nguoiChoiService = new NguoiChoiService(appConfig);
        }

        [TestMethod]
        public void AddNguoiChoi_To_LoiSoDienThoai()
        {
            var rs = _nguoiChoiService.AddNguoiChoi(new NguoiChoiModel());
            Assert.IsTrue(rs.IsOk == false && rs.Errors.Contains("Vui lòng nhập số điện thoại hợp lệ"));
        }

        [TestMethod]
        public void GetNguoiChoiByDienThoai_To_NotFound()
        {
            var rs = _nguoiChoiService.GetNguoiChoiByDienThoai("0");
            Assert.IsTrue(rs.IsOk == false && rs.Response.StatusCode == System.Net.HttpStatusCode.NotFound);
        }
    }
}
