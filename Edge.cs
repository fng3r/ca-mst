using System;
using System.Collections.Generic;

namespace ca
{
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