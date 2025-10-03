namespace TongSoNguyenTo
{
    internal class Program
    {
        static void Main()
        {
            //1) Tạo biến thử để người dùng chọn
            int num = -1;
            while (num != 0)
            {   
                //2) Nhập n hoặc kết thúc chương trình + kiểm tra điều kiện nhập
                Console.Write("Nhap so nguyen duong n (Nhap 0 neu ban muon ket thuc chuong trinh): ");
                if(!int.TryParse(Console.ReadLine(), out num))
                {
                    //Không hợp lệ => nhập lại
                    Console.WriteLine("\n[Khong hop le]\n");
                    num = -1;
                    continue;
                }    
                else if (num == 0)
                {
                    //Dừng chương trình
                    Console.WriteLine("\n[Ket thuc chuong trinh]");
                    return;
                }
                else if (num > 0)
                {
                    //Tính tổng các số nguyên tố
                    int sum = 0;
                    for (int x = 2; x < num; x++)
                    {
                        if (KiemTraNguyenTo(x))
                        {
                            sum += x;
                        }
                    }
                    //In kết quả
                    Console.WriteLine($"\nTong cac so nguyen to tu 1 den {num} la: {sum}\n");
                }
                // Báo lỗi
                else Console.WriteLine("\n[Khong hop le]\n");
            
            }
        }
        //Hàm kiểm tra số nguyên tố
        static bool KiemTraNguyenTo(int n)
        {
            if (n < 2) return false;
            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0) return false;
            }
            return true;
        }
    }
}
