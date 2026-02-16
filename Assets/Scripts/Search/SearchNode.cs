using UnityEngine;

public class SearchNode<TState>
{
    public TState State;
    public SearchNode<TState> Parent;
    public int Cost;
    public int Depth;

    public SearchNode(TState state, SearchNode<TState> parent, int cost)
    {
        this.State = state;
        this.Parent = parent;
        this.Cost = cost;
        Depth = (parent == null) ? 0 : parent.Depth + 1;
    }
}
