using System.ComponentModel.Design;

namespace MaTran 
{
    internal class Program
    {
        static void Main()
        {
            //Khai báo số lượng hàng, cột, biến random để tạo giá trị ngẫu nhiên
            Random ran=new Random();
            Console.Write("Nhap so hang: ");
            int m = ReadPositiveInt();
            Console.Write("Nhap so cot: ");
            int n = ReadPositiveInt();
            //Tạo matrix
            List<List<int>> Mtx = new List<List<int>>();
            //Gán giá trị ngẫu nhiên cho matrix
            for (int x = 0; x < m; x++)
            {
                Mtx.Add(new List<int>());
                for (int y = 0; y < n; y++)
                {
                    Mtx[x].Add(ran.Next(0,100));
                }
            }
            int Bien = -1;
            while (Bien != 0)
            {
                //In menu
                Console.WriteLine("\n----= MENU= ----");
                Console.WriteLine("1. Xuat ma tran");
                Console.WriteLine("2. Tim phan tu lon nhat");
                Console.WriteLine("3. Tim phan tu nho nhat");
                Console.WriteLine("4. Tim dong co tong lon nhat");
                Console.WriteLine("5. Tinh tong cac so khong phai la so nguyen to");
                Console.WriteLine("6. Xoa dong");
                Console.WriteLine("7. Xoa cot co phan tu lon nhat");
                Console.WriteLine("0. Thoat chuong trinh");
                Console.Write("\nLua chon: ");
                if(!int.TryParse(Console.ReadLine(),out Bien))
                {
                    Console.WriteLine("\n[Lua chon khong hop le, vui long chon lai]");
                    Bien = -1;
                    continue;
                }
                //Xử lí chức năng người dùng chọn
                switch (Bien)
                {
                    case 1: 
                        XuatMaTran(Mtx);
                        break;
                    case 2: 
                        Console.WriteLine("\n[Phan tu lon nhat la: " + TimPhanTuLonNhat(Mtx) + "]");
                        break;
                    case 3:
                        Console.WriteLine("\n[Phan tu nho nhat la: " + TimPhanTuNhoNhat(Mtx) + "]");
                        break;
                    case 4:
                        Console.WriteLine("\n[Dong co tong lon nhat la dong thu " + TimDongCoTongLonNhat(Mtx) + "]");
                        break;
                    case 5:
                        Console.WriteLine("\n[Tong cac so khong phai so nguyen to la: " + TongCacSoKoNguyenTo(Mtx) + "]");
                        break;
                    case 6:
                        Console.Write("\nNhap dong muon xoa: ");
                        XoaDong(Mtx, ReadPositiveInt());
                        break;
                    case 7:
                        XoaCotCoPhanTuLonNhat(Mtx);
                        break;
                    case 0:
                        Console.WriteLine("\n[Ket thuc chuong trinh]");
                        break;
                    default:
                        Console.WriteLine("\n[Lua chon khong hop le, vui long chon lai]");
                        break;
                }
            }
        }
        static void XuatMaTran(List<List<int>> Mtx)
        {
            //Hàm xuất ma trận
            Console.WriteLine("\nXuat: \n");
            for(int x=0;x<Mtx.Count;x++)
            {
                for(int y = 0; y < Mtx[x].Count;y++)
                {
                    Console.Write(Mtx[x][y] + " ");
                }   
                Console.WriteLine();
            }    
        }
        static int TimPhanTuNhoNhat(List<List<int>> Mtx)
        {
            //Hàm tìm phần tử nhỏ nhất trong ma trận
            int min = int.MaxValue;
            for (int x = 0; x < Mtx.Count; x++)
            {
                if (Mtx[x].Min() < min)
                    min = Mtx[x].Min();
            }
            return min;
        }
        static int TimPhanTuLonNhat(List<List<int>> Mtx)
        {
            //Hàm tìm phần tử lớn nhất trong ma trận
            int max = int.MinValue;
            for (int x = 0; x < Mtx.Count; x++)
            {
                if (Mtx[x].Max() > max)
                    max = Mtx[x].Max();
            }
            return max;
        }
        static int TimDongCoTongLonNhat(List<List<int>> Mtx)
        {
            //Hàm tìm vị trí dòng có tổng các phần tử lớn nhất

            int value = 0;
            int MaxSum = int.MinValue;
            for (int x = 0; x < Mtx.Count; x++)
            {
                int sum = 0;
                for (int y = 0; y < Mtx[x].Count; y++)
                {
                    sum += Mtx[x][y];
                }
                if(sum > MaxSum)
                {
                    MaxSum = sum;
                    value = x;
                }
            }
            return value+1;
        }
        static int TongCacSoKoNguyenTo(List<List<int>> Mtx)
        {
            //Tổng các số nguyên tố trong ma trận
            int sum = 0;
            for (int x = 0; x < Mtx.Count; x++)
            {
                for (int y = 0; y < Mtx[x].Count; y++)
                {
                    if (IsSoNguyenTo(Mtx[x][y]) == false)
                    {
                        sum += Mtx[x][y];
                    }
                }
            }
            return sum;
        }
        static bool IsSoNguyenTo(int val)
        {
            //Kiểm tra số nguyên tố
            if(val < 2) return false;
            for(int x = 2 ; x < Math.Sqrt(val) ; x++)
            {
                if(val % x == 0) return false;
            }
            return true;
        }
        static void XoaDong(List<List<int>> Mtx, int ViTri)
        {
            //Hàm xóa dòng
            if(ViTri <0 || ViTri > Mtx.Count())
            {
                Console.WriteLine("\n[Vi tri khong hop le]");
                return;
            }
            Mtx.RemoveAt(ViTri - 1);
            Console.WriteLine("\n[Da xoa dong {0}]",ViTri);

        }
        static void XoaCotCoPhanTuLonNhat(List<List<int>> Mtx)
        {
            //Hàm xóa cột chứa phần tử lớn nhất ma trận
            int value = 0;
            int MaxVal = int.MinValue;
            for (int x = 0; x < Mtx.Count; x++)
            {
                for (int y = 0; y < Mtx[x].Count; y++)
                {

                    if (Mtx[x][y] > MaxVal)
                    {
                        MaxVal = Mtx[x][y];
                        value = y;
                    }
                
                }
            }
            foreach (List<int> x in Mtx)
            {
                x.RemoveAt(value);
            }
            Console.WriteLine("\n[Da xoa cot co phan tu lon nhat la cot {0}], \n", value + 1);

        }
        static int ReadPositiveInt()
        {
            //Hàm chỉ nhập số nguyên dương
            int n;
            do
            {
                if (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
                {
                    Console.WriteLine("\n[Dinh dang khong hop le, vui long nhap lai]\n");
                    continue;
                }
                break;
            } while (true);
            return n;
        }
    }


}

