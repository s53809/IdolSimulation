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
        //#todo: Resources.Load�� �̿��Ͽ� ĳ���� ������ �������� (ĳ���� �������� �̸��� ĳ���� id�� �Ǿ����� ����)
    }

    public void Damaged(int damage)
    {
        if (this.health - damage <= 0)
        {
            //Todo: �׾��� �� ��Ȳ ¥��
        }
        else this.health -= damage;
    }
    
    public override string ToString() {
        return $"{id}({name}) : hp:{health}, damage:{damage}, mood:{mood.ToString()}";
    }
}
