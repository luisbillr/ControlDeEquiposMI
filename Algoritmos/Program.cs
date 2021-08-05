using System;
using System.Collections.Generic;
using System.Linq;
using Algoritmos;
namespace Algoritmos
{
    class Program
    {
        static void Main(string[] args)
        {
            //List<int>[] arrayList = new List<int>[int.MaxValue];
            //arrayList[0] = new List<int> { 1, 2, 3 };
            //arrayList[1] = new List<int> { 4, 5, 6 };
            //arrayList[2] = new List<int> { 7, 8, 9 };
            // 1.Crear una función que reciba un arreglo de listas de enteros y retorne
            //tanto el número más alto que existe dentro de todas las listas como la lista
            //que contiene mayor cantidad de números.
            //------
            //2.Crear una función que dado un numero retorne los siguientes 5 números
            //utilizando el algoritmo Fibonacci(para el primer Fibonacci favor usar el
            //número dado menos 1 como numero anterior).
            //List<int>[] arrayList2 = new List<int>[3];
            //arrayList2[0] = new List<int> { 1, 2, 3 };
            //arrayList2[1] = new List<int> { 4, 5, 6 };
            //arrayList2[2] = new List<int> { 7, 8, 9, 12 };
            //Console.WriteLine("Introduzca un numero");
            // var a = Funciones.Algoritmo1(arrayList2);
            //Console.ReadKey();
            int numero = 0, a = 0, tmp = 0, b = 0;
            Console.WriteLine("Introduzca un numero");
            numero = Convert.ToInt32(Console.ReadLine());
            b = 1;
            for (int i = -1; i < numero; i++)
            {
                Console.WriteLine(a);
                tmp = a + b;
                a = b;
                b = tmp;
            }

        }

   
    }
}
