namespace Algorithms.Chapter_6
{
    public class BreadthFirstSearch
    {
        public static bool FindMangoSellerInGraph()
        {
            var queueSearch = new Queue<string>();
            HashSet<string> verified = [];

            var graph = CreateGraph();

            AddItemInQueueSearch(queueSearch, graph["you"]);

            while (queueSearch.Count > 0)
            {
                var name = queueSearch.Dequeue();

                if (!verified.Contains(name))
                {
                    if (IsSeller(name))
                    {
                        Console.WriteLine($"{name} is a mango seller");
                        return true;
                    }
                    else
                    {
                        AddItemInQueueSearch(queueSearch, graph[name]);
                        verified.Add(name);
                    }
                }
            }
            return false;
        }

        public static void ShowGraph()
        {
            var graph = CreateGraph();

            foreach (var node in graph)
            {
                Console.WriteLine($"{node.Key} -> {string.Join(", ", node.Value)}");
            }
        }

        public static List<string>? FindShortesPath(string origin, string destination)
        {
            var graph = CreateGraph();
            var verified = new HashSet<string>();
            var queueSearch = new Queue<List<string>>();

            queueSearch.Enqueue([origin]);
            verified.Add(origin);

            while (queueSearch.Count > 0)
            {
                var currentPath = queueSearch.Dequeue();
                var lastNode = currentPath[^1];

                if (lastNode == destination)
                {
                    return currentPath;
                }

                foreach (var adjacentNode in graph[lastNode])
                {
                    if (!verified.Contains(adjacentNode))
                    {
                        queueSearch.Enqueue(new List<string>(currentPath) { adjacentNode });
                        verified.Add(adjacentNode);
                    }
                }
            }

            return null;
        }
        private static Dictionary<string, List<string>> CreateGraph()
        {
            var graph = new Dictionary<string, List<string>>();

            AddEdge(graph, "you", "alice");
            AddEdge(graph, "you", "bob");
            AddEdge(graph, "you", "claire");
            AddEdge(graph, "bob", "anuj");
            AddEdge(graph, "bob", "peggy");
            AddEdge(graph, "alice", "peggy");
            AddEdge(graph, "claire", "thom");
            AddEdge(graph, "claire", "jonny");
            AddEdge(graph, "anuj", string.Empty);
            AddEdge(graph, "peggy", string.Empty);
            AddEdge(graph, "thom", string.Empty);
            AddEdge(graph, "jonny", string.Empty);

            return graph;
        }

        private static void AddItemInQueueSearch(Queue<string> queueSearch, List<string> listName)
        {
            foreach (var name in listName)
            {
                queueSearch.Enqueue(name);
            }
        }

        private static bool IsSeller(string name)
        {
            if (name[^1].ToString() == "m") return true;

            return false;
        }

        private static void AddEdge(Dictionary<string, List<string>> graph, string origin, string destination, bool isUndirected = false)
        {
            if (!graph.ContainsKey(origin))
            {
                graph[origin] = [];
            }

            graph[origin].Add(destination);

            if (isUndirected)
            {
                if (!graph.ContainsKey(destination))
                {
                    graph[destination] = [];
                }

                graph[destination].Add(origin);
            }
        }
    }
}
