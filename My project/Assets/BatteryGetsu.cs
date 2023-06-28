using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatteryGetsu : MonoBehaviour
{
    public static BatteryGetsu Instance;
    void Start()
    {
        Instance = this;
        GetComponent<Text>().text = DataManager.Instance.GetData().zaehwa.ToString();
    }

    
}
