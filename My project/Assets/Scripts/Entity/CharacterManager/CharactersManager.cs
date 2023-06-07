using System;
using System.Collections.Generic;
using UnityEngine;

public class CharactersManager : MonoBehaviour {
    public IDictionary<int, Character> Characters { get; private set; }

    private static CharactersManager _instance;

    public static CharactersManager Instance {
        get {
            if (_instance == null) {
                throw new Exception("You don't have Characters Manager");
            }
            else {
                return _instance;
            }
        }
    }

    private void Awake() {
        if (_instance != null) Destroy(this.gameObject);
        else {
            DontDestroyOnLoad(this);
            _instance = this;
        }

        Characters = new Dictionary<int, Character>();
    }

    private void Start() {
        string[] items = new string[] { "ID", "Name", "Health", "Damage", "Mood" };

        List<DBData> result = DBReader.Instance.ReadDB("/DB/CharacterDB/Character",
            "Select * From Characters", items);

        foreach (var item in result) {
            Characters.Add(item.intData["ID"],
                new Character(
                    item.intData["ID"],
                    item.stringData["Name"],
                    item.intData["Health"], 
                    item.intData["Damage"],
                    (Mood)item.intData["Mood"]
                ));
        }
        
        Debug.Log(Characters[30002]);
    }
}