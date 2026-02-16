using UnityEngine;
public class SlididingPuzzleMisplacedHeuristic : IHeuristic<SlidingPuzzleState>
{
    private int[] goal;

    public SlididingPuzzleMisplacedHeuristic(int size)
    {
        goal = new int[size * size];
        
        for (int i = 0; i < goal.Length - 1; i++)
            goal[i] = i + 1;
        goal[goal.Length - 1] = 0;
    }

    public int Estimate(SlidingPuzzleState state)
    {
        int h = 0;

        for (int i = 0; i < goal.Length; i++)
        {
            if (state.puzzle[i] == 0) 
                continue;

            if (state.puzzle[i] != goal[i])
                h++;
        }

        return h;
    }
}