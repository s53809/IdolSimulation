using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Mono.Data.Sqlite;
using System.IO;
using UnityEngine.Networking;
using UnityEngine;

public class DBReader : MonoBehaviour
{
    private bool isAlreadyRunning = false;
    
    
    public void ReadDB(string path, string query, string[] items)
    {
        if (!isAlreadyRunning) StartCoroutine(DBCreate(path, query, items));
        else Debug.LogError("DB Query is already Running!");
    }

    
    private static DBReader _instance;
    public static DBReader Instance { 
        get {
            if (_instance == null)
            {
                throw new Exception("You don't have DBReader");
            }
            else { return _instance; }
        }
    }
    private void Awake()
    {
        if (_instance != null) Destroy(this.gameObject);
        else
        {
            DontDestroyOnLoad(this);
            _instance = this;
        }
    }
    
    private string GetDBFilePath(string path)
    {
        string str = string.Empty;
        if (Application.platform == RuntimePlatform.Android)
        {
            str = "URI=file:" + Application.persistentDataPath + path + ".db";
        }
        else
        {
            str = "URI=file:" + Application.dataPath + path + ".db";
        }
        return str;
    }

    private void DataBaseRead(string path, string query, string[] items)
    {
        IDbConnection dbConnection = new SqliteConnection(GetDBFilePath(path));
        dbConnection.Open();
        IDbCommand dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = query;
        IDataReader dataReader = dbCommand.ExecuteReader();
        while (dataReader.Read())
        {
            Debug.Log("첫번째 속성");
            foreach (var item in items)
            {
                Debug.Log($"{dataReader[item]} : {dataReader[item].GetType()}"); //Todo: 어떻게 데이터를 받아야할지 생각하기
            }
        }
        
        dataReader.Dispose();
        dataReader = null;
        dbCommand.Dispose();
        dbCommand = null;
        dbConnection.Dispose();
        dbConnection = null;
    }
    private IEnumerator DBCreate(string dbFilePath, string query, string[] items)
    {
        isAlreadyRunning = true;
        string filepath = string.Empty;
        string[] paties = dbFilePath.Split('/');
        string dbFileName = '/' + paties[paties.Length - 1];
        if (Application.platform == RuntimePlatform.Android)
        {
            filepath = Application.persistentDataPath + dbFileName + ".db";
            if (!File.Exists(filepath))
            {
                UnityWebRequest unityWebRequest
                    = UnityWebRequest.Get("jar:file//" + Application.dataPath + "!/assets" + dbFilePath + ".db");
                yield return unityWebRequest.SendWebRequest().isDone;
                File.WriteAllBytes(filepath, unityWebRequest.downloadHandler.data);
            }
        }
        else
        {
            filepath = Application.dataPath + dbFileName + ".db";
            if (!File.Exists(filepath))
            {
                File.Copy(Application.streamingAssetsPath + dbFilePath + ".db", filepath);
            }
            Debug.Log(filepath);
        }
        
        DataBaseRead(dbFileName, query, items);
        
        isAlreadyRunning = false;
    }
}
