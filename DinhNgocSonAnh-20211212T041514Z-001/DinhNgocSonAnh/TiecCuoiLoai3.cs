using System;


namespace DinhNgocSonAnh
{
    internal class TiecCuoiLoai3 : TiecCuoi
    {
        private int chiPhiMC1;
        private int chiPhiMC2;

        public TiecCuoiLoai3()
        {
            soLuongBan = 15;
            SoLuongThiep = 150;
            soLuongMenuMon = 7;
            soLuongMamQua = 7;
            soLuongNhanCong = 30;
        }
      
        public override void NhapChiPhi()
        {
            base.NhapChiPhi();
            Console.Write("Nhap vao chi phi MC 1: ");
            chiPhiMC1 = int.Parse(Console.ReadLine());
            Console.Write("Nhap vao chi phi MC 2: ");
            chiPhiMC2 = int.Parse(Console.ReadLine());
        }
        public override void XuatChiPhi()
        {
            base.XuatChiPhi();
            Console.WriteLine($"Chi phi MC 1: {chiPhiMC1}");
            Console.WriteLine($"Chi phi MC 2: {chiPhiMC2}");
        }
        public override int TinhTongChiPhi()
        {
            return base.TinhTongChiPhi() + chiPhiMC1 + chiPhiMC2;
        }
    }
}
