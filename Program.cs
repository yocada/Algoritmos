using EstructurasDatosAvanzadas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var grafoDirigido = new GrafoDirigido<int>();
            for (int i = 1; i <= 7; i++)
            {
                grafoDirigido.addVertice(i);
            }
            grafoDirigido.addArista(1, 2, 10);
            grafoDirigido.addArista(1, 5, 6);
            grafoDirigido.addArista(2, 4, 2);
            grafoDirigido.addArista(2, 3, 5);
            grafoDirigido.addArista(3, 4, 4);
            grafoDirigido.addArista(4, 1, 5);
            grafoDirigido.addArista(5, 6, 9);
            grafoDirigido.addArista(5, 7, 1);
            grafoDirigido.addArista(6, 3, 2);
            grafoDirigido.addArista(6, 4, 3);
            grafoDirigido.addArista(6, 7, 8);
            var tupla = Voraces.Dijkstra(grafoDirigido, 1);
            System.Diagnostics.Debug.WriteLine(Voraces.MostrarCaminoDijkstra(tupla, 1, 7));
        }
    }
}
