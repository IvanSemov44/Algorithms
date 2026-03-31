# Algorithms & Data Structures

C# implementations of algorithms and data structures, organized from fundamentals to advanced topics, plus ongoing interview practice.

## Structure

```
Algorithms/
├── AlgorithmsFundamentals/     # Core algorithms course
├── AlgorithmsAdvanced/         # Advanced algorithms course
└── ProblemSolving/             # Interview practice (LeetCode, Codewars, HackerRank)
    ├── LeetCode/
    │   ├── Easy/
    │   ├── Medium/
    │   └── Hard/
    ├── Codewars/
    └── HackerRank/
```

## AlgorithmsFundamentals

| Project | Topics |
|---|---|
| RecursionAndBacktracking | Fibonacci, Factorial, 8 Queens, Maze pathfinding |
| CombinatorialProblems | Permutations, Combinations, Variations with/without repetition |
| SearchingSortingAndGreedyAlgorithms | Binary Search, Bubble/Merge/Quick Sort, Greedy, Set Cover |
| GraphTheoryTraversalAndShortest | DFS, BFS, Shortest path (unweighted) |
| IntroductionToDynamicProgramming | Memoization, LCS, Subset Sum, Move Down-Right |
| ExamPreparation | Mixed practice |

## AlgorithmsAdvanced

| Project | Topics |
|---|---|
| GraphsDijkstraMST | Dijkstra, Prim's MST, Kruskal's MST |
| GraphsBellmanFordAndLongestPathinDAG | Bellman-Ford, Longest path in DAG |
| GraphsStronglyConnectedComponentsMaxFlow | Kosaraju/Tarjan SCC, Max Flow |
| DynamicProgrammingAdvanced | 0-1 Knapsack, LIS, Rod Cutting |
| ExamPreparationAdvance | Mixed advanced practice |

## ProblemSolving — LeetCode

Each file follows this format:

```csharp
// LeetCode #N - Problem Name
// Difficulty: Easy/Medium/Hard | Time: O(...) | Space: O(...)
// Approach: one-line explanation of the key insight
```

| # | Title | Difficulty | Time | Space |
|---|---|---|---|---|
| 1 | [Two Sum](ProblemSolving/LeetCode/Easy/0001_TwoSum.cs) | Easy | O(n) | O(n) |

## Tech Stack

- C# / .NET 8
- Console applications (no external test framework — run via `dotnet run`)
