using UnityEngine;
using System.Collections.Generic;

public class DFSSearch<TState>
{
    public int NodesExpanded { get; private set; }

    // maxDepth: to limit the search
    public List<TState> Solve(ISearchProblem<TState> problem, int maxDepth, int maxExpansions)
    {
        NodesExpanded = 0;

        Stack<SearchNode<TState>> frontier = new Stack<SearchNode<TState>>();
        HashSet<string> visited = new HashSet<string>();

        TState start = problem.GetInitialState();
        SearchNode<TState> root = new SearchNode<TState>(start, null, 0);

        frontier.Push(root);
        visited.Add(problem.GetKey(start));

        while (frontier.Count > 0)
        {
            if (NodesExpanded >= maxExpansions)
                break;

            SearchNode<TState> node = frontier.Pop();

            if (problem.IsGoal(node.State))
                return ReconstructPath(node);

            NodesExpanded++;

            if (node.Depth >= maxDepth)
                continue;

            List<TState> succ = problem.GetSuccessors(node.State);
            for (int i = 0; i < succ.Count; i++)
            {
                TState s = succ[i];
                string key = problem.GetKey(s);
                
                if (visited.Contains(key))  
                    continue;
                
                visited.Add(key);
                SearchNode<TState> child = new SearchNode<TState>(
                    s, node, node.Cost + problem.GetStepCost(node.State, s)
                );

                frontier.Push(child);
            }
        }

        return new List<TState>();
    }

    private List<TState> ReconstructPath(SearchNode<TState> goal)
    {
        List<TState> path = new List<TState>();
        SearchNode<TState> cur = goal;

        while (cur != null)
        {
            path.Add(cur.State);
            cur = cur.Parent;
        }

        path.Reverse();
        return path;
    }
}