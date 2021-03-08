using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evade : Seek 
{
    float maxPredictionTime = 1f;

    protected override Vector3 getTargetPosition()
    {
        flee = true;

        Vector3 directionToTarget = character.transform.position - target.transform.position;

        float distanceToTarget = directionToTarget.magnitude;
        float mySpeed = character.linearVelocity.magnitude;
        float predictionTime;

        if (mySpeed <= distanceToTarget / maxPredictionTime)
        {
            predictionTime = maxPredictionTime;
        }
        else
        {
            predictionTime = distanceToTarget / mySpeed;
        }

        Kinematic myMovingTarget = target.GetComponent<Kinematic>();
        if (myMovingTarget == null)
        {
            return base.getTargetPosition();
        }

        return (myMovingTarget.linearVelocity * predictionTime) - target.transform.position;
    }
}
