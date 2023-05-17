using System.Collections.Generic;

public class Character : Entity, IDamageable
{
    public string name { get; private set; }
    public Mood mood { get; private set; }

    public Character(int id, string name, int health, int damage)
    {
        this.id = id;
        this.health = health;
        this.damage = damage;
        this.name = name;
        this.mood = Mood.HappyHappyHappy;
    }

    public void Damaged(int damage)
    {
        if (this.health - damage <= 0)
        {
            //Todo: �׾��� �� ��Ȳ ¥��
        }
        else this.health -= damage;
    }
}
