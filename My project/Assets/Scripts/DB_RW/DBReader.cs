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
    private bool _isAlreadyRunning = false;
    private List<DBData> _result;
    public List<DBData> ReadDB(string path, string query, string[] items)
    {
        if (!_isAlreadyRunning) {
            _result = new List<DBData>();
            StartCoroutine(DBCreate(path, query, items));
        }
        else {
            Debug.LogError("DB Query is already being run");
            return new List<DBData>();
        }
        

        return _result;
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
            DBData temp = new DBData();
            foreach (var item in items) {
                if (dataReader[item].GetType().ToString() == "System.Single") {
                    temp.floatData.Add(item, (float)dataReader[item]);
                }
                else if (dataReader[item].GetType().ToString() == "System.String") {
                    temp.stringData.Add(item, (string)dataReader[item]);
                }
                else if (dataReader[item].GetType().ToString() == "System.Int64") {
                    temp.intData.Add(item, (int)(Int64)dataReader[item]);
                }
                else {
                    Debug.LogError($"dataReader is reading undefined type : {dataReader[item].GetType()}");
                }
            }
            _result.Add(temp);
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
        _isAlreadyRunning = true;
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
        
        _isAlreadyRunning = false;
    }
}
