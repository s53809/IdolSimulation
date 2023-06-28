public class Enemy : Entity
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
}
