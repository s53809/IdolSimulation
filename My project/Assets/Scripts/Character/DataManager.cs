using System;
using UnityEngine;
using System.IO;
using Unity.VisualScripting;
using System.Data;

public class DataManager : MonoBehaviour
{
    private static DataManager m_instance;
    public static DataManager Instance
    {
        get
        {
            try
            {
                return m_instance;
            }
            catch (Exception e)
            {
                Debug.Log(e);
                return null;
            }
        }
    }

    private SavedData data;
    private string path;

    public SavedData GetData()
    {
        JsonLoad();
        return data;
    }

    private void Awake()
    {
        if (m_instance != null) Destroy(this.gameObject);
        m_instance = this;
        DontDestroyOnLoad(this.gameObject);

        path = Path.Combine(Application.dataPath, "database.json");
        Debug.Log(path);

        JsonLoad();

    }
    public void JsonLoad()
    {
        if (!File.Exists(path))
        {
            data = new SavedData();
            JsonSave();
        }
        string loadJson = File.ReadAllText(path);
        data = JsonUtility.FromJson<SavedData>(loadJson);
    }

    public void JsonSave()
    {
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(path, json);
    }


}
