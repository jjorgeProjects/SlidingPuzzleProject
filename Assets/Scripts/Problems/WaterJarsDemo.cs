using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class WaterJarsDemo : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int maxExpansions = 200000;

    void Start()
    {
        WaterJarsProblem problem = new WaterJarsProblem(4, 3, 1);

        BFSSearch<WaterJarsState> bfs = new BFSSearch<WaterJarsState>();

        List<WaterJarsState> solutionBFS = bfs.Solve(problem, maxExpansions);

        if (solutionBFS.Count == 0)
        {
            Debug.Log("No hay soluci�n.");
            return;
        }

        Debug.Log("Soluci�n encontrada en " + (solutionBFS.Count - 1) + " pasos:");
        for (int i = 0; i < solutionBFS.Count; i++)
        {
            Debug.Log("Paso " + i + ": A=" + solutionBFS[i].A + " B=" + solutionBFS[i].B);
        }

        Debug.Log($"Nodes Expanded: {bfs.NodesExpanded}");
        Debug.Log("=================================");
        Debug.Log("=================================");
        Debug.Log("=================================");

        DFSSearch<WaterJarsState> dfs = new DFSSearch<WaterJarsState>();

        List<WaterJarsState> solutionDFS = dfs.Solve(problem, 10, 10);

        if (solutionDFS.Count == 0)
        {
            Debug.Log("No hay soluci�n.");
            return;
        }

        Debug.Log("Soluci�n encontrada en " + (solutionDFS.Count - 1) + " pasos:");
        for (int i = 0; i < solutionDFS.Count; i++)
        {
            Debug.Log("Paso " + i + ": A=" + solutionDFS[i].A + " B=" + solutionDFS[i].B);
        }

        Debug.Log($"Nodes Expanded: {dfs.NodesExpanded}");


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
