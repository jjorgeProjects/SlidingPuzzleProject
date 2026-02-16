using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class BFSSearch<TState>
{
    public int NodesExpanded { get; private set; }

    public List<TState> Solve(ISearchProblem<TState> problem, int maxExpansions)
    {

        //FIFO (Queue)
        Queue<SearchNode<TState>> frontier = new Queue<SearchNode<TState>>();
        HashSet<string> visited = new HashSet<string>();
        TState start = problem.GetInitialState();
        SearchNode<TState> root = new SearchNode<TState>(start, null, 0);

        frontier.Enqueue(root);
        visited.Add(problem.GetKey(start));

        while (frontier.Count > 0)
        {
            SearchNode<TState> node = frontier.Dequeue();
            if (problem.IsGoal(node.State))
                
            if (problem.IsGoal(node.State))
            {
                return ReconstructPath(node);
            }

            NodesExpanded++;

            
            if (NodesExpanded > maxExpansions)
                return new List<TState>();

            List<TState> successors = problem.GetSuccessors(node.State);

            for (int i = 0; i < successors.Count; i++)
            {
                TState s = successors[i];
                string key = problem.GetKey(s);

                if (visited.Contains(key))
                    continue;

                visited.Add(key);

                SearchNode<TState> child = new SearchNode<TState>(s, node, node.Cost + 1);

                frontier.Enqueue(child);
            }

        }

        return new List<TState>(); // no solution
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
