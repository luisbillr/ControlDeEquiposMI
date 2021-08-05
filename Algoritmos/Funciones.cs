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
    }
}
