using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander : SteeringBehavior
{
    public float maxAAcceleration = 1;
    public Kinematic charachter;

    public override SteeringOutput getSteering()
    {

        SteeringOutput result = new SteeringOutput();
        Vector3 targetPos = getTargetPosition();

        result.linear = targetPos - charachter.transform.position;
        result.linear.Normalize();
        result.linear *= maxAAcceleration;
        result.angular = 0;

        return result;
    }

    public virtual Vector3 getTargetPosition()
    {
        return new Vector3(Random.Range(-5, 5), 0, Random.Range(-5, 5));
    }
}
