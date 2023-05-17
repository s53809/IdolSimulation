public class Enemy : Entity, IDamageable
{
    public Enemy(int id, int health, int damage)
    {
        this.id = id;
        this.health = health;
        this.damage = damage;
    }

    public Enemy(int id)
    {
        this.id = id;
        this.health = 0;
        this.damage = 0;
    }

    public void Damaged(int damage)
    {
        if (this.health - damage <= 0)
        {
            //Todo: 죽었을 때 상황 만들기
        }
        else this.health -= damage;
    }
}
