using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGanghwa : MonoBehaviour
{
    public void OnClickGanghwaButton(int i)
    {
        if(DataManager.Instance.GetData().zaehwa >= 500 * DataManager.Instance.GetData().characterStrengths[i])
        {
            DataManager.Instance.GetData().characterStrengths[i] += 1;
            DataManager.Instance.JsonSave();
        }
    }
}
