
using System.Collections.Generic;

public class SlidingPuzzleProblem : ISearchProblem<SlidingPuzzleState>
{
    private SlidingPuzzleState initial;
    private SlidingPuzzleState goalState;
    private int size;

    public SlidingPuzzleProblem(SlidingPuzzleState initialState, int size)
    {
        this.size = size;
        initial = Copy(initialState);

        int[] goal = new int[size * size];
        
        for (int i = 0; i < goal.Length - 1; i++)
            goal[i] = i + 1;
        goal[goal.Length - 1] = 0;
        
        goalState = new SlidingPuzzleState(goal, size);

    }

    public SlidingPuzzleState GetInitialState()
    {
        return Copy(initial);
    }

    public bool IsGoal(SlidingPuzzleState state)
    {
        for (int i = 0; i < goalState.puzzle.Length; i++)
            if (state.puzzle[i] != goalState.puzzle[i])
                return false;
        return true;
    }

    public string GetKey(SlidingPuzzleState state)
    {
        string key = "";
        for (int i = 0; i < state.puzzle.Length; i++)
            key += state.puzzle[i].ToString() + ",";
        return key;
    }

    public int GetStepCost(SlidingPuzzleState from, SlidingPuzzleState to)
    {
        return 1;
    }

    public List<SlidingPuzzleState> GetSuccessors(SlidingPuzzleState state)
    {
        List<SlidingPuzzleState> successors = new List<SlidingPuzzleState>();

        int zeroIndex = FindZero(state);
        int row = zeroIndex / size;
        int col = zeroIndex % size;

        if (row > 0)
            successors.Add(Swap(state, zeroIndex, zeroIndex - size));
        if (row < size - 1)
            successors.Add(Swap(state, zeroIndex, zeroIndex + size));
        if (col > 0)
            successors.Add(Swap(state, zeroIndex, zeroIndex - 1));
        if (col < size - 1)
            successors.Add(Swap(state, zeroIndex, zeroIndex + 1));

        return successors;
    }

    private int FindZero(SlidingPuzzleState state)
    {
        for (int i = 0; i < state.puzzle.Length; i++)
            if (state.puzzle[i] == 0)
                return i;
        return -1;
    }

    private SlidingPuzzleState Swap(SlidingPuzzleState state, int i, int j)
    {
        SlidingPuzzleState copy = Copy(state);
        int temp = copy.puzzle[i];
        copy.puzzle[i] = copy.puzzle[j];
        copy.puzzle[j] = temp;
        return copy;
    }

    private SlidingPuzzleState Copy(SlidingPuzzleState state)
    {
        return new SlidingPuzzleState(state.puzzle);
    
    }
}
