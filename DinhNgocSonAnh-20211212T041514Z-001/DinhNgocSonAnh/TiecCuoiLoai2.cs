using System;

namespace DinhNgocSonAnh
{
    internal class TiecCuoiLoai2 : TiecCuoi
    {
        private int chiPhiMC;

        public TiecCuoiLoai2()
        {
            soLuongBan = 12;
            SoLuongThiep = 120;
            soLuongMenuMon = 6;
            soLuongMamQua = 5;
            soLuongNhanCong = 25;
        }
       
        public override void NhapChiPhi()
        {
            base.NhapChiPhi();
            Console.Write("Nhap vao chi phi MC: ");
            chiPhiMC = int.Parse(Console.ReadLine());
        }

        public override void XuatChiPhi()
        {
            base.XuatChiPhi();
            Console.WriteLine($"Chi phi MC: {chiPhiMC}");
        }
        public override int TinhTongChiPhi()
        {
            return base.TinhTongChiPhi() + chiPhiMC;
        }
    }
}
