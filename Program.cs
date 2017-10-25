using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ca
{
    class Program
    {
        static void Main()
        {
            var input = File.ReadLines("in.txt");
            var vertexes = input
                .Where(s => !string.IsNullOrWhiteSpace(s))
                .Skip(1)
                .Select(line => line.Split().Select(int.Parse).ToArray())
                .Select((a, i) => new Vertex(i + 1, a[0], a[1]))
                .ToArray();

            var edges = vertexes
                .SelectMany(v1 => vertexes.Select(v2 => new Edge(v1, v2)))
                .Where(e => e.Weight != 0)
                .ToArray();

            var result = Mst(vertexes, edges);
            var output = result.ToOutput();
            File.WriteAllText("out.txt", output);
        }

        private static List<Edge> Mst(Vertex[] vertexes, Edge[] edges)
        {
            var name = new int[vertexes.Length + 1];
            var next = new int[vertexes.Length + 1];
            foreach (var v in vertexes)
            {
                name[v.Number] = v.Number;
                next[v.Number] = v.Number;
            }
            Array.Sort(edges, new EdgeComparer());
            var edgesQueue = new Queue<Edge>(edges);

            var result = new List<Edge>();
            while (result.Count != vertexes.Length - 1)
            {
                var e = edgesQueue.Dequeue();
                var p = name[e.From.Number];
                var q = name[e.To.Number];
                if (p != q)
                {
                    Merge(e.From, e.To, p, name, next);
                    result.Add(e);
                }
            }

            return result;
        }

        private static void Merge(Vertex v, Vertex w, int p, int[] name, int[] next)
        {
            name[w.Number] = p;
            var u = next[w.Number];
            while(name[u] != p)
            {
                name[u] = p;
                u = next[u];
            }

            SwapNext(v, w, next);
        }

        private static void SwapNext(Vertex v, Vertex w, int[] next)
        {
            var temp = next[v.Number];
            next[v.Number] = next[w.Number];
            next[w.Number] = temp;
        }
    }
}
