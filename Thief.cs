using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thief : Character
{

    Thief()
    {
        health -= 50;
        mana -= 50;
        stamina += 100;
        characterName = "Pick";
        bodyType = "ThiefBody";
    }

    void Start()
    {
        Attack _stab = gameObject.AddComponent<Stab>();
        attacks.Add(_stab);
        SetBody();
    }
}

