
using System;

public class SlidingPuzzleManhattanHeuristic : IHeuristic<SlidingPuzzleState>
{
    private int size;

    public SlidingPuzzleManhattanHeuristic(int size)
    {
        this.size = size;
    }

    public int Estimate(SlidingPuzzleState state)
    {
        int h = 0;

        for (int i = 0; i < state.puzzle.Length; i++)
        {
            int value = state.puzzle[i];
            if (value == 0) continue;

            int currentRow = i / size;
            int currentCol = i % size;

            int goalIndex = value - 1;
            int goalRow = goalIndex / size;
            int goalCol = goalIndex % size;

            h += Math.Abs(currentRow - goalRow) +
                 Math.Abs(currentCol - goalCol);
        }

        return h;
    }
}
