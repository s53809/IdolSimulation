using MBT;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[MBTNode("Character/Move Towards")]
[AddComponentMenu("")]
public class MoveTo : Leaf
{
    public TransformReference transformToMove;
    public TransformReference enemyTarget;
    public float speed = 0.2f;
    public float minDistance = 0.2f;

    public override NodeResult Execute()
    {
        if (enemyTarget.Value == null) return NodeResult.success;

        Transform obj = transformToMove.Value;
        Transform target = enemyTarget.Value;

        float dist = Vector3.Distance(obj.position, target.position);
        if(dist > minDistance)
        {
            obj.GetComponent<CharacterEntity>().SetWalk(true);
            if (obj.position.x - target.position.x < 0) obj.localScale 
                    = new Vector3(-Mathf.Abs(obj.localScale.x), obj.localScale.y, obj.localScale.z);
            else obj.localScale = new Vector3(Mathf.Abs(obj.localScale.x), obj.localScale.y, obj.localScale.z);
            obj.position 
                = Vector3.MoveTowards(obj.position, target.position,
                (speed * Time.deltaTime > dist) ? dist : speed * Time.deltaTime);

            return NodeResult.running;
        }
        else
        {
            obj.GetComponent<CharacterEntity>().SetWalk(false);
            return NodeResult.success;
        }
    }
}
