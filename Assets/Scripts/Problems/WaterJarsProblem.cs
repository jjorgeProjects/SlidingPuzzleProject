using System.Collections.Generic;
using UnityEngine;

public class WaterJarsProblem : ISearchProblem<WaterJarsState>
{
    public int capA;
    public int capB;
    public int targetAmount;


    public WaterJarsProblem(int capA, int capB, int targetAmount)
    {
        this.capA = capA;
        this.capB = capB;
        this.targetAmount = targetAmount;
    }
    public WaterJarsState GetInitialState()
    {
        return new WaterJarsState(0, 0);
    }

    public string GetKey(WaterJarsState state)
    {
        return state.A + "," + state.B;
    }

    public List<WaterJarsState> GetSuccessors(WaterJarsState state)
    {
        List<WaterJarsState> succ = new List<WaterJarsState>();

        //1. Llenar A
        succ.Add(new WaterJarsState(capA, state.B));
        //2. Llenar B
        succ.Add(new WaterJarsState(state.A, capB));
        //3. Vaciar A
        succ.Add(new WaterJarsState(0, state.B));
        //4. Vaciar B
        succ.Add(new WaterJarsState(state.A, 0));
        //5. Verter A -> B
        int pourAB = System.Math.Min(state.A, capB - state.B);
        succ.Add(new WaterJarsState(state.A - pourAB, state.B + pourAB));
        //6. Verter B -> A
        int pourBA = System.Math.Min(state.B, capA - state.A);
        succ.Add(new WaterJarsState(state.A + pourBA, state.B - pourBA));

        return succ;
    }

    public int GetStepCost(WaterJarsState from, WaterJarsState to)
    {
        return 1;
    }

    public bool IsGoal(WaterJarsState state)
    {
        return targetAmount == state.A || targetAmount == state.B;
    }
}
