using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Twopyo : MonoBehaviour
{
    public GameObject[] Crowns;
    private int finalIndex;

    public void OnClickButton(int index)
    {
        for(int i = 0; i < Crowns.Length; i++)
        {
            Crowns[i].SetActive(false);
        }
        Crowns[index].SetActive(true);
        finalIndex = index;
    }

    public void OnNagaButton()
    {
        DataManager.Instance.GetData().twopyoedCharacter = finalIndex;
        DataManager.Instance.JsonSave();
    }
}
