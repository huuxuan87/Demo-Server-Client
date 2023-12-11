using AutoMapper;
using Client.Config;
using Client.Helpers;
using Client.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Server.Services;
using System;

namespace Client.Test
{
    [TestClass]
    public class DatSoServiceTest
    {
        private IDatSoService _datSoService;

        [TestInitialize] 
        public void Init() 
        {
            IMapper mapper = new MapperConfiguration(cf => cf.AddProfile<CustomerProfile>()).CreateMapper();
            IConfigAppSetting appConfig = new ConfigAppSetting();
            _datSoService = new DatSoService(mapper, appConfig);
        }

        [TestMethod]
        public void GetThoiGianServer_To_Ok()
        {
            var rs = _datSoService.GetThoiGianServer();
            Assert.AreEqual(rs.IsOk, true);
        }

        [TestMethod]
        public void GetDatSo_To_Ok()
        {
            var rs = _datSoService.GetDatSo(0, null, null);
            Assert.AreEqual(rs.IsOk, true);
        }

        [TestMethod]
        public void DatSo_To_PostNguoiChoiBiRong()
        {
            var rs = _datSoService.DatSo(new DatSoModel());
            Assert.IsTrue(rs.IsOk == false && rs.Response.Request.Method == RestSharp.Method.Post && rs.Errors.Contains("Giá trị người chơi bị rỗng"));
        }

        [TestMethod]
        public void DatSo_To_PutNguoiChoiBiRong()
        {
            var rs = _datSoService.DatSo(new DatSoModel() { Id = 1 });
            Assert.IsTrue(rs.IsOk == false && rs.Response.Request.Method == RestSharp.Method.Put && rs.Errors.Contains("Giá trị người chơi bị rỗng"));
        }
    }
}
