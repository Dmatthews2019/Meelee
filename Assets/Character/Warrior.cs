using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : Character
{

    Warrior()
    {
        health += 100;
        mana -= 0;
        stamina -= 100;
        characterName = "Slash";
        bodyType = "WarriorBody";
    }

    void Start()
    {
        Attack _slash = gameObject.AddComponent<Slash>();
        attacks.Add(_slash);
        SetBody();
        
    }


}
