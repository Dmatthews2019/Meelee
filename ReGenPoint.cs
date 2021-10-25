using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReGenPoint : MonoBehaviour
{
    Character character;
    public int AlivePoints = 100;

    float myUpdate = 0;

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.layer == 8 && Time.time > myUpdate + .2f)
        {
            character = collision.gameObject.GetComponent<Character>();
            if (character.health < character.baseMana)
            {
                collision.gameObject.GetComponent<Character>().health += 10;
            }
            if (character.mana < character.baseMana)
            {
                collision.gameObject.GetComponent<Character>().mana += 10;
            }
            if (character.stamina < character.baseStamina)
            {
                collision.gameObject.GetComponent<Character>().stamina += 10;
            }
            myUpdate = Time.time;
            AlivePoints -= 10;
            Debug.Log(AlivePoints);
        }

    }
}
