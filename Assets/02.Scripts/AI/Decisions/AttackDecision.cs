using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDecision : AIDecision
{
    [SerializeField]
    private float attackRange = 1f;

    public override bool MakeADecision()
    {
        return Vector2.Distance(_enemyBrain.target.position, transform.position) <= attackRange;
    }
}
