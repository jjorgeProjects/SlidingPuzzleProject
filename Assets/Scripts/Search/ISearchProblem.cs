using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public interface ISearchProblem<TState>
{
    TState GetInitialState();

    bool IsGoal(TState state); 

    List<TState> GetSuccessors(TState state);

    string GetKey(TState state);

    int GetStepCost(TState from, TState to);


}
