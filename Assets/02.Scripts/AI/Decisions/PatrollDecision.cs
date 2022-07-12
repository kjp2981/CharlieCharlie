using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollDecision : AIDecision
{
    public override bool MakeADecision()
    {
        return _enemyBrain.target.GetComponent<Player>().IsBox;
    }
}
