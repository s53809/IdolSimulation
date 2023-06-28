using MBT;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[MBTNode("Character/CheckDistance")]
[AddComponentMenu("")]
public class CheckDistance : Leaf
{
    public TransformReference myObj;
    public TransformReference enemyObj;
    public BoolReference isClose;
    public float dist;

    public override NodeResult Execute()
    {
        Transform myObject = myObj.Value;
        Transform enemyObject = enemyObj.Value;

        if (Vector3.Distance(enemyObject.position, myObject.position) < dist) isClose.Value = true;
        else isClose.Value = false;

        return NodeResult.success;
    }
}
