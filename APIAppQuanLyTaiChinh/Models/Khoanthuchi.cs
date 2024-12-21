using System;
using System.Collections.Generic;

namespace APIAppQuanLyTaiChinh.Models;

public partial class Khoanthuchi
{
    public string Idkhoangthuchi { get; set; } = null!;

    public string Tenthuchi { get; set; } = null!;

    public string? Idnguoidung { get; set; }

    public string? Hinhanh { get; set; }

    public virtual Nguoidung? IdnguoidungNavigation { get; set; }

    public virtual ICollection<Thuchi> Thuchis { get; set; } = new List<Thuchi>();
}
