using System;


namespace DinhNgocSonAnh
{
    public enum Nhan
    {
        NHAN_BAC=100,
        NHAN_VANG=1000,
        NHAN_KIM_CUONG=10000
    }
    abstract class TiecCuoi
    {
        protected int chiPhiBan;
        protected int chiPhiThiep;
        protected int chiPhiMenuMon;
        protected int chiPhiMamQua;
        protected int chiPhiNhanCong;
        protected string loaiNhan;

        protected int soLuongBan;
        public int SoLuongThiep { get; set;  }
        protected int soLuongMenuMon;
        protected int soLuongMamQua;
        protected int soLuongNhanCong;

   

        public virtual void NhapChiPhi()
        {
            Console.Write("Nhap vao chi phi mot ban: ");
            chiPhiBan = int.Parse(Console.ReadLine());
            Console.Write("Nhap vao chi phi mot thiep cuoi: ");
            chiPhiThiep =int.Parse(Console.ReadLine());
            Console.Write("Nhap vao chi phi mot menu mon: ");
            chiPhiMenuMon =int.Parse(Console.ReadLine());
            Console.Write("Nhap vao chi phi nhan cong: ");
            chiPhiNhanCong =int.Parse(Console.ReadLine()) ;
            Console.Write("Nhap vao loai nhan (vang, bac, kim cuong): ");
            loaiNhan =Console.ReadLine();
        }

        protected int GetChiPhiNhan(string loaiNhan)
        {
            switch(loaiNhan)
            {
                case "bac":
                    return (int)Nhan.NHAN_BAC;
                case "vang":
                    return (int)Nhan.NHAN_VANG;
                case "kim cuong":
                    return (int)Nhan.NHAN_KIM_CUONG;
                default:
                    return 0;
            }
        }

        public virtual void XuatChiPhi()
        {
            Console.WriteLine($"=============== Tong Chi Phi: {TinhTongChiPhi()} ===================");
            Console.WriteLine("=============== Chi tiet ===================");
            Console.WriteLine($"Chi phi ban: {chiPhiBan}");
            Console.WriteLine($"Chi phi thiep: {chiPhiThiep}");
            Console.WriteLine($"Chi phi mon: {chiPhiMenuMon}");
            Console.WriteLine($"Chi phi mam qua: {chiPhiMamQua}");
            Console.WriteLine($"Chi phi nhan cong: {chiPhiNhanCong}");
            Console.WriteLine($"Chi phi nhan {loaiNhan}: {GetChiPhiNhan(loaiNhan)}");

            chiPhiBan = chiPhiBan * soLuongBan;
            chiPhiThiep = chiPhiThiep * SoLuongThiep;
            chiPhiMenuMon = chiPhiMenuMon * soLuongMenuMon;
            chiPhiNhanCong = chiPhiNhanCong * soLuongNhanCong;
            chiPhiMamQua = chiPhiMamQua * soLuongMamQua;
        }
        public virtual int TinhTongChiPhi()
        {
            return chiPhiBan + chiPhiMamQua + chiPhiMenuMon + chiPhiNhanCong + chiPhiThiep + GetChiPhiNhan(loaiNhan);
        }
    }
}
