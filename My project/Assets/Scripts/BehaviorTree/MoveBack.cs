using MBT;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[MBTNode("Character/Move Backs")]
[AddComponentMenu("")]
public class MoveBack : Leaf
{
    public TransformReference transformToMove;
    public TransformReference enemyTarget;
    public float speed = 0.2f;
    public float time = 0;
    public float runTime = 2f;

    public override void OnEnter()
    {
        this.time = Time.time;
        Debug.Log(time);
    }
    public override NodeResult Execute()
    {
        if (enemyTarget.Value == null) return NodeResult.success;

        Transform obj = transformToMove.Value;
        Transform target = enemyTarget.Value;

        Vector3 dir = target.position - obj.position;
        dir = dir.normalized * speed * -1;

        if (time + runTime > Time.time)
        {
            obj.GetComponent<CharacterEntity>().SetWalk(true);
            if (dir.x < 0) obj.localScale
                    = new Vector3(Mathf.Abs(obj.localScale.x), obj.localScale.y, obj.localScale.z);
            else obj.localScale = new Vector3(-Mathf.Abs(obj.localScale.x), obj.localScale.y, obj.localScale.z);
            obj.position += dir * Time.deltaTime;

            return NodeResult.running;
        }
        else
        {
            obj.GetComponent<CharacterEntity>().SetWalk(false);
            return NodeResult.success;
        }
    }
}
