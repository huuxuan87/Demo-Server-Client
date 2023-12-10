using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Extensions;
using Server.Models;
using Server.Services;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NguoiChoiController : ControllerBase
    {
        private readonly INguoiChoiService _service;
        private readonly IMapper _mapper;

        public NguoiChoiController(INguoiChoiService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        // GET: api/NguoiChoi/0912345678
        [HttpGet("{pDienThoai}")]
        public async Task<ActionResult<NguoiChoi>> GetNguoiChoi(string pDienThoai)
        {
            var nguoiChoi = await _service.GetNguoiChoiByDienThoai(pDienThoai);

            if (nguoiChoi == null)
            {
                return NotFound();
            }

            return nguoiChoi;
        }

        // POST: api/NguoiChoi
        [HttpPost]
        public async Task<ActionResult<NguoiChoi>> PostNguoiChoi(NguoiChoi nguoiChoi)
        {
            if (!nguoiChoi.DienThoai.IsPhoneNumberValid())
            {
                ModelState.AddModelError("warning", "Vui lòng nhập số điện thoại hợp lệ");
            }

            if (string.IsNullOrWhiteSpace(nguoiChoi.HoDem) || string.IsNullOrWhiteSpace(nguoiChoi.Ten))
            {
                ModelState.AddModelError("warning", "Vui lòng nhập họ tên");
            }

            if (!nguoiChoi.NgaySinh.HasValue)
            {
                ModelState.AddModelError("warning", "Vui lòng nhập ngày sinh");
            }

            if (await _service.IsExist(nguoiChoi.DienThoai))
            {
                ModelState.AddModelError("warning", "Số điện thoại đã tồn tại");
            }

            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();

                return BadRequest(new { Errors = errors });
            }

            nguoiChoi.DbCommonUpdate(nguoiChoi.Id);
            await _service.AddUpdateNguoiChoi(nguoiChoi);

            return CreatedAtAction("GetNguoiChoi", new { pDienThoai = nguoiChoi.DienThoai }, nguoiChoi);
        }
    }
}
