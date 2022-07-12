using EstructurasDatosAvanzadas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmos
{
    internal static class Voraces
    {
        public static Tuple<Dictionary<T, int>, Dictionary<T, T>> Dijkstra<T>(Grafo<T> grafo, T inicio)
        {
            var restoVertices = new Dictionary<int, T>();
            var x = 0;
            foreach(var vertice in grafo.vertices)
            {
                var elementoActual = vertice;
                if (!elementoActual.Equals(inicio))
                {
                    restoVertices.Add(x, elementoActual);
                    x++;
                }
            }

            var especial = new Dictionary<T,int>();
            var predecesor = new Dictionary<T,T>();
            for (int i = 0; i < restoVertices.Count; i++)
            {
                var distancia = grafo.etiqueta(inicio, restoVertices[i]);
                distancia = distancia == 0 ? int.MaxValue : distancia;
                especial.Add(restoVertices[i],distancia);
                predecesor.Add(restoVertices[i], inicio);
            }

            while (restoVertices.Count > 1)
            {
                var distanciaMinima = int.MaxValue;
                var verticeMinimo = restoVertices.Values.First();
                var posicionMinima = 0;
                foreach (var v in restoVertices)
                {
                    if (especial[v.Value] < distanciaMinima)
                    {
                        distanciaMinima = especial[v.Value];
                        verticeMinimo = restoVertices[v.Key];
                        posicionMinima = v.Key;
                    }
                }
                restoVertices.Remove(posicionMinima);

                foreach (var v in restoVertices)
                {
                    var distancia = grafo.etiqueta(verticeMinimo, v.Value);
                    distancia = distancia == 0 ? int.MaxValue : distancia;
                    if (distancia < int.MaxValue && especial[v.Value] > especial[verticeMinimo] + distancia)
                    {
                        especial[v.Value] = especial[verticeMinimo] + distancia;
                        predecesor[v.Value] = verticeMinimo;
                    }
                }
            }

            var res = new Tuple<Dictionary<T, int>, Dictionary<T, T>>(especial,predecesor);
            return res;
        }

        public static string MostrarCaminoDijkstra<T>(Tuple<Dictionary<T, int>, Dictionary<T, T>> tupla, T inicio, T fin)
        {
            var listaRes = new List<string>();
            var antecesor = tupla.Item2[fin];
            var textoDestino = fin.ToString();
            while (!antecesor.Equals(inicio))
            {
                listaRes.Insert(0, "," + antecesor.ToString() + " -> " + textoDestino);
                textoDestino = antecesor.ToString();
                antecesor = tupla.Item2[antecesor];
            }

            listaRes.Insert(0, inicio.ToString() + " -> " + textoDestino);

            var res = "Camino desde " + inicio.ToString() + " hasta " + fin.ToString() + ":";
            foreach(var s in listaRes)
            {
                res += s;
            }
            return res;
        }
    }
}
