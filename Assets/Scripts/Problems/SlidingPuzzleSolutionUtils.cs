
using System.Collections.Generic;
using UnityEngine;

public static class SlidingPuzzleSolutionUtils
{
    public static void LogSolution(List<SlidingPuzzleState> path, string label, int size)
    {
        if (path == null || path.Count == 0)
        {
            Debug.Log(label + ": (sin solución)");
            return;
        }

        Debug.Log(label + ": solución en " + (path.Count - 1) + " pasos");

        for (int i = 0; i < path.Count; i++)
        {
            Debug.Log("Paso " + i + ":\n" + Pretty(path[i], size));
        }
    }

    public static string Pretty(SlidingPuzzleState s, int size)
    {
        string t = "";
        for (int i = 0; i < s.puzzle.Length; i++)
        {
            if (s.puzzle[i] == 0) t += "_";
            else t += s.puzzle[i].ToString();

            if (i % size != size - 1) t += " ";
            else t += "\n";
        }
        return t;
    }
}
