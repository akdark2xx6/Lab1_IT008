using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTTH1_BT1
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1) Nhập n và tạo mảng
            int n = ReadPositiveInt("Nhập n (>0): ");
            int[] a = CreateRandomArray(n, -100, 100);

            int choice;
            do
            {
                // 2) In menu
                Console.WriteLine("\n===== MENU =====");
                Console.WriteLine("1. In mảng");
                Console.WriteLine("2. Tính tổng các số lẻ");
                Console.WriteLine("3. Đếm số nguyên tố");
                Console.WriteLine("4. Tìm số chính phương nhỏ nhất");
                Console.WriteLine("0. Thoát");
                Console.Write("Chọn chức năng: ");

                // 3) Đọc lựa chọn
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Lựa chọn không hợp lệ!");
                    continue;
                }

                // 4) Xử lý bằng switch
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Mảng:");
                        Console.WriteLine(string.Join(" ", a));
                        break;
                    case 2:
                        Console.WriteLine("Tổng các số lẻ: " + SumOdd(a));
                        break;
                    case 3:
                        Console.WriteLine("Số lượng số nguyên tố: " + CountPrimes(a));
                        break;
                    case 4:
                        Console.WriteLine("Số chính phương nhỏ nhất: " + SmallestPerfectSquare(a));
                        break;
                    case 0:
                        Console.WriteLine("Kết thúc chương trình.");
                        break;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ!");
                        break;
                }

            } while (choice != 0);
        }

        // Đọc số nguyên dương
        static int ReadPositiveInt(string message)
        {
            int n;
            do
            {
                Console.Write(message);
            } while (!int.TryParse(Console.ReadLine(), out n) || n <= 0);
            return n;
        }

        // Tạo mảng ngẫu nhiên
        static int[] CreateRandomArray(int n, int minVal, int maxVal)
        {
            var rnd = new Random();
            int[] a = new int[n];
            for (int i = 0; i < n; i++)
                a[i] = rnd.Next(minVal, maxVal + 1);
            return a;
        }

        // (a) Tổng số lẻ
        static int SumOdd(int[] a)
        {
            int sum = 0;
            foreach (int x in a)
                if (x % 2 != 0) sum += x;
            return sum;
        }

        // Kiểm tra số nguyên tố
        static bool IsPrime(int x)
        {
            if (x <= 1) return false;
            if (x == 2) return true;
            if (x % 2 == 0) return false;

            int limit = (int)Math.Sqrt(x);
            for (int i = 3; i <= limit; i += 2)
                if (x % i == 0) return false;

            return true;
        }

        // (b) Đếm số nguyên tố
        static int CountPrimes(int[] a)
        {
            int count = 0;
            foreach (int x in a)
                if (IsPrime(x)) count++;
            return count;
        }

        // Kiểm tra số chính phương
        static bool IsPerfectSquare(int x)
        {
            if (x < 0) return false;
            int r = (int)Math.Sqrt(x);
            return r * r == x;
        }

        // (c) Tìm số chính phương nhỏ nhất
        static int SmallestPerfectSquare(int[] a)
        {
            int? best = null;
            foreach (int x in a)
            {
                if (IsPerfectSquare(x))
                {
                    if (best == null || x < best.Value)
                        best = x;
                }
            }
            return best ?? -1;
        }
    }
}
