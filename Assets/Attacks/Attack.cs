using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public abstract class Attack : MonoBehaviour
{
    public string attackName = "None";
    public int damage = 10;
    public int baseDamage = 10;
    public int chance = 100;
    public int range = 100;
    public int level = 1;
    public int exp = 0;
    public GameObject projectilePrefab;
    public int[] levelThresholds = { 0, 1, 3, 6, 10, 15, 21, 28, 36, 45, 55, 66, 78, 91, 105, 120, 136, 153, 171, 190, 210, 231, 253, 276, 300, 325, 351, 378, 406, 435, 465, 496, 528, 561, 595, 630,666};
    public int cost = 10;
    public Character character;

    public virtual void Use() { }

    public void Update()
    {
        Levelup();
    }

    public void Levelup() {
        if (exp >= levelThresholds[level + 1] * 3) {
            level++;
            damage = baseDamage * level;
        }
    }

    public void Start()
    {
        baseDamage = damage;
        character = GetComponent<Character>();
    }
}
