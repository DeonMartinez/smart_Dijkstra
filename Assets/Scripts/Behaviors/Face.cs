using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Face : Align
{
    // TODO: override Align's getTargetAngle to face the target instead of matching it's orientation
    public override float getTargetAngle()
    {
        // --- replace me ---
        // float targetAngle = 0f;

        Vector3 targetVector = character.transform.position - target.transform.position;

        if (targetVector.magnitude == 0) 
        {
            return character.transform.eulerAngles.y;
        }
        float targetAngle = Mathf.Atan2(targetVector.x, targetVector.z);
        targetAngle = targetAngle * Mathf.Rad2Deg;
        // ------------------

        return targetAngle;
    }
}
