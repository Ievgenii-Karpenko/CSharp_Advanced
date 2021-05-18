using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Delegats
{
    class ArrayOperations
    {
        private static void WriteArray(ref int[] arr, string message)
        {
            Console.WriteLine(message);
            foreach (int i in arr)
                Console.Write($"{i}  ");
            Console.WriteLine();
        }

        public static void WriteArray(ref int[] arr)
        {
            WriteArray(ref arr, "Initial array: ");
        }

        public static void IncrementSort(ref int[] arr)
        {
            int j, k;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                j = 0;
                do
                {
                    if (arr[j] > arr[j + 1])
                    {
                        k = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = k;
                    }
                    j++;
                }
                while (j < arr.Length - 1);
            }

            WriteArray(ref arr, "Ascendant sorting: ");
        }

        public static void DecrementSort(ref int[] arr)
        {
            int j, k;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                j = 0;
                do
                {
                    if (arr[j] < arr[j + 1])
                    {
                        k = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = k;
                    }
                    j++;
                }
                while (j < arr.Length - 1);
            }

            WriteArray(ref arr, "Descendant sorting: ");
        }

        // Заменяем нечетные числа четными и наоборот
        public static void ChetArr(ref int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
                if (arr[i] % 2 != 0)
                    arr[i] += 1;

            WriteArray(ref arr, "Even array: ");
        }

        public static void NeChetArr(ref int[] arr)
        {
            
            for (int i = 0; i < arr.Length; i++)
                if (arr[i] % 2 == 0)
                    arr[i] += 1;

            WriteArray(ref arr, "Odd array: ");
        }
    }
}
