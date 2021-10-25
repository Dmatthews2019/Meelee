using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage : Character
{

    Mage()
    {
        health -= 20;
        mana += 50;
        stamina += 10;
        characterName = "Hex";
        bodyType = "MageBody";
        healthRegen += 1;
        manaRegen += 10; 
        staminaRegen += 1;
}

    void Start()
    {
        baseHealth = health;
        baseMana = mana;
        baseStamina = stamina;
        Attack _dark = gameObject.AddComponent<Dark>();
        Attack _light = gameObject.AddComponent<Light>();
        attacks.Add(_dark);
        attacks.Add(_light);
        SetBody();
    }

    

}
