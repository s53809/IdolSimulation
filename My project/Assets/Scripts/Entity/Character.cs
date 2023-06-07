using System;
using System.IO;

public class Character : Entity, IDamageable
{
    public string name { get; private set; }
    public Mood mood { get; private set; }

    public Character(int id, string name, int health, int damage, Mood mood)
    {
        this.id = id;
        this.health = health;
        this.damage = damage;
        this.name = name;
        this.mood = mood;
        //#todo: Resources.Load를 이용하여 캐릭터 프리펩 가져오기 (캐릭터 프리팹의 이름은 캐릭터 id로 되어있을 예정)
    }

    public void Damaged(int damage)
    {
        if (this.health - damage <= 0)
        {
            //Todo: 죽었을 때 상황 짜기
        }
        else this.health -= damage;
    }
    
    public override string ToString() {
        return $"{id}({name}) : hp:{health}, damage:{damage}, mood:{mood.ToString()}";
    }
}
