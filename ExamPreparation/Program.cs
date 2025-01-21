using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPreparation
{
    public class Program
    {
        private static Dictionary<string, List<string>> graph;
        private static Dictionary<string, int> dependencies;
        public static void Main(string[] args)
        {

            /*Algorithms Fundamentals with C# Exam - 24 July 2022https://judge.softuni.org/Contests/3585/Algorithms-Fundamentals-with-CSharp-Exam-24-July-2022
                //01. Trains https://judge.softuni.org/Contests/Practice/DownloadResource/23684
                //Train.Solution();

                //02. Conditional Expression Resolver https://judge.softuni.org/Contests/Practice/DownloadResource/23538
                //ConditionalExpressionResolver.Solution();

                //3. Guards https://judge.softuni.org/Contests/Practice/DownloadResource/23685
                //Guards.Solution();
            -------------------------------------------------*/

            /*Exam Preparation https://judge.softuni.org/Contests/2571/Exam-Preparation
                //01. Two Minutes to Midnight https://judge.softuni.org/Contests/Practice/DownloadResource/10139
                //TwoMinutesToMidnight.Solution();
            -------------------------------------------------*/

            TwoMinutesToMidnight.Solution();

            //var first = Console.ReadLine()
            //    .Split()
            //    .Select(int.Parse)
            //    .ToArray();

            //var second = Console.ReadLine()
            //    .Split()
            //    .Select(int.Parse)
            //    .ToArray();

            //var lcs = new int[first.Length + 1, second.Length + 1];
            //var result = new List<int>();

            //for (int r = 1; r < lcs.GetLength(0); r++)
            //{
            //    for (int c = 1; c < lcs.GetLength(1); c++)
            //    {
            //        if (first[r - 1] == second[c - 1])
            //        {
            //            lcs[r, c] = lcs[r - 1, c - 1] + 1;
            //            result.Add(first[r - 1]);
            //        }
            //        else
            //            lcs[r, c] = Math.Max(lcs[r, c - 1], lcs[r - 1, c]);
            //    }
            //}

            //Console.WriteLine(string.Join(" ", result));
            //Console.WriteLine(lcs[first.Length, second.Length]);


            //graph = ReadGraph();
            //dependencies = ExtractDependencies(graph);
            //var sorted = TopologicalSorted(dependencies);

            //Console.WriteLine(string.Join(" ", sorted));
        }

        private static List<string> TopologicalSorted(Dictionary<string, int> dependencies)
        {
            var sorted = new List<string>();

            while (dependencies.Count > 0)
            {
                var nodeToRemove = dependencies.FirstOrDefault(x => x.Value == 0).Key;

                if (nodeToRemove == null)
                    break;

                dependencies.Remove(nodeToRemove);
                sorted.Add(nodeToRemove);

                foreach (var child in graph[nodeToRemove])
                    dependencies[child] -= 1;
            }

            return sorted;
        }

        private static Dictionary<string, int> ExtractDependencies(Dictionary<string, List<string>> graph)
        {
            var result = new Dictionary<string, int>();

            foreach (var kvp in graph)
            {
                var node = kvp.Key;
                var children = kvp.Value;

                if (!result.ContainsKey(node))
                    result[node] = 0;

                foreach (var child in children)
                    if (!result.ContainsKey(child))
                        result[child] = 1;
                    else
                        result[child]++;
            }

            return result;
        }

        private static Dictionary<string, List<string>> ReadGraph()
        {
            var result = new Dictionary<string, List<string>>();

            while (true)
            {
                var parts = Console.ReadLine()
                    .Split("->", StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => x.Trim())
                    .ToArray();

                var key = parts[0];

                if (key == "End") break;

                if (parts.Length == 1)
                {
                    result[key] = new List<string>();
                }
                else
                {
                    var children = parts[1].Split().ToList();
                    result[key] = children;
                }
            }

            return result;
        }
    }
}
