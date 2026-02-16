using UnityEngine;

public class SlidingPuzzleState
{
    public int[] puzzle;
    public int size;
    public SlidingPuzzleState(int[] state, int size)
    {
        this.size = size;
        puzzle = new int[state.Length];
        for (int i = 0; i < state.Length; i++)
            puzzle[i] = state[i];
    }

    public SlidingPuzzleState(int[] state)
    {
        this.size = state.Length;
        puzzle = new int[state.Length];
        for (int i = 0; i < state.Length; i++)
            puzzle[i] = state[i];
    }


}
