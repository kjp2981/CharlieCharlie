using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleAction : AIAction
{
    public override void TakeAction()
    {
        _aiMovementData.direction = Vector2.zero;
        _aiMovementData.pointOfInterest = transform.position;
        _enemyBrain.Move(_aiMovementData.direction, _aiMovementData.pointOfInterest);

        if(_enemyBrain.DelayTime > 0)
        {
            _enemyBrain.DelayTime -= Time.deltaTime;
            if (_enemyBrain.DelayTime < 0)
            {
                _enemyBrain.DelayTime = 0f;
            }
        }
        
    }
}
