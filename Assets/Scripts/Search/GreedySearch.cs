
using System.Collections.Generic;

public class GreedySearch<TState>
{
    public int NodesExpanded { get; private set; }

    public List<TState> Solve(ISearchProblem<TState> problem, IHeuristic<TState> heuristic, int maxExpansions)
    {
        NodesExpanded = 0;

        SimpleMinPriorityQueue open = new SimpleMinPriorityQueue();

        Dictionary<string, string> cameFrom = new Dictionary<string, string>();
        Dictionary<string, TState> states = new Dictionary<string, TState>();
        HashSet<string> closed = new HashSet<string>();

        TState start = problem.GetInitialState();
        string startKey = problem.GetKey(start);

        states[startKey] = start;
        cameFrom[startKey] = null;

        open.Enqueue(startKey, heuristic.Estimate(start));

        while (open.Count > 0 && NodesExpanded < maxExpansions)
        {
            string currentKey = open.DequeueMin();
            if (closed.Contains(currentKey)) continue;

            TState current = states[currentKey];

            if (problem.IsGoal(current))
                return Reconstruct(currentKey, cameFrom, states);

            closed.Add(currentKey);
            NodesExpanded++;

            foreach (TState next in problem.GetSuccessors(current))
            {
                string nk = problem.GetKey(next);
                if (closed.Contains(nk)) continue;

                if (!states.ContainsKey(nk))
                {
                    states[nk] = next;
                    cameFrom[nk] = currentKey;
                    open.Enqueue(nk, heuristic.Estimate(next));
                }
            }
        }

        return new List<TState>();
    }

    private List<TState> Reconstruct(string goalKey, Dictionary<string, string> cameFrom, Dictionary<string, TState> states)
    {
        List<TState> path = new List<TState>();
        for (string cur = goalKey; cur != null; cur = cameFrom[cur])
            path.Add(states[cur]);

        path.Reverse();
        return path;
    }
}
