namespace Bai4
{
    internal class Program
    {
        public class ThangNam
        {
            //Lớp định dạng tháng và năm
            int thang;
            int nam;
            public void Nhap()
            {
                //Hàm nhập
                while (true)
                {
                    Console.Write("Nhap thang: ");
                    if (!int.TryParse(Console.ReadLine(), out thang))
                    {
                        Console.WriteLine("[Dinh dang khong hop le, vui long nhap lai]");
                        continue;
                    }
                    Console.Write("Nhap nam: ");
                    if (!int.TryParse(Console.ReadLine(), out nam))
                    {
                        Console.WriteLine("[Dinh dang khong hop le, vui long nhap lai]");
                        continue;
                    }
                
                    if (KiemTraHopLe() == false)
                    {
                        //Kiểm tra ngày tháng đã nhập vào
                        Console.WriteLine("\n[Ngay thang khong hop le, vui long nhap lai]\n");
                        continue;
                    }
                    break;
                }
            }
            public bool IsLeapYear(int year)
            {
                //Kiểm tra năm nhuận
                return (year % 4 == 0 && year % 100 != 0) || (year % 400 == 0);
            }
            public bool KiemTraHopLe()
            {
                //Kiểm tra tháng năm có hợp lệ không
                if (nam < 1 || thang < 1 || thang > 12 )
                {
                    return false;
                }
                return true;

            }
            public int NgayCuaThang()
            {   
                //Hàm trả về ngày của 1 tháng
                if (thang == 4 || thang == 6 || thang == 9 || thang == 11)
                {
                    return 30;
                }
                else if (thang == 2)
                {
                    return IsLeapYear(nam) ? 29 : 28;
                }
                else return 31;
            }
        }
        static void Main(string[] args)
        {
            //Khai báo biến thử để chọn
            int Bien = -1;
            Console.WriteLine("---= Kiem tra ngay cua thang =---\n");
            while (Bien != 0)
            {
                Console.WriteLine("Muon kiem tra thu khong? \n0. KHONG\n1. CO");
                Console.Write("\n=>>>> Lua chon cua ban: ");
                //Nhập lựa chọn
                if(!int.TryParse(Console.ReadLine(), out Bien))
                {
                    Console.WriteLine("\n[Lua chon khong hop le, chon lai nha]\n");
                    Bien = -1;
                }
                else if (Bien == 0)
                {
                    //Dừng chương trình
                    Console.WriteLine("\n[Ket thuc chuong trinh]");
                }
                else if (Bien == 1)
                {
                    //Nhập dữ liệu, kiểm tra ngày của tháng đó
                    ThangNam nt = new ThangNam();
                    Console.WriteLine("Nhap thang, nam: \n");
                    nt.Nhap();
                    Console.WriteLine("\n[Thang do co " + nt.NgayCuaThang() + " ngay]\n");
                }
                else
                {
                    //Dữ liệu đầu vào k chính xác
                     Console.WriteLine("\n[Lua chon khong hop le, chon lai nha]\n");
                }
            }
        }
    }
}
