using System;
using System.Collections.Generic;

namespace _133
{
    public class Program
    {
        static void Main(string[] args)
        {
            IDictionary<int, Node> dic = new Dictionary<int, Node>();
            // build graph
            int[,] graph = {{2,4},{1,3},{2,4},{1,3}};
            int[,] graph2 = {{2}, {1}};
            Node h = BuildGraphHelper(graph2, dic);
            //Node h =
            foreach(KeyValuePair<int, Node> k in dic)
            {
                Console.Write($"node val = {k.Key} ");
                foreach(var neighbor in k.Value.neighbors)
                {
                    Console.Write($"neighbor is {neighbor.val}\t");
                }
                Console.WriteLine();
            }
        }

        public static Node BuildGraphHelper(int[,] graph, IDictionary<int, Node> dic)
        {
            if (graph.Length == 0)
            {
                return null;
            }
            return BuildGraph(graph, 1, dic);
        }

        public static Node BuildGraph(int[,] graph, int val, IDictionary<int, Node> dic)
        {
            if (dic.TryGetValue(val, out Node n))
            {
                return n;
            }
            Node newN = new Node(val);
            dic.Add(val, newN);
            for (int i = 0; i < graph.GetLength(1); i ++)
            {
                // remove first element in graph
                //var newGraph = graph.ToList().Where((g, index) => index != 0).ToArray();
                var newGraph = RemoveFirst(graph);
                newN.neighbors.Add(BuildGraph(newGraph, graph[0, i], dic));
            }
            return newN;
        }
        public static int[,] RemoveFirst(int[,] graph)
        {
            if(graph.Length <= 1) return new int[,]{{}};
            int[,] newGraph = new int[graph.GetLength(0)-1, graph.GetLength(1)];
            for (int i = 1; i < graph.GetLength(0); i ++)
            {
                for (int j = 0; j < graph.GetLength(1); j ++)
                {
                    newGraph[i-1, j] = graph[i, j];
                }
            }
            return newGraph;
        }
    }


    public class Node
    {
        public int val;
        public IList<Node> neighbors {get;set;}
        public Node(int val)
            : this(val, new List<Node>())
        {}
        public Node()
            : this(0)
        {}

        public Node(int val, List<Node> neighbors)
        {
            this.val = val;
            this.neighbors = neighbors;
        }
    }
}
