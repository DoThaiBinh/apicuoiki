using System;
using System.Collections.Generic;

namespace APIAppQuanLyTaiChinh.Models;

public partial class Thuchi
{
    public string Idkhoangthuchi { get; set; } = null!;

    public DateOnly Idthoigianthem { get; set; }

    public decimal Sotien { get; set; }

    public virtual Khoanthuchi IdkhoangthuchiNavigation { get; set; } = null!;
}
