using System;

namespace Generic
{
    class MyList<T>
    {
        private T[] array;

        public MyList()
        {
            array = new T[3];
        }

        public T this[int index]
        {
            get 
            { 
                return array[index]; 
            }

            set 
            { 
                if (index >= array.Length) 
                { 
                    Array.Resize<T>(ref array, index + 1);
                    Console.WriteLine($"Array Resized : {array.Length}");
                }

                array[index] = value;
            }
        }

        public int Length // 프로퍼티
        {
            get 
            {
                return array.Length;
            }
        }
    }
    class MainApp
    {
        static void Main(string[] args)
        {
            MyList<string> strList = new MyList<string>();
            strList[0] = "abc";
            strList[1] = "def";
            strList[2] = "ghi";
            strList[3] = "jkl";
            strList[4] = "mno";

            for (int i = 0; i < strList.Length; i++)
            {
                Console.WriteLine(strList[i]);
            }

            Console.WriteLine();

            MyList<int> intList = new MyList<int>();
            intList[0] = 0;
            intList[1] = 1;
            intList[2] = 2;
            intList[3] = 3;
            intList[4] = 4;

            for (int i = 0; i < intList.Length; i++)
            {
                Console.WriteLine(intList[i]);
            }


        }
    }
}
