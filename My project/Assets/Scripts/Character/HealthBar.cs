using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private float maxScale = 2;

    public void SetHealth(float curHealth, float maxHealth)
    {
        this.transform.localScale = new Vector3(curHealth / maxHealth * maxScale, 0.3f, 1);
    }
}
