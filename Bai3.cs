using System.Collections.Specialized;

namespace Bai3
{
    internal class Program
    {
        //Lớp định nghĩa ngày tháng
        public class NgayThang
        {
            int ngay;
            int thang;
            int nam;
            public void Nhap()
            {
                //Hàm nhập ngày, tháng, năm
                do
                {
                    Console.WriteLine("\nNhap ngay, thang, nam: \n");
                    Console.Write("Nhap ngay: ");
                    if(!int.TryParse(Console.ReadLine(), out ngay))
                    {
                        Console.WriteLine("\n[Gia tri khong hop le, vui long nhap lai]\n");
                        continue;
                    }
                    Console.Write("Nhap thang: ");
                    if(!int.TryParse(Console.ReadLine(), out thang))
                    {
                        Console.WriteLine("\n[Gia tri khong hop le, vui long nhap lai]\n");
                        continue;
                    }
                    Console.Write("Nhap nam: ");
                    if (!int.TryParse(Console.ReadLine(), out nam))
                    {
                        Console.WriteLine("\n[Gia tri khong hop le, vui long nhap lai]\n");
                        continue;
                    }
                    break;
                }
                while (true);
            }
            public bool IsLeapYear(int year)
            {
                //Hàm check năm nhuận
                return (year % 4 == 0 && year % 100 != 0) || (year % 400 == 0);
            }
            public bool KiemTraHopLe()
            {
                //Hàm kiểm tra ngày tháng năm hợp lệ
                if (nam < 1 || thang < 1 || thang > 12 || ngay < 1)
                {
                    return false;
                }
                int[] daysInMonth = { 31, (IsLeapYear(nam) ? 29 : 28), 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
                return ngay <= daysInMonth[thang - 1];
            }
        }
        static void Main(string[] args)
        {
            //Khai báo biến NgayThang, biến thử để chọn
            NgayThang nt = new NgayThang();
            int Bien = -1;
            while (Bien != 0)
            {
                //Lựa chọn kiểm tra hoặc dừng chương trình
                Console.WriteLine("Ban co muon kiem tra ngay, thang, nam hop le khong");
                Console.WriteLine("0. Khong");
                Console.WriteLine("1. Co");
                Console.Write("Cau tra loi: ");
                if(!int.TryParse(Console.ReadLine(), out Bien))
                {
                    //Kiểm tra điều kiện nhập, nếu sai thì nhập lại
                    Console.WriteLine("\n[Lua chon khong hop le, vui long chon lai]\n");
                    Bien = -1;
                    continue;
                }
                if (Bien == 0)
                {
                    //Dừng chương trình
                    Console.WriteLine("\n[Ket thuc chuong trinh]");
                }
                else if (Bien == 1)
                {
                    //Nhập ngày tháng năm, kiểm tra
                    nt.Nhap();
                    if (nt.KiemTraHopLe())
                        Console.WriteLine("\n[Hop le]\n");
                    else
                        Console.WriteLine("\n[Khong hop le]\n");
                }
                else
                {
                    //Báo lỗi nhập sai định dạng
                    Console.WriteLine("\n[Lua chon khong hop le, vui long chon lai]\n");
                }
            }
        }
    }
}
