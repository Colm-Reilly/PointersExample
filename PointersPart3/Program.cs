using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointersPart3
{
    class Program
    {
        static void Main(string[] args)
        {

            int x = 2, y = 3;


            //Compare pointers
            Console.WriteLine("----- Exercise 1 -----");

            unsafe
            {
                int* px = &x;
                int* py = &y;

                if (px == py)
                {
                    Console.WriteLine("The pointers point to the same address.\n");
                }
                if (px != py)
                {
                    Console.WriteLine("The pointers point to different addresses.\n");
                }
            }


            //find out if pointers point to higher, lower or same element in an array
            Console.WriteLine("----- Exercise 2 -----");

            int[] myArray = new int[5];
            for (int i = 0; i < 5; i++)
            {
                myArray[i] = i + 1;
            }

            unsafe
            {
                fixed (int* ptr1 = &myArray[0], ptr2 = &myArray[3])
                    if (ptr1 == ptr2)
                    {
                        Console.WriteLine("Pointers point to the same address.\n");
                    }
                    else if (ptr1 < ptr2)
                    {
                        Console.WriteLine("ptr1 points to a lower address than ptr2\n");
                    }
                    else
                    {
                        Console.WriteLine("ptr1 points to a higher address than ptr2\n");
                    }
            }


            Console.WriteLine("----- Exercise 3 -----");
            //Manipulate fixed array pointers

            unsafe
            {
                int[] intArray = new int[5] { 1, 2, 3, 4, 5 };

                fixed (int* arrayPtr = &intArray[0])
                {
                    int* tempPtr = arrayPtr;

                    tempPtr++;

                    Console.WriteLine("Element at address {0} = {1}\n", (int)tempPtr, *tempPtr);
                }
            }

            Console.WriteLine("----- Exercise 4 -----");
            //Void pointers

            unsafe
            {
                int* ptrx = &x;
                int* ptry = &y;
                void* voidx = (void*)ptrx;
                void* voidy = (void*)ptry;

                Console.WriteLine("Before swap x = {0} and y = {1}", *(int*)voidx, *(int*)voidy);


                Switch(ref voidx, ref voidy);

                ptrx = (int*)voidx;
                ptry = (int*)voidy;

                Console.WriteLine("After swap x = {0} and y = {1}\n", *ptrx, *ptry);

            }


            Console.WriteLine("----- Exercise 5 -----");
            //Stacklloc

            unsafe
            {
                int* myBuffer = stackalloc int[5];

                int Index;
                for (Index = 0; Index < 5; Index++)
                {
                    myBuffer[Index] = Index;
                }
                for (Index = 0; Index < 5; Index++)
                {
                    Console.WriteLine(myBuffer[Index]);
                }
            }


            Console.ReadLine();

        }

        public static unsafe void Switch(ref void* x, ref void* y)
        {
            void* temp = x;
            x = y;
            y = temp;
        }

    }
    
}
