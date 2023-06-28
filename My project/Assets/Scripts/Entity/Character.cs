using System;
using System.IO;
using UnityEngine;

public class Character : Entity 
{ 
    public string entityName { get; private set; }
    public Mood mood { get; private set; }

    public Character(int id, string name, int health, int damage, Mood mood)
    {
        this.id = id;
        this.health = health;
        this.damage = damage;
        this.entityName = name;
        this.mood = mood;
    }
    
    public override string ToString() {
        return $"{id}({entityName}) : hp:{health}, damage:{damage}, mood:{mood.ToString()}";
    }
}
