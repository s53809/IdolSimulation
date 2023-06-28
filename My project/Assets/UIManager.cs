using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject m_popUpUI;
    [SerializeField] private GameObject m_gangHwaUI;
    public void OnTwoPyo()
    {
        m_popUpUI.SetActive(!m_popUpUI.activeSelf);
    }

    public void ONGangHwa()
    {
        m_gangHwaUI.SetActive(!m_gangHwaUI.activeSelf);
    }

    public void OnTwoPyoCharacter(int num)
    {

    }
}
