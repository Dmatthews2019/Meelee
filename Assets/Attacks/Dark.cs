using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dark : Cast
{
    Dark() {
        attackName = "Dark";
        damage += 10;
        chance += 0;
        cost += 0;
    }

    public override void Use() {
        if (character.mana > cost)
        {
            for (int i = 0; i < level; i++)
            {
                GameObject projectile = Instantiate(AttackPrefabs._instance.ProjectilePrefab,
                    transform.position
                    , transform.rotation); ;
                projectile component = projectile.GetComponent<projectile>();
                component.damage = damage;
                component.Player = gameObject;
                component.Attack = this;
                projectile.SetActive(true);
            }
            character.ReduceMana(cost);
        }

    }
}
