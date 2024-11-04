using System;
using System.Collections.Generic;

namespace BaiTapThucHanhWeek4.Models;

public partial class TUser
{
    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    //public LoaiUser LoaiUser { get; set; }

    public byte loaiuser { get; set; }

    public virtual ICollection<TKhachHang> TKhachHangs { get; } = new List<TKhachHang>();

    public virtual ICollection<TNhanVien> TNhanViens { get; } = new List<TNhanVien>();
}

//public enum LoaiUser
//{
//    NHANVIEN,
//    KHACHHANG
//}
