using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class WaterJarsDemo : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int maxExpansions = 200000;

    public int capacityA = 4;
    public int capacityB = 3;
    public int target = 1;


    

    void Start()
    {

    

        Debug.Log("Problema de las jarras, A= " + capacityA + ", B= " + capacityB + ", objetivo = " + target);

        Debug.Log("=================================");
        Debug.Log("===========BFS===================");
        Debug.Log("=================================");
        WaterJarsProblem problem = new WaterJarsProblem(capacityA, capacityB, target);

        BFSSearch<WaterJarsState> bfs = new BFSSearch<WaterJarsState>();

        List<WaterJarsState> solutionBFS = bfs.Solve(problem, maxExpansions);

        if (solutionBFS.Count == 0)
        {
            Debug.Log("No hay solución.");
            return;
        }

        Debug.Log("Solución encontrada en " + (solutionBFS.Count - 1) + " pasos:");
        for (int i = 0; i < solutionBFS.Count; i++)
        {
            Debug.Log("Paso " + i + ": A=" + solutionBFS[i].A + " B=" + solutionBFS[i].B);
        }

        Debug.Log($"Nodes Expanded: {bfs.NodesExpanded}");
        Debug.Log("=================================");
        Debug.Log("=============DFS=================");
        Debug.Log("=================================");

        DFSSearch<WaterJarsState> dfs = new DFSSearch<WaterJarsState>();

        List<WaterJarsState> solutionDFS = dfs.Solve(problem, 10, 10);

        if (solutionDFS.Count == 0)
        {
            Debug.Log("No hay solución.");
            return;
        }

        Debug.Log("Solución encontrada en " + (solutionDFS.Count - 1) + " pasos:");
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
