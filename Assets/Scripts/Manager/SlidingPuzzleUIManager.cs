using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class SlidingPuzzleUIManager : MonoBehaviour
{
    [Header("UI")]
    public Transform gridParent;
    public GameObject tilePrefab;
    public Button solveButton;
    public TMP_Text infoText;

    [Header("Puzzle Settings")]
    public int size = 4; // 3 = 8-puzzle
    public int maxExpansions = 200000;

    private int[] currentState;
    private List<GameObject> tiles = new List<GameObject>();

    private SlidingPuzzleProblem problem;
    private SlidingPuzzleManhattanHeuristic heuristic;
    private AStarSearch<SlidingPuzzleState> astar;

    void Start()
    {
        if (solveButton == null)
        {
            Debug.LogError("SolveButton NO asignado en el Inspector.");
        }
        else
        {
            solveButton.onClick.RemoveAllListeners();
            solveButton.onClick.AddListener(Solve);
            Debug.Log("Listener conectado: Solve");
        }
        InitializePuzzle();

    }

    void InitializePuzzle()
    {
        // Estado inicial ejemplo
        currentState = new int[]
        {
            1,0,3,4,
            5,6,7,8,
            9,10,11,12,
            13,2,14,15
        };
        SlidingPuzzleState initialState = new SlidingPuzzleState(currentState);
        problem = new SlidingPuzzleProblem(initialState, size);
        heuristic = new SlidingPuzzleManhattanHeuristic(size);
        astar = new AStarSearch<SlidingPuzzleState>();

        CreateGrid();
        DrawState(currentState);
    }

    void CreateGrid()
    {
        foreach (Transform child in gridParent)
            Destroy(child.gameObject);

        tiles.Clear();

        for (int i = 0; i < size * size; i++)
        {
            GameObject tile = Instantiate(tilePrefab, gridParent);
            tiles.Add(tile);
        }
    }

    void DrawState(int[] state)
    {
        for (int i = 0; i < state.Length; i++)
        {
            TMP_Text txt = tiles[i].GetComponentInChildren<TMP_Text>();

            if (state[i] == 0)
            {
                txt.text = "";
                tiles[i].GetComponent<Image>().color = Color.gray;
            }
            else
            {
                txt.text = state[i].ToString();
                tiles[i].GetComponent<Image>().color = Color.white;
            }
        }
    }

    void Solve()
    {
        infoText.text = "Solving...";

        List<SlidingPuzzleState> path = astar.Solve(problem, heuristic, maxExpansions);

        if (path.Count == 0)
        {
            infoText.text = "No solution.";
            return;
        }

        infoText.text = "Steps: " + (path.Count - 1) +
                        " | Expanded: " + astar.NodesExpanded;

        StartCoroutine(AnimateSolution(path));
    }

    IEnumerator AnimateSolution(List<SlidingPuzzleState> path)
    {
        for (int i = 0; i < path.Count; i++)
        {
            currentState = path[i].puzzle;
            DrawState(currentState);
            yield return new WaitForSeconds(0.5f);
        }
    }
}