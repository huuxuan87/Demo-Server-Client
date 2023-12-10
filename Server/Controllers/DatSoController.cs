using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Extensions;
using Server.Models;
using Server.Services;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatSoController : ControllerBase
    {
        private readonly IDatSoService _service;        

        public DatSoController(IDatSoService service)
        {
            _service = service;
        }

        // GET: api/DatSo/thoi-gian-server
        [HttpGet("thoi-gian-server")]
        public ActionResult<DateTime> GetThoiGianServer()
        {
            var rs = _service.GetDateTimeServer();
            return rs;
        }

        // GET: api/DatSo/danh-sach?pIDNguoiChoi=1&pNgay=&pGio=
        [HttpGet("danh-sach")]
        public async Task<ActionResult<IEnumerable<SP_GetDanhSachDatSoResult>>> GetDatSo(int? pIDNguoiChoi, DateTime? pNgay, int? pGio)
        {
            var lst = await _service.GetDanhSachDatSo(pIDNguoiChoi ?? 0, pNgay, pGio);
            return lst;
        }

        // GET: api/DatSo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DatSo>> GetDatSo(int id)
        {
            var rs = await _service.GetDatSoById(id);
            if (rs == null)
            {
                return NotFound();
            }

            return rs;
        }

        // POST: api/DatSo
        [HttpPost]
        public async Task<ActionResult<DatSo>> PostDatSo(DatSo datSo)
        {
            var lstError = _service.CheckErrorsDatSo(datSo);
            if (lstError.Any())
            {
                return BadRequest(new { Errors = lstError });
            }
            datSo.DbCommonUpdate(datSo.Id);
            var rs = await _service.AddOrUpdateDatSo(datSo);
            return CreatedAtAction("GetDatSo", new { id = datSo.Id }, datSo);
        }

        // PUT: api/DatSo/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDatSo(int id, DatSo datSo)
        {
            if (id != datSo.Id)
            {
                return BadRequest();
            }

            var lstError = _service.CheckErrorsDatSo(datSo);
            if (lstError.Any())
            {
                return BadRequest(new { Errors = lstError });
            }
            datSo.DbCommonUpdate(datSo.Id);
            var rs = await _service.AddOrUpdateDatSo(datSo);
            if (rs == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
