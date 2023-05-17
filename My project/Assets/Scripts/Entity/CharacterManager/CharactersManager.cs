using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactersManager : MonoBehaviour
{
    public IDictionary Characters { get; private set; }

    private static CharactersManager _instance;
    public static CharactersManager Instance { 
        get {
            if (_instance == null)
            {
                throw new Exception("You don't have Characters Manager");
            }
            else { return _instance; }
        }
    }

    private void Awake()
    {
        if (_instance != null) Destroy(this.gameObject);
        else _instance = this;
        Characters = new Dictionary<int, Character>();
    }
}
