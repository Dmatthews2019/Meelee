using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform target;
    public int health = 100;
    public int damage = 10;
    public int exp = 1;

    private void Update()
    {
        agent.SetDestination(target.position);
        
    }

    public void Start()
    {
        health = health * (int)(1 + Mathf.Pow(WaveManager._instance.wave, 1.75f));
    }

    public void takeDamage(int damage, GameObject Player, Attack Attack)
    {
        health -= damage;
        if (health <= 0)
        {
            SpawnEnemy._instance.count -= 1;
            Attack.exp += exp * 5;
            Destroy(gameObject);            
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Character>().takeDamage(damage);
        }
    }
}
