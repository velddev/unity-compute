using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockNode : FunctionNode {

    public float clockInterval = 1.0f;

    public override void Run()
    {
        if (!IsInvoking("InvertClock"))
        {
            Invoke("InvertClock", clockInterval);
        }
    }

    private void InvertClock()
    {
        canRun = true;
    }
}
