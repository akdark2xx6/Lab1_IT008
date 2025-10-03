namespace ThuTrongTuan
{
    internal class Program
    {
        static bool IsLeapYear(int year)
        {
            //Kiểm tra năm nhuận
            return (year % 4 == 0 && year % 100 != 0) || (year % 400 == 0);
        }
        static bool KiemTraHopLe(int ngay, int thang, int nam)
        {
            //Kiểm tra tính hợp lệ của ngày tháng
            if (nam < 1 || thang < 1 || thang > 12 || ngay < 1)
            {
                return false;
            }
            int[] daysInMonth = { 31, (IsLeapYear(nam) ? 29 : 28), 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            return ngay <= daysInMonth[thang - 1];
        }
        static void Main(string[] args)
        {
            Console.WriteLine("---= Kiem tra thu ngay =---\n");
            //Khai báo biến thử để chọn
            int Bien = -1;
            while (Bien != 0)
            {
                Console.WriteLine("\nNhap so bat ki de kiem tra, nhap 0 neu muon ket thuc chuong trinh: \n");
                Console.Write("Lua chon: ");
                if (!int.TryParse(Console.ReadLine(), out Bien))
                {
                    //Định dạng dữ liệu k hợp lệ
                    Console.WriteLine("\n[Khong hop le, vui long thu lai]");
                    Bien = -1;
                    continue;
                }
                else if (Bien == 0)
                {
                    //Dừng chương trình
                    Console.WriteLine("\n[Ket thuc chuong trinh]"); 
                    break;
                }
                int ngay, thang, nam;
                while (true)
                {
                    //Nhập dữ liệu 
                    Console.WriteLine("\nNhap ngay, thang, nam kiem tra:\n");
                    Console.Write("Nhap ngay: ");
                    if (!int.TryParse(Console.ReadLine(), out ngay))
                    {
                        Console.WriteLine("\n[Khong hop le, vui long thu lai]");
                        Bien = -1;
                        continue;
                    }
                    Console.Write("Nhap thang: ");
                    if (!int.TryParse(Console.ReadLine(), out thang))
                    {
                        Console.WriteLine("\n[Khong hop le, vui long thu lai]");
                        Bien = -1;
                        continue;
                    }
                    Console.Write("Nhap nam: ");
                    if (!int.TryParse(Console.ReadLine(), out nam))
                    {
                        Console.WriteLine("\n[Khong hop le, vui long thu lai]");
                        Bien = -1;
                        continue;
                    }
                    //Kiểm tra hợp lệ
                    if (KiemTraHopLe(ngay, thang, nam) == true)
                    {
                        //In thứ của ngày đó bằng enum DayOfWeek
                        string[] thu = { "Chu nhat", "Thu 2", "Thu 3", "Thu 4", "Thu 5", "Thu 6", "Thu 7" };
                        DateTime dt = new DateTime(nam, thang, ngay);
                        Console.WriteLine($"\nHom do la {thu[(int)dt.DayOfWeek]}");
                    }
                    else
                        Console.WriteLine("\n[Khong hop le, vui long thu lai]");
                }
            }
        }
    }
}
