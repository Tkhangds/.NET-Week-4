﻿using System;
using System.Collections.Generic;

namespace BaiTapThucHanhWeek4.Models;

public partial class TMauSac
{
    public string MaMauSac { get; set; } = null!;

    public string? TenMauSac { get; set; }

    public virtual ICollection<TChiTietSanPham> TChiTietSanPhams { get; } = new List<TChiTietSanPham>();
}
