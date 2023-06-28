using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterEntity : MonoBehaviour, IDamageable
{
    public float health = 0;
    public float damage = 0;

    public float maxHealth = 0;

    public GameObject parent;

    private void Start()
    {
        maxHealth = health;
        transform.GetChild(0).GetComponent<HealthBar>().SetHealth(health, maxHealth);
    }
    public void Damaged(float damage)
    {
        health -= damage;
        transform.GetChild(0).GetComponent<HealthBar>().SetHealth(health, maxHealth);
        if (health < 0)
        {
            if (gameObject.tag == "GameController") parent.GetComponent<gmzer>().enemyCount--;
            Destroy(gameObject);
            health = 0;
        }
        else
        {
            Attacked();
        }
    }

    public void SetWalk(bool isWalk)
    {
        GetComponent<Animator>().SetBool("isWalk", isWalk);
    }

    public void Attack()
    {
        GetComponent<Animator>().SetTrigger("isAttack");
    }

    public void Attacked()
    {
        GetComponent<Animator>().SetTrigger("isAttacked");
    }
}