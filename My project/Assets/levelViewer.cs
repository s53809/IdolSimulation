using UnityEngine;
using UnityEngine.UI;

public class levelViewer : MonoBehaviour
{
    public void Start()
    {
        transform.GetChild(0).GetComponent<Text>().text = DataManager.Instance.GetData().level.ToString();
    }
}
