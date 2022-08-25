using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinhNgocSonAnh
{
    internal class DamCuoi
    {
        private  int kinhPhiCotheChi;
        private  int khachThamDu;
        private  bool checkDuKinhPhi;
        private  int soLuongRandomKhachToiDa;
        private List<int> tienMung;

        public DamCuoi()
        {
            checkDuKinhPhi = false;
        }
        public void NhapKinhPhi()
        {
            Console.Write("Nhap vao kinh phi co the chi: ");
            kinhPhiCotheChi = int.Parse(Console.ReadLine());
        }
        public void LoaiTiecCuoiTotNhat(TiecCuoiLoai1 tiecCuoiLoai1, TiecCuoiLoai2 tiecCuoiLoai2, TiecCuoiLoai3 tiecCuoiLoai3)
        {
            bool luaChon1 = false;
            bool luaChon2 = false;
            bool luaChon3 = false;

            int tongChiPhiLoai1 = tiecCuoiLoai1.TinhTongChiPhi();
            int tongChiPhiLoai2 = tiecCuoiLoai2.TinhTongChiPhi();
            int tongChiPhiLoai3 = tiecCuoiLoai3.TinhTongChiPhi();

            int minChiPhiLoai = Math.Min(tongChiPhiLoai1, Math.Min(tongChiPhiLoai2, tongChiPhiLoai3));
            
            if (tongChiPhiLoai1 <= kinhPhiCotheChi)
                luaChon1 = true;
            if(tongChiPhiLoai2 <= kinhPhiCotheChi)
                luaChon2 = true;
            if(tongChiPhiLoai3 <= kinhPhiCotheChi)
                luaChon3 = true;

            if (luaChon1 && luaChon2)
            {
                if (tongChiPhiLoai1 == tongChiPhiLoai2)
                {
                    luaChon1 = false;
                }
                else if (tongChiPhiLoai1 > tongChiPhiLoai2)
                    luaChon2 = false;
                else
                    luaChon1 = false;
            }

            if (luaChon2 && luaChon3)
            {
                if (tongChiPhiLoai2 == tongChiPhiLoai3)
                {
                    luaChon2 = false;
                }
                else if (tongChiPhiLoai2 > tongChiPhiLoai3)
                    luaChon3 = false;
                else
                    luaChon2 = false;
            }

            if (luaChon1 && luaChon3)
            {
                if (tongChiPhiLoai1 == tongChiPhiLoai3)
                {
                    luaChon1 = false;
                }
                else if (tongChiPhiLoai1 > tongChiPhiLoai3)
                    luaChon3 = false;
                else
                    luaChon1 = false;
            }

            if (luaChon1)
            {
                Console.WriteLine($"So tien con lai sau khi chi la: {kinhPhiCotheChi - tongChiPhiLoai1}");
                checkDuKinhPhi = true;
                soLuongRandomKhachToiDa = tiecCuoiLoai1.SoLuongThiep;
            }

            if (luaChon2)
            {
                Console.WriteLine($"So tien con lai sau khi chi la: {kinhPhiCotheChi - tongChiPhiLoai2}");
                checkDuKinhPhi = true;
                soLuongRandomKhachToiDa = tiecCuoiLoai2.SoLuongThiep;
            }

            if (luaChon3)
            {
                Console.WriteLine($"So tien con lai sau khi chi la: {kinhPhiCotheChi - tongChiPhiLoai3}");
                checkDuKinhPhi = true;
                soLuongRandomKhachToiDa = tiecCuoiLoai3.SoLuongThiep;
            }

            if (!luaChon1 && !luaChon2 && !luaChon3)
            {
                Console.WriteLine($"Khong du kinh phi ! Can them it nhat {minChiPhiLoai - kinhPhiCotheChi} de to chuc loai toi thieu");
            }


        }

        
        public void RandomKhachThamDu()
        {
            if (!checkDuKinhPhi)
            {
                Console.WriteLine("Khong du kinh phi de to chuc nen khong co khach tham du");
            }
            else
            {
                Random random = new Random();
                khachThamDu = random.Next(soLuongRandomKhachToiDa - 20, soLuongRandomKhachToiDa + 1);

                int[] tien = { 100, 200, 500 };

                for (int i = 0; i < khachThamDu; i++)
                {
                    tienMung.Add(tien[random.Next(0, 3)]);
                }
            }
        }

        public void SoLuongTienMungMoiLoaiVaTienLai()
        {
            if (!checkDuKinhPhi)
            {
                Console.WriteLine("Khong du kinh phi de to chuc nen khong co khach tham du");
            }
            else
            {

                int count100 = 0;
                int count200 = 0;
                int count500 = 0;

                for (int i = 0; i < khachThamDu; i++)
                {
                    if(tienMung[i] == 100)
                        count100++;
                    
                    if(tienMung[i] == 200)
                        count200++;
                    if(tienMung[i] == 500)
                        count500++;
                }

                Console.WriteLine($"So luong tien 100 da duoc mung la: {count100}");
                Console.WriteLine($"So luong tien 200 da duoc mung la: {count200}");
                Console.WriteLine($"So luong tien 500 da duoc mung la: {count500}");
                Console.WriteLine($"Tien lai sau le cuoi la: {TongSoTienLai()}");
            }
        }

        private int TongTienMung ()
        {
            int sum = 0;
            for (int i = 0; i < khachThamDu; i++)
            {
                sum += tienMung[i];
            }
            return sum;
        }


        private int TongSoTienLai()
        {
            if (!checkDuKinhPhi) { return 0; }
           
            return kinhPhiCotheChi - TongTienMung();
        }
    }
}
