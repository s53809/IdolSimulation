using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EntityController : MonoBehaviour
{
    public abstract void MoveCharacter(Vector3 goalPos);
}
