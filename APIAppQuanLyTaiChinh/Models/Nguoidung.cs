using System;
using System.Collections.Generic;

namespace APIAppQuanLyTaiChinh.Models;

public partial class Nguoidung
{
    public string Idnguoidung { get; set; } = null!;

    public string Tennguoidung { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Passw { get; set; } = null!;

    public string Gioitinh { get; set; } = null!;

    public string? Anhdaidien { get; set; }

    public int Ngaybatdau { get; set; }

    public int Ngayketthuc { get; set; }

    public virtual ICollection<Khoanthuchi> Khoanthuchis { get; set; } = new List<Khoanthuchi>();
}
