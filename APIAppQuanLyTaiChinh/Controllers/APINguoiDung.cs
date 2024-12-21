using APIAppQuanLyTaiChinh.Models;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System;



namespace APIAppQuanLyTaiChinh.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class APINguoiDung : Controller
    {
        private readonly AppquanlytaichinhContext _context;
        public APINguoiDung(AppquanlytaichinhContext context)
        {
            _context = context;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest model)
        {
            if (model == null || string.IsNullOrEmpty(model.Idnguoidung) || string.IsNullOrEmpty(model.Passw))
            {
                return BadRequest("Invalid client request");
            }

            // Kiểm tra thông tin đăng nhập (giả định có bảng Users trong DB)
            var user = await _context.Nguoidungs
                .FirstOrDefaultAsync(u => u.Idnguoidung == model.Idnguoidung && u.Passw == model.Passw);

            if (user == null)
            {
                return Unauthorized();
            }

            // Nếu đăng nhập thành công, có thể tạo token hoặc trả về thông tin người dùng
            return Ok(new { Tennguoidung = user.Tennguoidung, Username = user.Idnguoidung });
        }
        [HttpGet("tongthuchi")]
        public async Task<IActionResult> tongthuchi(string Idnguoidung)
        {
            if (string.IsNullOrEmpty(Idnguoidung))
            {
                return BadRequest("Invalid client request");
            }

            var user = await _context.Nguoidungs
                .FirstOrDefaultAsync(u => u.Idnguoidung == Idnguoidung);

            if (user == null)
            {
                return Unauthorized();
            }

            var thuchi = _context.Thuchis.Where(i => i.Idkhoangthuchi.Contains(Idnguoidung) && i.Idthoigianthem.Month== DateTime.Now.Month).ToList();

            Decimal thu = thuchi
                .Where(t => t.Idkhoangthuchi.Contains("T"))
                .Sum(s => s.Sotien);

            Decimal chi = thuchi
                .Where(t => t.Idkhoangthuchi.Contains("C"))
            .Sum(s => s.Sotien);

            return Ok(new { Tienthu = Math.Round(thu, 2) , Tienchi = Math.Round(chi, 2)  });
        }
        [HttpGet("thuchi3thang")]
        public async Task<IActionResult> thuchi3thang(string Idnguoidung)
        {
            if (string.IsNullOrEmpty(Idnguoidung))
            {
                return BadRequest("Invalid client request");
            }

            var user = await _context.Nguoidungs
                .FirstOrDefaultAsync(u => u.Idnguoidung == Idnguoidung);

            if (user == null)
            {
                return Unauthorized();
            }

            var thuchi1 = _context.Thuchis.Where(i => i.Idkhoangthuchi.Contains(Idnguoidung) && i.Idthoigianthem.Month== DateTime.Now.Month).ToList();
            var thuchi2 = _context.Thuchis.Where(i => i.Idkhoangthuchi.Contains(Idnguoidung) && i.Idthoigianthem.Month== (DateTime.Now.Month-1)).ToList();
            var thuchi3 = _context.Thuchis.Where(i => i.Idkhoangthuchi.Contains(Idnguoidung) && i.Idthoigianthem.Month== (DateTime.Now.Month-2)).ToList();

            Decimal thu1 = thuchi1
                .Where(t => t.Idkhoangthuchi.Contains("T"))
                .Sum(s => s.Sotien);
            
            Decimal chi1 = thuchi1
                .Where(t => t.Idkhoangthuchi.Contains("C"))
            .Sum(s => s.Sotien);

            Decimal thu2 = thuchi2
                .Where(t => t.Idkhoangthuchi.Contains("T"))
                .Sum(s => s.Sotien);

            Decimal chi2 = thuchi2
                .Where(t => t.Idkhoangthuchi.Contains("C"))
            .Sum(s => s.Sotien);

            Decimal thu3 = thuchi3
                .Where(t => t.Idkhoangthuchi.Contains("T"))
                .Sum(s => s.Sotien);

            Decimal chi3 = thuchi3
                .Where(t => t.Idkhoangthuchi.Contains("C"))
            .Sum(s => s.Sotien);


            return Ok(new { Thu1 = Math.Round(thu1, 2) ,
                Chi1 = Math.Round(chi1, 2) ,
                Thu2 = Math.Round(thu2, 2),
                Chi2 = Math.Round(chi2, 2),
                Thu3 = Math.Round(thu3, 2),
                Chi3 = Math.Round(chi3, 2)
            });
        }


        [HttpGet("vitichluy")]
        public async Task<IActionResult> vitichluy(string Idnguoidung)
        {
            if (string.IsNullOrEmpty(Idnguoidung))
            {
                return BadRequest("Invalid client request");
            }

            var user = await _context.Nguoidungs
                .FirstOrDefaultAsync(u => u.Idnguoidung == Idnguoidung);

            if (user == null)
            {
                return Unauthorized();
            }
            var thuchi = _context.Thuchis.Where(i => i.Idkhoangthuchi.Contains(Idnguoidung) && i.Idthoigianthem.Year == DateTime.Now.Year).ToList();
            var thuchi1= thuchi.Where(i=>i.Idthoigianthem.Month==1).ToList();
            var thuchi2= thuchi.Where(i=>i.Idthoigianthem.Month==2).ToList();
            var thuchi3= thuchi.Where(i=>i.Idthoigianthem.Month==3).ToList();
            var thuchi4= thuchi.Where(i=>i.Idthoigianthem.Month==4).ToList();
            var thuchi5= thuchi.Where(i=>i.Idthoigianthem.Month==5).ToList();
            var thuchi6= thuchi.Where(i=>i.Idthoigianthem.Month==6).ToList();
            var thuchi7= thuchi.Where(i=>i.Idthoigianthem.Month==7).ToList();
            var thuchi8= thuchi.Where(i=>i.Idthoigianthem.Month==8).ToList();
            var thuchi9= thuchi.Where(i=>i.Idthoigianthem.Month==9).ToList();
            var thuchi10= thuchi.Where(i=>i.Idthoigianthem.Month==10).ToList();
            var thuchi11= thuchi.Where(i=>i.Idthoigianthem.Month==11).ToList();
            var thuchi12= thuchi.Where(i=>i.Idthoigianthem.Month==12).ToList();
            decimal thu1=thuchi1.Where(t => t.Idkhoangthuchi.Contains("T"))
                .Sum(s => s.Sotien);
            decimal chi1=thuchi1.Where(t => t.Idkhoangthuchi.Contains("C"))
                .Sum(s => s.Sotien);
            decimal thu2=thuchi2.Where(t => t.Idkhoangthuchi.Contains("T"))
                .Sum(s => s.Sotien);
            decimal chi2=thuchi2.Where(t => t.Idkhoangthuchi.Contains("C"))
                .Sum(s => s.Sotien);
            decimal thu3 = thuchi3.Where(t => t.Idkhoangthuchi.Contains("T"))
                .Sum(s => s.Sotien);
            decimal chi3 = thuchi3.Where(t => t.Idkhoangthuchi.Contains("C"))
                .Sum(s => s.Sotien);
            decimal thu4 = thuchi4.Where(t => t.Idkhoangthuchi.Contains("T"))
                .Sum(s => s.Sotien);
            decimal chi4 = thuchi4.Where(t => t.Idkhoangthuchi.Contains("C"))
                .Sum(s => s.Sotien);
              decimal thu5 = thuchi5.Where(t => t.Idkhoangthuchi.Contains("T"))
                .Sum(s => s.Sotien);
            decimal chi5 = thuchi5.Where(t => t.Idkhoangthuchi.Contains("C"))
                .Sum(s => s.Sotien); 
            decimal thu6 = thuchi6.Where(t => t.Idkhoangthuchi.Contains("T"))
                .Sum(s => s.Sotien);
            decimal chi6 = thuchi6.Where(t => t.Idkhoangthuchi.Contains("C"))
                .Sum(s => s.Sotien);
            decimal thu7 = thuchi7.Where(t => t.Idkhoangthuchi.Contains("T"))
                .Sum(s => s.Sotien);
            decimal chi7 = thuchi7.Where(t => t.Idkhoangthuchi.Contains("C"))
                .Sum(s => s.Sotien);
            decimal thu8 = thuchi8.Where(t => t.Idkhoangthuchi.Contains("T"))
                .Sum(s => s.Sotien);
            decimal chi8 = thuchi8.Where(t => t.Idkhoangthuchi.Contains("C"))
                .Sum(s => s.Sotien);
            decimal thu9 = thuchi9.Where(t => t.Idkhoangthuchi.Contains("T"))
                .Sum(s => s.Sotien);
            decimal chi9 = thuchi9.Where(t => t.Idkhoangthuchi.Contains("C"))
                .Sum(s => s.Sotien);
            decimal thu10 = thuchi10.Where(t => t.Idkhoangthuchi.Contains("T"))
                .Sum(s => s.Sotien);
            decimal chi10 = thuchi10.Where(t => t.Idkhoangthuchi.Contains("C"))
                .Sum(s => s.Sotien);
            decimal thu11 = thuchi11.Where(t => t.Idkhoangthuchi.Contains("T"))
                .Sum(s => s.Sotien);
            decimal chi11 = thuchi11.Where(t => t.Idkhoangthuchi.Contains("C"))
                .Sum(s => s.Sotien);
            decimal thu12 = thuchi12.Where(t => t.Idkhoangthuchi.Contains("T"))
                .Sum(s => s.Sotien);
            decimal chi12 = thuchi12.Where(t => t.Idkhoangthuchi.Contains("C"))
                .Sum(s => s.Sotien);

            return Ok(new { tl1 = thu1-chi1,
                tl2 = thu2 - chi2,
                tl3 = thu3 - chi3,
                tl4 = thu4 - chi4,
                tl5 = thu5 - chi5,
                tl6 = thu6 - chi6,
                tl7 = thu7 - chi7,
                tl8 = thu8 - chi8,
                tl9 = thu9 - chi9,
                tl10 = thu10 - chi10,
                tl11 = thu11 - chi11,
                tl12 = thu12 - chi12

            });
        }

        [HttpGet]
        [Route("GetAllUsers")]
        public async Task<ActionResult> GetAllUsers()
        {
            var x= await _context.Nguoidungs
                .Select(i => new
                {
                    i.Tennguoidung,
                    
                    i.Idnguoidung
                   
                })
                .ToListAsync();
            return Ok(x);
        }
        [HttpGet]
        [Route("GetTienTe")]
        public async Task<ActionResult<IEnumerable<Tiente>>> GetTienTe()
        {
            return await _context.Tientes.ToListAsync();
        }

        //[HttpGet("lichsuthu")]
        //public async Task<ActionResult<IEnumerable<historyRespond>>> lichsuthu(string Idnguoidung)
        //{
        //    var thuchi = _context.Thuchis.Where(i => i.Idkhoangthuchi.Contains(Idnguoidung) && i.Idkhoangthuchi.Contains('T')).ToList();
        //    List<historyRespond> historyList = new List<historyRespond>();

        //    foreach (var thu in thuchi)
        //    {
        //        String ten = _context.Khoanthuchis.Where(i => i.Idkhoangthuchi == thu.Idkhoangthuchi).Select(i => i.Tenthuchi).FirstOrDefault(); 
        //        historyList.Add(new historyRespond
        //        {
        //            tenkhoangthuchi = ten,
        //            thoigian = thu.Idthoigianthem.ToString(),
        //            sotien = thu.Sotien.ToString()
        //        });
        //    }

        //    return Ok(historyList);
        //}

        [HttpGet("lichsuthu")]
        public async Task<ActionResult<IEnumerable<historyRespond>>> lichsuthu(string Idnguoidung)
        {
            // Truy vấn bất đồng bộ danh sách `thuchi`
            var thuchi = await _context.Thuchis
                .Where(i => i.Idkhoangthuchi.Contains(Idnguoidung) && i.Idkhoangthuchi.Contains("T"))
                .ToListAsync();

            List<historyRespond> historyList = new List<historyRespond>();

            foreach (var thu in thuchi)
            {
                // Truy vấn tên khoản thu chi bất đồng bộ
                string ten = await _context.Khoanthuchis
                    .Where(i => i.Idkhoangthuchi == thu.Idkhoangthuchi)
                    .Select(i => i.Tenthuchi)
                    .FirstOrDefaultAsync();

                historyList.Add(new historyRespond
                {
                    tenkhoangthuchi = ten,
                    thoigian = thu.Idthoigianthem.ToString(),
                    sotien = thu.Sotien.ToString()
                });
            }

            return Ok(historyList);
        }


        [HttpGet("lichsuchi")]
        public async Task<ActionResult<IEnumerable<historyRespond>>> lichsuchi(string Idnguoidung)
        {
            var thuchi = await _context.Thuchis
                .Where(i => i.Idkhoangthuchi.Contains(Idnguoidung) && i.Idkhoangthuchi.Contains("C"))
                .ToListAsync();

            List<historyRespond> historyList = new List<historyRespond>();

            foreach (var thu in thuchi)
            {
                string ten = await _context.Khoanthuchis
                    .Where(i => i.Idkhoangthuchi == thu.Idkhoangthuchi)
                    .Select(i => i.Tenthuchi)
                    .FirstOrDefaultAsync();

                historyList.Add(new historyRespond
                {
                    tenkhoangthuchi = ten,
                    thoigian = thu.Idthoigianthem.ToString(),
                    sotien = thu.Sotien.ToString()
                });
            }

            return Ok(historyList);
        }

        [HttpGet("getHoSo")]
        public async Task<IActionResult> getHoSo(string Idnguoidung)
        {
            var user = await _context.Nguoidungs
                .FirstOrDefaultAsync(u => u.Idnguoidung == Idnguoidung );
            return Ok(new { anh = user.Anhdaidien, ten = user.Tennguoidung, gt= user.Gioitinh });

        }
        [HttpGet("getKhoanThu")]
        public async Task<IActionResult> getKhoanThu(string Idnguoidung)
        {
            var khoanthu = await _context.Khoanthuchis.Where(i=>i.Idkhoangthuchi.Contains("T") && i.Idnguoidung==Idnguoidung)
                .Select(i => new
                {
                    i.Idkhoangthuchi,
                    i.Tenthuchi,
                    i.Idnguoidung,
                    i.Hinhanh
                })
                .ToListAsync();    

            return Ok(khoanthu);

        }
        [HttpGet("getKhoanChi")]
        public async Task<IActionResult> getKhoanChi(string Idnguoidung)
        {
            var khoanchi = await _context.Khoanthuchis.Where(i=>i.Idkhoangthuchi.ToString().Contains("C") && i.Idnguoidung==Idnguoidung)
                .Select(i => new 
                {
                    i.Idkhoangthuchi,
                    i.Tenthuchi,
                    i.Idnguoidung,
                    i.Hinhanh
                })
                .ToListAsync();    

            return Ok(khoanchi);

        }
        [HttpGet("getAllDanMuc")]
        public async Task<IActionResult> getAllDanMuc(string Idnguoidung)
        {
            var khoanchi = await _context.Khoanthuchis.Where(i=> i.Idnguoidung==Idnguoidung)
                .Select(i => new 
                {
                    i.Idkhoangthuchi,
                    i.Tenthuchi,
                    i.Idnguoidung,
                    i.Hinhanh
                })
                .ToListAsync();    

            return Ok(khoanchi);
        }
        
        
        [HttpPut("ChinhSuaProfile")]
        public async Task<IActionResult> ChinhSuaProfile(string Idnguoidung, string ten, string email, string pass, string anhdaidien)
        {
            var nguoidung = await _context.Nguoidungs.Where(i=> i.Idnguoidung==Idnguoidung).FirstOrDefaultAsync();
            
            nguoidung.Tennguoidung=ten;
            nguoidung.Email=email;
            nguoidung.Email = email;
            nguoidung.Passw=pass;
            nguoidung.Anhdaidien=anhdaidien;
            await _context.SaveChangesAsync();
            return Ok("OK");
        }

        [HttpPost("insertTienThu")]
        public async Task<IActionResult> insertTienThu(string idkhoangthuchi, decimal sotien)
        {
            // Tạo đối tượng mới để thêm vào bảng `Thuchi`
            DateOnly ngayHienTai = DateOnly.FromDateTime(DateTime.Now);

            var kt = await _context.Thuchis.Where(i => i.Idkhoangthuchi == idkhoangthuchi && i.Idthoigianthem == ngayHienTai).FirstOrDefaultAsync();
            if (kt == null)
            {
                var thuchi = new Thuchi
                {
                    Idkhoangthuchi = idkhoangthuchi,
                    Idthoigianthem = ngayHienTai,
                    Sotien = sotien

                };

                _context.Thuchis.Add(thuchi);
            }
            else
            {
                kt.Sotien= kt.Sotien+sotien;
                _context.Thuchis.Update(kt);
            }
            // Lưu thay đổi vào cơ sở dữ liệu
            await _context.SaveChangesAsync();

            // Trả về phản hồi thành công
            return Ok(new { Message = "Data inserted successfully" });
        }
         [HttpPost("insertTienChi")]
        public async Task<IActionResult> insertTienChi(string idkhoangthuchi,string ngay, decimal sotien)
        {
            // Tạo đối tượng mới để thêm vào bảng `Thuchi`
            DateOnly ngaynhap = DateOnly.ParseExact(ngay, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            var kt = await _context.Thuchis.Where(i => i.Idkhoangthuchi == idkhoangthuchi && i.Idthoigianthem == ngaynhap).FirstOrDefaultAsync();
            if (kt == null)
            {
                var thuchi = new Thuchi
                {
                    Idkhoangthuchi = idkhoangthuchi,
                    Idthoigianthem = ngaynhap,
                    Sotien = sotien

                };

                _context.Thuchis.Add(thuchi);
            }
            else
            {
                kt.Sotien= kt.Sotien+sotien;
                _context.Thuchis.Update(kt);
            }
            // Lưu thay đổi vào cơ sở dữ liệu
            await _context.SaveChangesAsync();

            // Trả về phản hồi thành công
            return Ok(new { Message = "Data inserted successfully" });
        }
        
        [HttpPost("dangKi")]
        public async Task<IActionResult> dangKi(string sdt,string ten, string gmail, string pass)
        {
            var k= await _context.Nguoidungs.Where(n=>n.Idnguoidung==sdt).FirstOrDefaultAsync();
            if (k == null)
            {
                var nguoi = new Nguoidung
                {
                    Idnguoidung = sdt,
                    Tennguoidung = ten,
                    Email = gmail,
                    Passw = pass,
                    Gioitinh = "Nam",
                    Anhdaidien = "daidien.png",
                    Ngaybatdau= 1,
                    Ngayketthuc=30

                };
                _context.Nguoidungs.Add(nguoi);
                await _context.SaveChangesAsync();


                var thu1 = new Khoanthuchi
                {
                    Idkhoangthuchi = sdt + "T001",
                    Tenthuchi = "Cho tặng",
                    Idnguoidung= sdt,
                    Hinhanh= "2131230861"
                };
                _context.Khoanthuchis.Add(thu1);
                
                var thu2 = new Khoanthuchi
                {
                    Idkhoangthuchi = sdt + "T002",
                    Tenthuchi = "Lãi suất",
                    Idnguoidung= sdt,
                    Hinhanh= "2131231018"
                };
                _context.Khoanthuchis.Add(thu2);
                
                var thu3 = new Khoanthuchi
                {
                    Idkhoangthuchi = sdt + "T003",
                    Tenthuchi = "Làm thêm",
                    Idnguoidung= sdt,
                    Hinhanh= "2131231019"
                };
                _context.Khoanthuchis.Add(thu3);
                
                var thu4 = new Khoanthuchi
                {
                    Idkhoangthuchi = sdt + "T004",
                    Tenthuchi = "Đầu tư",
                    Idnguoidung= sdt,
                    Hinhanh= "2131230897"
                };
                _context.Khoanthuchis.Add(thu4);
                
                
                
                var chi1 = new Khoanthuchi
                {
                    Idkhoangthuchi = sdt + "C001",
                    Tenthuchi = "Ăn uống",
                    Idnguoidung= sdt,
                    Hinhanh= "2131231101"
                };
                _context.Khoanthuchis.Add(chi1);
                
                var chi2 = new Khoanthuchi
                {
                    Idkhoangthuchi = sdt + "C002",
                    Tenthuchi = "Mua sắm",
                    Idnguoidung= sdt,
                    Hinhanh= "2131231101"
                };
                _context.Khoanthuchis.Add(chi2);
                
                var chi3 = new Khoanthuchi
                {
                    Idkhoangthuchi = sdt + "C003",
                    Tenthuchi = "Nhà cửa",
                    Idnguoidung= sdt,
                    Hinhanh= "2131231117"
                };
                _context.Khoanthuchis.Add(chi3);
                
                
                var chi4 = new Khoanthuchi
                {
                    Idkhoangthuchi = sdt + "C004",
                    Tenthuchi = "Đám tiệc",
                    Idnguoidung= sdt,
                    Hinhanh= "2131230893"
                };
                _context.Khoanthuchis.Add(chi4);
                await _context.SaveChangesAsync();
            }
            else
            {
                return Ok(new { Message = "Đã có thông tin người này" });
            }
            

            // Trả về phản hồi thành công
            return Ok(new { Message = "Data inserted successfully" });
        }
        [HttpPut("updateKhoang")]
        public async Task<IActionResult> updateKhoang(string idkhoangthuchi, string ten, string hinh)
        {
            var k= await _context.Khoanthuchis.Where(i=>i.Idkhoangthuchi==idkhoangthuchi).FirstOrDefaultAsync();
            if (k == null)
            {
                return Ok(new { Message = "sai id khoảng thu chi" });
            }
            else
            {
                k.Tenthuchi = ten;
                k.Hinhanh = hinh;
                _context.Khoanthuchis.Update(k);
                await _context.SaveChangesAsync();
            }
            return Ok(new { Message = "ok" });
        }
        
        [HttpPut("chuyenDoiTienTe")]
        public async Task<IActionResult> chuyenDoiTienTe(string idnguoidung, int loaihientai, int loaimoi)
        {
            var c= await _context.Tientes.Where(i=>i.Idtiente==( loaihientai)).FirstOrDefaultAsync();
            decimal tiencu = c.Tigiasovoivnd.Value;
            var m= await _context.Tientes.Where(i=>i.Idtiente==( loaimoi)).FirstOrDefaultAsync();
            decimal tienmoi = m.Tigiasovoivnd.Value;
            var k = await _context.Thuchis.Where(i => i.Idkhoangthuchi.Contains(idnguoidung)).ToListAsync();

            if (k == null)
            {
                return Ok(new { Message = "sai idnguoidung" });
            }
            else
            {
                foreach (var item in k)
                {
                    item.Sotien = (item.Sotien * tiencu) / tienmoi;
                    _context.Thuchis.Update(item);
                    await _context.SaveChangesAsync();
                }
             
                
            }
            return Ok(new { Message = "ok" });
        }


        [HttpDelete("deleteKhoangThuChi")]
        public async Task<IActionResult> deleteKhoangThuChi(string idkhoangthuchi)
        {
            var i = await _context.Thuchis.Where(i => i.Idkhoangthuchi == idkhoangthuchi).ToListAsync();
            _context.Thuchis.RemoveRange(i);
            
            var k = await _context.Khoanthuchis.Where(i => i.Idkhoangthuchi == idkhoangthuchi).FirstOrDefaultAsync();
            _context.Khoanthuchis.Remove(k);
            await _context.SaveChangesAsync();

            // Trả về phản hồi thành công
            return Ok(new { Message = "Data delete successfully" });
        }
        
        [HttpDelete("deleteUser")]
        public async Task<IActionResult> deleteUser(string sdt)
        {
            var i = await _context.Khoanthuchis.Where(i => i.Idkhoangthuchi.Contains( sdt)).ToListAsync();
            _context.Khoanthuchis.RemoveRange(i);
            
            var k = await _context.Thuchis.Where(i => i.Idkhoangthuchi.Contains(sdt)).FirstOrDefaultAsync();
            _context.Thuchis.Remove(k);
            
            var x = await _context.Nguoidungs.Where(i => i.Idnguoidung.Contains(sdt)).FirstOrDefaultAsync();
            _context.Nguoidungs.Remove(x);
            await _context.SaveChangesAsync();
            // Trả về phản hồi thành công
            return Ok(new { Message = "Data delete successfully" });
        }
        
        [HttpPost("insertKhoangThuChi")]
        public async Task<IActionResult> insertKhoangThuChi(string kieu, string ten,string sdt, string hinh)
        {
            string ma="";
            string k="";
            if (kieu.Contains  ("chi"))
            {
                k = "C";
                var mathuchi = await _context.Khoanthuchis
                                .Where(i => i.Idkhoangthuchi.Contains(sdt) && i.Idkhoangthuchi.Contains("C"))
                                .Select(i => i.Idkhoangthuchi.Substring(i.Idkhoangthuchi.Length - 3))
                                .OrderByDescending(x => x)
                                .FirstOrDefaultAsync();
                ma = (int.Parse( mathuchi)+1).ToString("D3");
            }
            else
            {
                k = "T";
                var mathuchi = await _context.Khoanthuchis
                                .Where(i => i.Idkhoangthuchi.Contains(sdt) && i.Idkhoangthuchi.Contains("T"))
                                .Select(i => i.Idkhoangthuchi.Substring(i.Idkhoangthuchi.Length - 3))
                                .OrderByDescending(x => x)
                                .FirstOrDefaultAsync();
                ma = (int.Parse(mathuchi) + 1).ToString("D3");

            }
            var khoang = new Khoanthuchi
            {
                Idkhoangthuchi = sdt+k+ma,
                Tenthuchi = ten,
                Idnguoidung = sdt,
                Hinhanh = hinh

            };
            _context.Khoanthuchis.Add(khoang);
            
            // Lưu thay đổi vào cơ sở dữ liệu
            await _context.SaveChangesAsync();

            // Trả về phản hồi thành công
            return Ok(new { Message = "Data inserted successfully" });
        }

    }
}


public class LoginRequest
{
    public string Idnguoidung { get; set; }
    public string Passw { get; set; }
}
public class NguoidungRequest
{
    public string Idnguoidung { get; set; }

}

public class historyRespond
{
    public string tenkhoangthuchi { get;set; }
    public string thoigian { get;set; }
    public string sotien { get;set; }

}
