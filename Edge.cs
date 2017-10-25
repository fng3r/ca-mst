using System;
using System.Collections.Generic;
using System.Linq;

namespace ca
{
    public static class EdgeExtensions
    {
        private static readonly string newLine = Environment.NewLine;

        public static string ToOutput(this List<Edge> edges)
        {
            var adjacencyLists = new SortedList<int, int>[edges.Count + 2];
            for (int i = 0; i < adjacencyLists.Length; i++)
                adjacencyLists[i] = new SortedList<int, int>();

            foreach (var e in edges)
            {
                adjacencyLists[e.From.Number].Add(e.To.Number, e.To.Number);
                adjacencyLists[e.To.Number].Add(e.From.Number, e.From.Number);
            }

            return string.Join(
                       newLine, adjacencyLists
                           .Skip(1)
                           .Select(l => string.Join(" ", l.Values) + " 0")
                   ) + newLine + edges.Sum(e => e.Weight);
        }
    }

    public class EdgeComparer : IComparer<Edge>
    {
        public int Compare(Edge x, Edge y)
        {
            return x.Weight - y.Weight;
        }
    }

    public class Edge
    {
        public readonly Vertex From;
        public readonly Vertex To;
        public Edge(Vertex from, Vertex to)
        {
            From = from;
            To = to;
        }
        public int Weight
        {
            get 
            {
                return Math.Abs(From.X - To.X) + Math.Abs(From.Y - To.Y);
            }
        }

        public override string ToString()
        {
            return string.Format("{0} - {1} - {2}", From, To, Weight);
        }
    }
}