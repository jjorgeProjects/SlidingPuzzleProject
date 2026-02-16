
using UnityEngine;
using System.Collections.Generic;

public class SlidingPuzzleDemo : MonoBehaviour
{
    public int size = 4; // 3 = 8-puzzle, 4 = 15-puzzle
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
        SlidingPuzzleProblem problem = new SlidingPuzzleProblem(initialState, size);
        BFSSearch<SlidingPuzzleState> bfs = new BFSSearch<SlidingPuzzleState>();

        List<SlidingPuzzleState> solutionBFS = bfs.Solve(problem, maxExpansions);

        if (solutionBFS.Count == 0)
        {
            Debug.Log("No hay solución.");
            Debug.Log($"Nodes expandidos: {bfs.NodesExpanded}");
            return;
        }

        Debug.Log("Solución encontrada en " + (solutionBFS.Count - 1) + " pasos:");
        for (int i = 0; i < solutionBFS.Count; i++)
        {

            Debug.Log("Paso " + i + ": State\n" + ShowPuzzle(solutionBFS[i]));
            ;
        }

        Debug.Log($"Nodes expandidos: {bfs.NodesExpanded}");
        Debug.Log("=================================");
        Debug.Log("=================================");
        Debug.Log("=================================");

        DFSSearch<SlidingPuzzleState> dfs = new DFSSearch<SlidingPuzzleState>();

        List<SlidingPuzzleState> solutionDFS = dfs.Solve(problem, 10000, 100000);

        if (solutionDFS.Count == 0)
        {
            Debug.Log("No hay solución.");
            Debug.Log($"Nodos expandidos: {dfs.NodesExpanded}");
            return;
        }

        Debug.Log("Solución encontrada en " + (solutionDFS.Count - 1) + " pasos:");
        for (int i = 0; i < solutionDFS.Count; i++)
        {
            Debug.Log("Paso " + i + ": State\n" + ShowPuzzle(solutionDFS[i]));
        }

        Debug.Log($"Nodos expandidos: {dfs.NodesExpanded}");
    }


    private string ShowPuzzle(SlidingPuzzleState state)
    {
        string message = "";
        for (int i = 0; i < state.puzzle.Length; i++)
        {
            message += state.puzzle[i] + " ";
            if (i % size != size - 1)
                message +=  "\n";
        }
        return message;
    }
}
