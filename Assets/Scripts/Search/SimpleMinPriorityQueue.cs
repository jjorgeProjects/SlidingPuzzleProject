
using System.Collections.Generic;

public class SimpleMinPriorityQueue
{
    private List<string> keys = new List<string>();
    private List<int> priorities = new List<int>();

    public int Count { get { return keys.Count; } }

    public void Enqueue(string key, int priority)
    {
        keys.Add(key);
        priorities.Add(priority);
    }

    public string DequeueMin()
    {
        int best = 0;
        for (int i = 1; i < priorities.Count; i++)
            if (priorities[i] < priorities[best])
                best = i;

        string k = keys[best];
        keys.RemoveAt(best);
        priorities.RemoveAt(best);
        return k;
    }
}
