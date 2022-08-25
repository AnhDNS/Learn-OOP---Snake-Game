using System;
using System.Collections.Generic;
using System.Linq;
namespace DinhNgocSonAnh
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /// a)
            
            TiecCuoiLoai1 tiecCuoiLoai1 = new TiecCuoiLoai1();
            TiecCuoiLoai2 tiecCuoiLoai2 = new TiecCuoiLoai2();
            TiecCuoiLoai3 tiecCuoiLoai3 = new TiecCuoiLoai3();

            Console.WriteLine("Nhap vao tiec cuoi loai 1");
            tiecCuoiLoai1.NhapChiPhi();
            tiecCuoiLoai1.XuatChiPhi();
            Console.WriteLine("Nhap vao tiec cuoi loai 2");
            tiecCuoiLoai2.NhapChiPhi();
            tiecCuoiLoai2.XuatChiPhi();
            Console.WriteLine("Nhap vao tiec cuoi loai 3");
            tiecCuoiLoai3.NhapChiPhi();
            tiecCuoiLoai3.XuatChiPhi();

            // b)
            DamCuoi damCuoi = new DamCuoi();
            damCuoi.NhapKinhPhi();
            damCuoi.LoaiTiecCuoiTotNhat(tiecCuoiLoai1, tiecCuoiLoai2, tiecCuoiLoai3);

            // c)
            damCuoi.RandomKhachThamDu();
            damCuoi.SoLuongTienMungMoiLoaiVaTienLai();

        }
    }
}
