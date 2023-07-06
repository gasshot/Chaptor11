using System;

namespace ConstantOnTypeParameters
{
    class StructArray<T> where T : struct // 형식 매개변수 구조체로 제한
    { 
    public T[] Array { get; set; } // 프로퍼티
        public StructArray(int size) // 생성자
        {
            Array = new T[size];
        }
    }

    class RefArray<T> where T : class // 형식 매개변수 클래스로 제한
    {
        public T[] Array { get; set; } // 프로퍼티
        public RefArray(int size) // 생성자
        {
            Array = new T[size];
        }
    }

    class Base { }
    class Derived : Base { }
    class BaseArray<U> where U : Base // Base에 상속 받는 형식 매개변수 제한
    {
        public U[] Array { get; set; } // 프로퍼티
        public BaseArray(int size) // 생성자
        {
            Array = new U[size];
        }


        public void CopyArray<T>(T[] Source) where T : U
        {
            Source.CopyTo(Array, 0);
        }
    }

    class MainApp
    {
        public static T CreateInstance<T>() where T : new() // 
        {
            return new T();
        }
        static void Main(string[] args)
        {
            StructArray<int> a = new StructArray<int>(3);
            a.Array[0] = 0;
            a.Array[1] = 1;
            a.Array[2] = 2;

            StructArray<float> a1 = new StructArray<float>(3); // string은 참조형식이라 불가능함(테스트)
            a1.Array[0] = 0.5f;
            a1.Array[1] = 1;
            a1.Array[2] = 2;

            RefArray<string> a2 = new RefArray<string>(3);
            a2.Array[0] = "C#";
            a2.Array[1] = "노답";
            a2.Array[2] = "극혐";

            RefArray<StructArray<double>> b = new RefArray<StructArray<double>>(3);
            b.Array[0] = new StructArray<double>(5);
            b.Array[0].Array[0] = 0.5; // 테스트
            b.Array[0].Array[1] = 0.55; // 테스트
            b.Array[0].Array[2] = 0.555; // 테스트
            b.Array[1] = new StructArray<double>(10); // double타입 크기 10의 배열을 b.Array[1]
            b.Array[2] = new StructArray<double>(1005); // double타입 크기 1005의 배열을 b.Array[2]

            BaseArray<Base> c = new BaseArray<Base>(3);
            c.Array[0] = new Base(); // U 제한된 형식 매개변수 (Base)
            c.Array[1] = new Derived(); // Derived는 Base에 상속
            c.Array[2] = CreateInstance<Base>();

            BaseArray<Derived> d = new BaseArray<Derived>(3);
            d.Array[0] = new Derived();
            d.Array[1] = CreateInstance<Derived>();
            d.Array[2] = CreateInstance<Derived>();

            BaseArray<Derived> e = new BaseArray<Derived>(3);
            e.CopyArray<Derived>(d.Array);
        }
        
    }
}
