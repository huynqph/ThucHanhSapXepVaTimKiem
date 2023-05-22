using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HuyNguyen
{
    class ThucHanhSapXepVaTimKiem
    {

        static void Swap(int[] arr, int i, int j)
        {
            int temp = arr[i];S
            arr[i] = arr[j];
            arr[j] = temp;
        }
        static void PrintArray(int[] arr)
        {
            foreach (int e in arr)
            {
                Console.Write(e + " ");
            }
        }
        static int ThuatToanTimKiemTuyenTinh(int[] arr, int x)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == x)
                {
                    return i;
                }
            }
            return -1;
        }
        static int ThuatToanTimKiemNhiPhan(int[] arr, int x)
        {
            int left = 0;
            int right = arr.Length - 1;

            while (left <= right)
            {
                int middle = (left + right) / 2;

                if (arr[middle] == x)
                {
                    return middle;
                }
                else if (arr[middle] < x)
                {
                    left = middle + 1;
                }
                else
                {
                    right = middle - 1;
                }
            }

            return -1;
        }
        static int ThuatToanTimKiemNoiSuy(int[] arr, int x)
        {
            int left = 0;
            int right = arr.Length - 1;

            while (left <= right && x >= arr[left] && x <= arr[right])
            {
                int pos = left + ((x - arr[left]) * (right - left)) / (arr[right] - arr[left]);

                if (arr[pos] == x)
                {
                    return pos;
                }
                else if (arr[pos] < x)
                {
                    left = pos + 1;
                }
                else
                {
                    right = pos - 1;
                }
            }

            return -1;
        }

        static void LinearSeach(int[] arr)
        {
            PrintArray(arr);
            Console.WriteLine();
            Console.Write("Mời bạn nhập Phần tử cần tìm: ");
            int x = int.Parse(Console.ReadLine());
            int LS = ThuatToanTimKiemTuyenTinh(arr, x);
            if (LS != -1)
            {
                Console.WriteLine("Phần tử {0} được tìm thấy tại vị trí {1}.", x, LS);
            }
            else
            {
                Console.WriteLine("Không tìm thấy phần tử {0} trong mảng.", x);
            }
        }
        static void BinearSearch(int[] arr)
        {
            //SapXepNoiBot
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length - 1 - i; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        Swap(arr, j, j + 1);
                    }
                }
            }
            Console.WriteLine("Mảng đã được sắp xếp!");
            PrintArray(arr);
            Console.WriteLine();
            Console.Write("Mời bạn nhập Phần tử cần tìm: ");
            int x = int.Parse(Console.ReadLine());
            int NP = ThuatToanTimKiemNhiPhan(arr, x);
            if (NP != -1)
            {
                Console.WriteLine("Phần tử {0} được tìm thấy tại vị trí {1}.", x, NP);
            }
            else
            {
                Console.WriteLine("Không tìm thấy phần tử {0} trong mảng.", x);
            }
        }
        static void InterpolationSearch(int[] arr)
        {
           
            //SapXepNoiBot
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length - 1 - i; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        Swap(arr, j, j + 1);
                    }
                }
            }
            Console.WriteLine("Mảng đã được sắp xếp!");
            PrintArray(arr);
            Console.WriteLine();
            Console.Write("Mời bạn nhập Phần tử cần tìm: ");
            int x = int.Parse(Console.ReadLine());
            int IS = ThuatToanTimKiemNhiPhan(arr, x);
            if (IS != -1)
            {
                Console.WriteLine("Phần tử {0} được tìm thấy tại vị trí {1}.", x, IS);
            }
            else
            {
                Console.WriteLine("Không tìm thấy phần tử {0} trong mảng.", x);
            }
        }


        static int Partition(int[] arr, int low, int high)
        {
            int pivot = arr[high];
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (arr[j] < pivot)
                {
                    i++;
                    Swap(arr, i, j);
                }
            }

            Swap(arr, i + 1, high);

            return i + 1;
        }

        static void QuickSortDQ(int[] arr, int low, int high)
        {
            if (low < high)
            {
                int pivotIndex = Partition(arr, low, high);

                QuickSortDQ(arr, low, pivotIndex - 1);
                QuickSortDQ(arr, pivotIndex + 1, high);
            }
        }

        static void SapXepChon(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                int min = i;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[min] > arr[j])
                    {
                        min = j;
                    }
                }
                if (min != i)
                {
                    Swap(arr, i, min);
                }
            }
            Console.WriteLine();
            PrintArray(arr);

        }
        static void SapXepChen(int[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                var j = i;
                while (j > 0 && arr[j].CompareTo(arr[j - 1]) < 0)
                {
                    Swap(arr, j, j - 1);
                }

            }
            Console.WriteLine();
            PrintArray(arr);

        }

        static void SapXepNoiBot(int[] arr)
        {
    
            int n = arr.Length;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n - 1 - i; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        Swap(arr, j, j + 1);
                    }
                }
            }
            Console.WriteLine();
            PrintArray(arr);

            
        }
        static void SapXepNhanh(int[] arr)
        {
            Console.WriteLine();
            QuickSortDQ(arr, 0, arr.Length - 1);

            Console.WriteLine("- Mảng sau khi sắp xếp!");
            PrintArray(arr);


        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            int[] sizes = { 10, 100, 1000, 10000 };

            foreach (int size in sizes)
            {
                int[] array = GenerateRandomArray(size);

                Console.Write($"Array size: {size}");

                int[] bubbleSortArray = (int[])array.Clone();
                Stopwatch stopwatch = Stopwatch.StartNew();
                SapXepNoiBot(bubbleSortArray);
                Console.WriteLine();
                stopwatch.Stop();
                Console.WriteLine("*****");
                Console.WriteLine($"Sắp Xếp nổi bọt: {stopwatch.Elapsed.TotalMilliseconds} ms");

                int[] selecSortArray = (int[])array.Clone();
                stopwatch.Restart();
                SapXepChon(selecSortArray);
                Console.WriteLine();
                stopwatch.Stop();
                Console.WriteLine("*****");
                Console.WriteLine($"Sắp xếp chọn: {stopwatch.Elapsed.TotalMilliseconds} ms");

                int[] insertionSortArray = (int[])array.Clone();
                stopwatch.Restart();
                SapXepNoiBot(insertionSortArray);
                Console.WriteLine();
                stopwatch.Stop();
                Console.WriteLine("*****");
                Console.WriteLine($"Sắp xếp chèn: {stopwatch.Elapsed.TotalMilliseconds} ms");

                int[] quirksoftarray = (int[])array.Clone();
                stopwatch.Restart();
                SapXepNoiBot(quirksoftarray);
                Console.WriteLine();
                stopwatch.Stop();
                Console.WriteLine("*****");
                Console.WriteLine($"Sắp xếp nhanh: {stopwatch.Elapsed.TotalMilliseconds} ms");

                int[] Liner = (int[])array.Clone();
                stopwatch.Restart();
                LinearSeach(array);        
                stopwatch.Stop();
                Console.WriteLine("*****");
                Console.WriteLine($"Tìm kiếm tuần tự: {stopwatch.Elapsed.TotalMilliseconds} ms");
                Console.ReadLine();

                int[] Binear = (int[])array.Clone();
                stopwatch.Restart();
                BinearSearch(array);
                stopwatch.Stop();
                Console.WriteLine("*****");
                Console.WriteLine($"Tìm kiếm Nhị phân: {stopwatch.Elapsed.TotalMilliseconds} ms");
                Console.ReadLine();

                int[] interpo = (int[])array.Clone();
                stopwatch.Restart();
                InterpolationSearch(array);
                stopwatch.Stop();
                Console.WriteLine("*****");
                Console.WriteLine($"Tìm kiếm nội suy: {stopwatch.Elapsed.TotalMilliseconds} ms");
                Console.ReadLine();

            }

            static int[] GenerateRandomArray(int size)
            {
                Random random = new Random();
                int[] array = new int[size];

                for (int i = 0; i < size; i++)
                {
                    array[i] = random.Next(1, 1000);
                }

                return array;
            }
        }
    }
}
