using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmos
{
    public class Funciones
    {
        public static object Algoritmo1(List<int>[] arrayList)
        {

            List<int> ListaNumeros = new List<int>();
            List<int> ListaMasLarga = new List<int>();
            var a = arrayList.Max(m => m.Count);
            object datos = new object();
            foreach (var item in arrayList)
            {
                if (item.Count() == a)
                {
                    ListaMasLarga = item;
                }
                ListaNumeros.Add(item.Max());
            }
            datos = new
            {
                ListaMasLarga = ListaMasLarga,
                NumeroMayor = ListaNumeros.Max()
            };
            return datos;
        }
        public static object Algoritmo2(int Numero)
        {
            List<int> ListaNumeros = new List<int>();
            object datos = new object();
            int  a = 0, tmp = 0, b = 0;
            Console.WriteLine("Introduzca un numero");
            b = Numero;
            for (int i = -1; i < 5; i++)
            {
                ListaNumeros.Add(a);
                Console.WriteLine(a);
                tmp = a + b;
                a = b;
                b = tmp;
               ;
            }
            return new { Datos = ListaNumeros };
        }
    }
}
