using MBT;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(MonoBehaviourTree))]
public class MBTExecute : MonoBehaviour
{
    private MonoBehaviourTree monoBehaviourTree;

    private void Awake()
    {
        monoBehaviourTree = GetComponent<MonoBehaviourTree>();
    }

    private void Update()
    {
        monoBehaviourTree.Tick();
    }
}
