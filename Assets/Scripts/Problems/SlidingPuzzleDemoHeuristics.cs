
using UnityEngine;
using System.Collections.Generic;

public class SlidingPuzzleDemoHeuristics : MonoBehaviour
{
    public int size = 3; // 3 = 8-puzzle, 4 = 15-puzzle
    public int maxExpansions = 200000;

    void Start()
    {
      
        int[] initial;

        if(size == 3){
        
            initial = new int[]
            {
                1,2,3,
                4,0,6,
                7,5,8
            };
        }
        else
        {
            /*
            initial = new int[]
            {
                1,2,3,4,
                5,6,7,8,
                9,10,11,12,
                13,0,14,15
            };
            */
            
            initial = new int[]
            {
                1,2,3,4,
                5,0,15,8,
                9,10,11,12,
                13,6,14,7
            };

            
        }

        SlidingPuzzleState initialState = new SlidingPuzzleState(initial);
        SlidingPuzzleProblem problem_manhattan = new SlidingPuzzleProblem(initialState, size);
        
        SlidingPuzzleManhattanHeuristic h_manhattan = new SlidingPuzzleManhattanHeuristic(size);

        AStarSearch<SlidingPuzzleState> astar = new AStarSearch<SlidingPuzzleState>();
        List<SlidingPuzzleState> path_manhattan = astar.Solve(problem_manhattan, h_manhattan, maxExpansions);

        SlidingPuzzleSolutionUtils.LogSolution(path_manhattan, "A* (Manhattan)", size);
        Debug.Log("Expandidos: " + astar.NodesExpanded);

        SlidingPuzzleProblem problem_misplaced = new SlidingPuzzleProblem(initialState, size);

        SlididingPuzzleMisplacedHeuristic h_misp = new SlididingPuzzleMisplacedHeuristic(size);

        List<SlidingPuzzleState> path_misp = astar.Solve(problem_misplaced, h_misp, maxExpansions);

        SlidingPuzzleSolutionUtils.LogSolution(path_misp, "A* (Misplaced)", size);
        Debug.Log("Expandidos: " + astar.NodesExpanded);
    }

    private string ShowPuzzle(SlidingPuzzleState state)
    {
        string message = "";
        for (int i = 0; i < state.puzzle.Length; i++)
        {
            message += state.puzzle[i] + " ";
            if ((size == 3 && i % size == 2) || (size == 4 && i % size == 3))
                message +=  "\n";
        }
        return message;
    }
}
