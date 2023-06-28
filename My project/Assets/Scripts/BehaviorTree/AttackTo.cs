using MBT;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[MBTNode("Character/Attack To")]
[AddComponentMenu("")]
public class AttackTo : Leaf
{
    public TransformReference myObj;
    public TransformReference enemyObj;

    public override NodeResult Execute()
    {
        CharacterEntity myObject = myObj.Value.gameObject.GetComponent<CharacterEntity>();
        CharacterEntity enemyObject = enemyObj.Value.gameObject.GetComponent<CharacterEntity>();

        myObject.Attack();

        enemyObject.Damaged(myObject.damage);

        return NodeResult.success;
    }
}
