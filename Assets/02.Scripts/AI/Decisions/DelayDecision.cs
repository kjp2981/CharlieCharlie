using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayDecision : AIDecision
{
    public override bool MakeADecision()
    {
        return _enemyBrain.DelayTime <= 0;
    }
}
